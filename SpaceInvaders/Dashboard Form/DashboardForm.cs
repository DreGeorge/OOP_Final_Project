using MySql.Data.MySqlClient;
using SpaceInvaders.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class DashboardForm : Form
    {
        private Panel shadow;
        private readonly string currentUserId;

        private System.Windows.Forms.Timer hudClockTimer;

        private const string ADMIN_PASSWORD = "xtremeadmin";
        private bool isDeployed = false;

        // ✅ XP progress block
        private Label lblXpNextTitle;
        private ProgressBar pbXpNext;
        private Label lblXpNextValue;
        private int currentXp = 0;
        private const int RankXpThreshold = 5000;

        // ✅ Rank ladder (no DB)
        private readonly string[] RankNames =
        {
            "LIEUTENANT",
            "CAPTAIN",
            "MAJOR",
            "COLONEL",
            "GENERAL"
        };

        // ✅ Mission 4-hour countdown (no DB)
        private Label lblMissionCountdown;
        private System.Windows.Forms.Timer missionCountdownTimer;
        private int missionCooldownSeconds = 0;
        private const int MissionCooldownTotalSeconds = 4 * 60 * 60; // 4 hours

        // Leaderboard dynamic refs
        private readonly List<Panel> leaderboardSlots = new List<Panel>();
        private readonly List<Label> leaderboardLabels = new List<Label>();
        private Button btnViewLeaderboards;

        // Achievements dynamic refs (page shows 3)
        private readonly List<Panel> achievementSlots = new List<Panel>();
        private readonly List<PictureBox> achievementIcons = new List<PictureBox>();
        private readonly List<Label> achievementTitles = new List<Label>();
        private readonly List<Label> achievementLocks = new List<Label>();

        // Pagination controls
        private Button btnAchPrev;
        private Button btnAchNext;
        private Label lblAchPage;

        // Achievements data (many)
        private List<Achievement> allAchievements = new List<Achievement>();
        private const int AchievementsPerPage = 3;
        private int achievementsPageIndex = 0;

        private class Achievement
        {
            public string Title;
            public string Description;
            public string LockedHint;
            public bool Unlocked;

            public Achievement(string title, string desc, string lockedHint, bool unlocked)
            {
                Title = title;
                Description = desc;
                LockedHint = lockedHint;
                Unlocked = unlocked;
            }
        }

        public DashboardForm(string userId)
        {
            InitializeComponent();

            currentUserId = userId;

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;

            Load += DashboardForm_Load;
            Resize += DashboardForm_Resize;
            KeyPreview = true;
            KeyDown += DashboardForm_KeyDown;

            btnLogout.Click += BtnLogout_Click;

            btnDeploy.Click += BtnDeploy_Click;
            btnMIA.Click += BtnLeaveBattlefield_Click;

            btnQuest1.Click += BtnQuest1_Click;
            btnQuest2.Click += BtnQuest2_Click;
            btnQuest3.Click += BtnQuest3_Click;

            if (pbAdminLogo != null)
                pbAdminLogo.Click += PbAdminLogo_Click;

            if (picAvatar != null)
            {
                picAvatar.Cursor = Cursors.Hand;
                picAvatar.Click += PicAvatar_Click;
            }

            hudClockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            hudClockTimer.Tick += HudClockTimer_Tick;

            // ✅ countdown timer
            missionCountdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            missionCountdownTimer.Tick += MissionCountdownTimer_Tick;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (pbGifBackground != null)
            {
                pbGifBackground.Visible = false;
                pbGifBackground.Enabled = false;
            }

            DashboardFormStyler.SetupStaticUI(
                pnlCard,
                pnlProfile,
                pnlMission,
                pnlSideTopActions,
                pnlSideBottomActions,
                pnlStatus,
                pnlLogs,
                pnlQuestStrip,
                pnlTime,
                lblQuestStripTitle,
                lblTimeHeader,
                lblTimeValue,
                lblHudTitle,
                lblWelcome,
                lblSub,
                lblRank,
                lblXP,
                btnLogout,
                btnDeploy,
                btnMIA,
                btnQuest1,
                btnQuest2,
                btnQuest3,
                picAvatar
            );

            EnsureXpProgressControls();
            EnsureMissionCountdownControl();

            LoadAvatarPlaceholder();
            LoadUserProfileSafe();

            ApplyUI();

            btnLogout.Visible = true;
            btnLogout.Enabled = true;

            if (lblLogsHeader != null)
                lblLogsHeader.Text = "CLASSIFIED ACCESS";

            if (pbAdminLogo != null)
            {
                pbAdminLogo.Visible = true;
                pbAdminLogo.Enabled = true;
                pbAdminLogo.Cursor = Cursors.Hand;

                try
                {
                    pbAdminLogo.Image = Image.FromFile("alien.png");
                    pbAdminLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }

                var tip = new ToolTip();
                tip.SetToolTip(pbAdminLogo, "ALIEN ADMIN ACCESS");
            }

            SetupMissionPanel();

            SeedAchievements();
            SetupAchievementsPanel();

            SetupLeaderboardsPanel();

            UpdateClockText();
            hudClockTimer.Start();

            UpdateStatusUI();
            UpdateMissionCountdownText();
        }

        private void EnsureXpProgressControls()
        {
            if (lblXpNextTitle == null)
            {
                lblXpNextTitle = new Label
                {
                    Name = "lblXpNextTitle",
                    Text = "XP TO CAPTAIN",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                pnlProfile.Controls.Add(lblXpNextTitle);
            }

            if (pbXpNext == null)
            {
                pbXpNext = new ProgressBar
                {
                    Name = "pbXpNext",
                    Minimum = 0,
                    Maximum = RankXpThreshold,
                    Value = 0
                };
                pnlProfile.Controls.Add(pbXpNext);
            }

            if (lblXpNextValue == null)
            {
                lblXpNextValue = new Label
                {
                    Name = "lblXpNextValue",
                    Text = $"0 / {RankXpThreshold} XP",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    BackColor = Color.Transparent
                };
                pnlProfile.Controls.Add(lblXpNextValue);
            }

            lblXpNextTitle.BringToFront();
            pbXpNext.BringToFront();
            lblXpNextValue.BringToFront();
        }

        private void EnsureMissionCountdownControl()
        {
            if (lblMissionCountdown != null) return;

            lblMissionCountdown = new Label
            {
                Name = "lblMissionCountdown",
                ForeColor = Color.White,
                Font = new Font("Consolas", 18F, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlMission.Controls.Add(lblMissionCountdown);
            lblMissionCountdown.BringToFront();
        }

        private void LoadAvatarPlaceholder()
        {
            if (picAvatar == null) return;

            try
            {
                picAvatar.Image = Image.FromFile("avatar_meme.png");
                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                picAvatar.Image = null;
            }

            picAvatar.Invalidate();
        }

        private void PicAvatar_Click(object sender, EventArgs e)
        {
            HudMessageBox.Show(
                "Edit Profile screen not implemented yet.",
                "COMING SOON",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private void DashboardForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = DashboardFormStyler.ApplyRuntimeLayout(
                this,
                pnlCard,
                shadow,
                pnlProfile,
                pnlMission,
                pnlSideTopActions,
                pnlSideBottomActions,
                pnlStatus,
                pnlLogs,
                pnlQuestStrip,
                pnlTime,
                lblHudTitle,
                btnLogout
            );

            DashboardFormStyler.LayoutProfileChildren(
                pnlProfile,
                picAvatar,
                lblWelcome,
                lblRank,
                lblXpNextTitle,
                pbXpNext,
                lblXpNextValue
            );

            DashboardFormStyler.LayoutMissionCountdown(
                pnlMission,
                lblMissionHeader,
                lblMissionCountdown
            );

            DashboardFormStyler.LayoutStatusChildren(
                pnlStatus,
                lblStatusHeader,
                pbStatusArc,
                lblCritical
            );

            DashboardFormStyler.LayoutLogsChildren(
                pnlLogs,
                lblLogsHeader,
                pbAdminLogo
            );

            LayoutMissionPanelControls();
            LayoutAchievementsSlots();
            LayoutLeaderboardsSlots();

            Invalidate();
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private void HudClockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClockText();
        }

        private void UpdateClockText()
        {
            lblTimeValue.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UpdateXpProgressUI()
        {
            if (pbXpNext == null || lblXpNextValue == null || lblXpNextTitle == null) return;

            int currentRankIndex = currentXp / RankXpThreshold;
            if (currentRankIndex < 0) currentRankIndex = 0;
            if (currentRankIndex >= RankNames.Length) currentRankIndex = RankNames.Length - 1;

            int nextRankIndex = currentRankIndex + 1;
            if (nextRankIndex >= RankNames.Length)
                nextRankIndex = RankNames.Length - 1;

            string nextRankName = RankNames[nextRankIndex];

            int progressInRank = currentXp % RankXpThreshold;
            if (progressInRank < 0) progressInRank = 0;
            if (progressInRank > RankXpThreshold) progressInRank = RankXpThreshold;

            pbXpNext.Maximum = RankXpThreshold;
            pbXpNext.Value = progressInRank;

            lblXpNextTitle.Text = $"XP TO {nextRankName}";
            lblXpNextValue.Text = $"{progressInRank:N0} / {RankXpThreshold:N0} XP";
        }

        private void LoadUserProfileSafe()
        {
            try
            {
                string q =
                    "SELECT ui.LastName, IFNULL(us.total_xp, 0) AS total_xp " +
                    "FROM user_info ui " +
                    "LEFT JOIN user_statistics us ON ui.UserName = us.UserName " +
                    "WHERE ui.UserName = @uname LIMIT 1";

                var dt = DbHelper.ExecuteQuery(q, cmd =>
                {
                    cmd.Parameters.AddWithValue("@uname", currentUserId);
                });

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];

                    string lastName = row["LastName"]?.ToString();
                    string xpStr = row["total_xp"]?.ToString();

                    lblWelcome.Text = !string.IsNullOrWhiteSpace(lastName)
                        ? $"Lt. {lastName}"
                        : $"Lt. {currentUserId}";

                    if (int.TryParse(xpStr, out int xpVal))
                        currentXp = xpVal;
                    else
                        currentXp = 0;
                }
                else
                {
                    lblWelcome.Text = $"Lt. {currentUserId}";
                    currentXp = 0;
                }
            }
            catch
            {
                lblWelcome.Text = $"Lt. {currentUserId}";
                currentXp = 0;
            }

            UpdateXpProgressUI();
        }

        private void UpdateStatusUI()
        {
            if (lblCritical == null) return;

            if (isDeployed)
            {
                lblCritical.Text = "DEPLOYED";
                DashboardFormStyler.SetCriticalStatusState(lblCritical, true);
                if (pbStatusArc != null) pbStatusArc.Value = 100;
            }
            else
            {
                lblCritical.Text = "ON STANDBY";
                DashboardFormStyler.SetCriticalStatusState(lblCritical, false);
                if (pbStatusArc != null) pbStatusArc.Value = 35;
            }
        }

        private void SetupMissionPanel()
        {
            if (lblMissionHeader != null)
                lblMissionHeader.Text = "TODAY'S MISSION";

            if (btnDeploy != null)
                btnDeploy.Text = "DEPLOY";

            if (btnMIA != null)
                btnMIA.Text = "LEAVE BATTLEFIELD";

            isDeployed = false;
            UpdateDeploymentUI();
            UpdateStatusUI();
            UpdateMissionCountdownText();

            LayoutMissionPanelControls();
        }

        private void LayoutMissionPanelControls()
        {
            if (pnlMission == null || btnDeploy == null || btnMIA == null) return;

            int padding = 18;
            int gap = 12;
            int buttonWidth = (pnlMission.Width - padding * 2 - gap) / 2;
            int buttonHeight = Math.Max(60, pnlMission.Height / 5);

            int yBottom = pnlMission.Height - padding - buttonHeight;
            int totalButtonsWidth = buttonWidth * 2 + gap;
            int xStart = (pnlMission.Width - totalButtonsWidth) / 2;

            btnDeploy.Size = new Size(buttonWidth, buttonHeight);
            btnMIA.Size = new Size(buttonWidth, buttonHeight);

            btnDeploy.Location = new Point(xStart, yBottom);
            btnMIA.Location = new Point(xStart + buttonWidth + gap, yBottom);

            btnDeploy.Anchor = AnchorStyles.Bottom;
            btnMIA.Anchor = AnchorStyles.Bottom;
        }

        private void UpdateDeploymentUI()
        {
            if (btnMIA == null || btnDeploy == null) return;

            DashboardFormStyler.SetLeaveBattlefieldVisualState(btnMIA, isDeployed ? btnDeploy : null);
            btnMIA.Enabled = isDeployed;
        }

        private void BtnDeploy_Click(object sender, EventArgs e)
        {
            if (missionCooldownSeconds > 0)
            {
                HudMessageBox.Show(
                    "MISSION COOLDOWN ACTIVE.\nWait for countdown to finish.",
                    "COOLDOWN",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Warning,
                    this
                );
                return;
            }

            if (isDeployed)
            {
                HudMessageBox.Show(
                    "You are already deployed.",
                    "DEPLOYED",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Info,
                    this
                );
                return;
            }

            isDeployed = true;
            UpdateDeploymentUI();
            UpdateStatusUI();

            missionCooldownSeconds = MissionCooldownTotalSeconds;
            missionCountdownTimer.Start();
            btnDeploy.Enabled = false;

            UpdateMissionCountdownText();

            HudMessageBox.Show(
                "DEPLOYMENT CONFIRMED.\nMission countdown started.",
                "DEPLOY",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private void BtnLeaveBattlefield_Click(object sender, EventArgs e)
        {
            if (!isDeployed)
            {
                HudMessageBox.Show(
                    "You can't leave battlefield unless you're deployed.",
                    "ACCESS DENIED",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Warning,
                    this
                );
                return;
            }

            isDeployed = false;
            UpdateDeploymentUI();
            UpdateStatusUI();

            UpdateMissionCountdownText();

            HudMessageBox.Show(
                "You have left the battlefield.\nCooldown still running.",
                "LEAVE BATTLEFIELD",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private void MissionCountdownTimer_Tick(object sender, EventArgs e)
        {
            if (missionCooldownSeconds <= 0)
            {
                missionCooldownSeconds = 0;
                missionCountdownTimer.Stop();
                btnDeploy.Enabled = true;
                UpdateMissionCountdownText();
                return;
            }

            missionCooldownSeconds--;
            UpdateMissionCountdownText();

            if (missionCooldownSeconds == 0)
            {
                btnDeploy.Enabled = true;
                UpdateMissionCountdownText();
            }
        }

        private void UpdateMissionCountdownText()
        {
            if (lblMissionCountdown == null) return;

            if (missionCooldownSeconds <= 0)
            {
                lblMissionCountdown.Text = "READY FOR DEPLOYMENT";
                return;
            }

            TimeSpan t = TimeSpan.FromSeconds(missionCooldownSeconds);
            lblMissionCountdown.Text = $"MISSION TIMER\n{t:hh\\:mm\\:ss}";
        }

        private void SeedAchievements()
        {
            allAchievements = new List<Achievement>
            {
                new Achievement("FIRST DEPLOYMENT","Complete your first successful class attendance deployment.","Deploy once.",true),
                new Achievement("3-DAY STREAK","Attend classes for 3 consecutive days without missing.","Maintain a 3-day deployed streak.",false),
                new Achievement("PERFECT WEEK","No absences for 7 straight days. Absolute discipline.","Finish 7 days with zero MIA.",false),
                new Achievement("NIGHT OPS","Complete an attendance deployment after 6PM.","Deploy at night.",false),
                new Achievement("MISSION MASTER","Reach the top 3 in Leaderboards.","Place Top 3.",false),
                new Achievement("NO MIA MONTH","Survive 30 days with no missed deployments.","Go 30 days perfect.",false),
            };

            achievementsPageIndex = 0;
        }

        private int TotalAchievementPages
        {
            get
            {
                if (allAchievements == null || allAchievements.Count == 0) return 1;
                return (int)Math.Ceiling(allAchievements.Count / (double)AchievementsPerPage);
            }
        }

        private void SetupAchievementsPanel()
        {
            if (pnlSideTopActions == null) return;

            if (lblSideTopHeader != null)
                lblSideTopHeader.Text = "ACHIEVEMENTS";

            EnsureAchievementPaginationControls();

            foreach (var s in achievementSlots)
                pnlSideTopActions.Controls.Remove(s);

            achievementSlots.Clear();
            achievementIcons.Clear();
            achievementTitles.Clear();
            achievementLocks.Clear();

            for (int i = 0; i < AchievementsPerPage; i++)
            {
                Panel slot = new Panel { BackColor = Color.Transparent, Cursor = Cursors.Hand };

                PictureBox pic = new PictureBox
                {
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                Label title = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lockLbl = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                DashboardFormStyler.StyleAchievementSlot(slot);
                DashboardFormStyler.StyleAchievementIcon(pic);
                DashboardFormStyler.StyleAchievementTitle(title);
                DashboardFormStyler.StyleAchievementLockLabel(lockLbl);

                slot.Controls.Add(pic);
                slot.Controls.Add(title);
                slot.Controls.Add(lockLbl);

                slot.MouseEnter += (s, e) => DashboardFormStyler.SetAchievementHover(slot, true);
                slot.MouseLeave += (s, e) => DashboardFormStyler.SetAchievementHover(slot, false);

                achievementSlots.Add(slot);
                achievementIcons.Add(pic);
                achievementTitles.Add(title);
                achievementLocks.Add(lockLbl);
                pnlSideTopActions.Controls.Add(slot);
            }

            RenderAchievementsPage();
            LayoutAchievementsSlots();
        }

        private void EnsureAchievementPaginationControls()
        {
            if (btnAchPrev == null)
            {
                btnAchPrev = new Button { Name = "btnAchPrev", Text = "PREV" };
                DashboardFormStyler.StyleAchievementNavButton(btnAchPrev);
                btnAchPrev.Click += (s, e) => ChangeAchievementPage(-1);
                pnlSideTopActions.Controls.Add(btnAchPrev);
            }

            if (btnAchNext == null)
            {
                btnAchNext = new Button { Name = "btnAchNext", Text = "NEXT" };
                DashboardFormStyler.StyleAchievementNavButton(btnAchNext);
                btnAchNext.Click += (s, e) => ChangeAchievementPage(1);
                pnlSideTopActions.Controls.Add(btnAchNext);
            }

            if (lblAchPage == null)
            {
                lblAchPage = new Label { Name = "lblAchPage" };
                DashboardFormStyler.StyleAchievementPageLabel(lblAchPage);
                pnlSideTopActions.Controls.Add(lblAchPage);
            }

            btnAchPrev.BringToFront();
            btnAchNext.BringToFront();
            lblAchPage.BringToFront();
        }

        private void ChangeAchievementPage(int delta)
        {
            int total = TotalAchievementPages;
            achievementsPageIndex += delta;

            if (achievementsPageIndex < 0) achievementsPageIndex = 0;
            if (achievementsPageIndex > total - 1) achievementsPageIndex = total - 1;

            RenderAchievementsPage();
            LayoutAchievementsSlots();
        }

        private void RenderAchievementsPage()
        {
            int start = achievementsPageIndex * AchievementsPerPage;

            for (int i = 0; i < AchievementsPerPage; i++)
            {
                int idx = start + i;

                bool hasData = idx < allAchievements.Count;
                Achievement ach = hasData ? allAchievements[idx] : null;

                PictureBox pic = achievementIcons[i];
                Label title = achievementTitles[i];
                Label lockLbl = achievementLocks[i];
                Panel slot = achievementSlots[i];

                slot.Visible = hasData;

                if (!hasData) continue;

                title.Text = ach.Title;
                DashboardFormStyler.ApplyAchievementState(pic, title, lockLbl, ach.Unlocked);

                slot.Tag = ach;
                pic.Tag = ach;
                title.Tag = ach;

                slot.Click -= AchievementSlot_Click;
                pic.Click -= AchievementSlot_Click;
                title.Click -= AchievementSlot_Click;

                slot.Click += AchievementSlot_Click;
                pic.Click += AchievementSlot_Click;
                title.Click += AchievementSlot_Click;
            }

            int totalPages = TotalAchievementPages;
            lblAchPage.Text = $"PAGE {achievementsPageIndex + 1}/{totalPages}";
            btnAchPrev.Enabled = achievementsPageIndex > 0;
            btnAchNext.Enabled = achievementsPageIndex < totalPages - 1;
        }

        private void AchievementSlot_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c?.Tag is Achievement ach)
            {
                ShowAchievementPopup(ach);
            }
        }

        private void ShowAchievementPopup(Achievement ach)
        {
            using (Form pop = new Form())
            {
                pop.StartPosition = FormStartPosition.CenterParent;
                pop.FormBorderStyle = FormBorderStyle.FixedDialog;
                pop.MaximizeBox = false;
                pop.MinimizeBox = false;
                pop.Width = 420;
                pop.Height = 240;

                Label lblTitle = new Label();
                Label lblDesc = new Label();
                Button btnOk = new Button();

                DashboardFormStyler.StyleAchievementPopup(pop, lblTitle, lblDesc, btnOk);

                lblTitle.Text = ach.Title;
                lblDesc.Text = ach.Unlocked
                    ? ach.Description
                    : ("LOCKED ACHIEVEMENT\n\n" + ach.LockedHint);

                btnOk.Click += (s, e) => pop.Close();

                pop.Controls.Add(lblTitle);
                pop.Controls.Add(lblDesc);
                pop.Controls.Add(btnOk);

                pop.ShowDialog(this);
            }
        }

        private void LayoutAchievementsSlots()
        {
            if (pnlSideTopActions == null || achievementSlots.Count == 0) return;

            int padding = 14;
            int gap = 8;
            int navH = 34;

            int headerBottom = (lblSideTopHeader != null)
                ? lblSideTopHeader.Bottom + 8
                : padding;

            int usableH = pnlSideTopActions.Height - headerBottom - padding - navH;
            int usableW = pnlSideTopActions.Width - padding * 2;

            int slotW = (usableW - gap * 2) / 3;
            int slotH = usableH;

            int x = padding;
            for (int i = 0; i < achievementSlots.Count; i++)
            {
                Panel slot = achievementSlots[i];
                slot.Location = new Point(x, headerBottom);
                slot.Size = new Size(slotW, slotH);

                PictureBox pic = achievementIcons[i];
                Label title = achievementTitles[i];
                Label lockLbl = achievementLocks[i];

                int iconSize = Math.Min(slotW - 10, (int)(slotH * 0.55));
                if (iconSize < 42) iconSize = 42;

                pic.Size = new Size(iconSize, iconSize);
                pic.Location = new Point((slotW - iconSize) / 2, 6);

                int titleH = 32;
                title.Size = new Size(slotW - 8, titleH);
                title.Location = new Point(4, pic.Bottom + 4);

                lockLbl.Size = pic.Size;
                lockLbl.Location = pic.Location;

                x += slotW + gap;
            }

            int navY = pnlSideTopActions.Height - padding - navH;

            if (btnAchPrev != null)
            {
                btnAchPrev.Size = new Size(70, navH);
                btnAchPrev.Location = new Point(padding, navY);
            }

            if (btnAchNext != null)
            {
                btnAchNext.Size = new Size(70, navH);
                btnAchNext.Location = new Point(
                    pnlSideTopActions.Width - padding - btnAchNext.Width,
                    navY
                );
            }

            if (lblAchPage != null)
            {
                lblAchPage.Size = new Size(120, navH);
                lblAchPage.Location = new Point(
                    (pnlSideTopActions.Width - lblAchPage.Width) / 2,
                    navY + 2
                );
            }
        }

        private void SetupLeaderboardsPanel()
        {
            if (pnlSideBottomActions == null) return;

            pnlSideBottomActions.AutoScroll = false;

            if (lblSideBottomHeader != null)
                lblSideBottomHeader.Text = "LEADERBOARDS";

            if (btnViewLeaderboards == null)
            {
                btnViewLeaderboards = new Button { Name = "btnViewLeaderboards" };
                DashboardFormStyler.StyleLeaderboardsViewButton(btnViewLeaderboards);
                btnViewLeaderboards.Click += BtnViewLeaderboards_Click;
                pnlSideBottomActions.Controls.Add(btnViewLeaderboards);
            }

            foreach (var s in leaderboardSlots)
                pnlSideBottomActions.Controls.Remove(s);

            leaderboardSlots.Clear();
            leaderboardLabels.Clear();

            string[] lastNames = LoadLeaderboardLastNamesSafe();

            for (int i = 0; i < 3; i++)
            {
                Panel slot = new Panel { BackColor = Color.Transparent };

                Label lbl = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = $"Lt. {lastNames[i]}"
                };

                DashboardFormStyler.StyleLeaderboardNameLabel(lbl);
                lbl.Paint += DashboardFormStyler.DrawLeaderboardNameBorder;

                slot.Controls.Add(lbl);

                leaderboardSlots.Add(slot);
                leaderboardLabels.Add(lbl);
                pnlSideBottomActions.Controls.Add(slot);
            }

            LayoutLeaderboardsSlots();
        }

        private void BtnViewLeaderboards_Click(object sender, EventArgs e)
        {
            HudMessageBox.Show(
                "Leaderboards screen not implemented yet.",
                "COMING SOON",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private string[] LoadLeaderboardLastNamesSafe()
        {
            string[] fallback = { "Shadow", "Nova", "Orion" };

            try
            {
                List<string> names = new List<string>();

                using (var conn = DbConnectionFactory.Create())
                {
                    conn.Open();

                    string q =
                        "SELECT ui.LastName " +
                        "FROM user_info ui " +
                        "JOIN user_statistics us ON ui.UserName = us.UserName " +
                        "WHERE ui.UserName <> @uname " +
                        "ORDER BY us.total_xp DESC " +
                        "LIMIT 3";

                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", currentUserId);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string ln = r["LastName"]?.ToString();
                                if (!string.IsNullOrWhiteSpace(ln))
                                    names.Add(ln);
                            }
                        }
                    }
                }

                while (names.Count < 3)
                    names.Add("Recruit");

                return names.ToArray();
            }
            catch
            {
                return fallback;
            }
        }

        private void LayoutLeaderboardsSlots()
        {
            if (pnlSideBottomActions == null || leaderboardSlots.Count == 0) return;

            int padding = 14;
            int gap = 8;

            int btnW = 64;
            int btnH = 28;

            int headerTop = (lblSideBottomHeader != null) ? lblSideBottomHeader.Top : padding;

            if (btnViewLeaderboards != null)
            {
                btnViewLeaderboards.Size = new Size(btnW, btnH);
                btnViewLeaderboards.Location = new Point(
                    pnlSideBottomActions.Width - padding - btnW,
                    headerTop - 3
                );
            }

            int headerBottom = (lblSideBottomHeader != null)
                ? lblSideBottomHeader.Bottom + 8
                : padding;

            int usableH = pnlSideBottomActions.Height - headerBottom - padding;
            if (usableH < 120) usableH = 120;

            int slotH = (usableH - gap * 2) / 3;
            if (slotH < 48) slotH = 48;

            int slotW = pnlSideBottomActions.Width - padding * 2;

            int y = headerBottom;
            for (int i = 0; i < leaderboardSlots.Count; i++)
            {
                Panel slot = leaderboardSlots[i];
                slot.Location = new Point(padding, y);
                slot.Size = new Size(slotW, slotH);

                Label lbl = leaderboardLabels[i];
                int labelPad = 6;
                lbl.Location = new Point(labelPad, labelPad);
                lbl.Size = new Size(slotW - labelPad * 2, slotH - labelPad * 2);

                y += slotH + gap;
            }
        }

        private void PbAdminLogo_Click(object sender, EventArgs e)
        {
            ShowAdminPasswordPrompt();
        }

        private void ShowAdminPasswordPrompt()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 360;
                prompt.Height = 200;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.Text = "ADMIN ACCESS";
                prompt.BackColor = Color.Black;
                prompt.ForeColor = Color.White;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label
                {
                    Left = 20,
                    Top = 20,
                    Width = 300,
                    Text = "ENTER ADMIN PASSWORD"
                };

                TextBox inputBox = new TextBox
                {
                    Left = 20,
                    Top = 60,
                    Width = 300,
                    PasswordChar = '*'
                };

                Button confirmation = new Button
                {
                    Text = "CONFIRM",
                    Left = 70,
                    Width = 90,
                    Top = 110
                };

                Button cancel = new Button
                {
                    Text = "CANCEL",
                    Left = 180,
                    Width = 90,
                    Top = 110
                };

                DashboardFormStyler.StyleAdminPromptButtons(confirmation, cancel);

                confirmation.Click += (s, e) =>
                {
                    if (inputBox.Text == ADMIN_PASSWORD)
                    {
                        prompt.Close();
                        HudMessageBox.Show(
                            "ADMIN MODE UNLOCKED.",
                            "ACCESS GRANTED",
                            HudMessageBoxButtons.OK,
                            HudMessageBoxIcon.Success,
                            this
                        );
                    }
                    else
                    {
                        HudMessageBox.Show(
                            "INVALID PASSWORD.",
                            "ACCESS DENIED",
                            HudMessageBoxButtons.OK,
                            HudMessageBoxIcon.Warning,
                            this
                        );
                    }
                };

                cancel.Click += (s, e) => prompt.Close();

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);

                prompt.ShowDialog(this);
            }
        }

        private void BtnQuest1_Click(object sender, EventArgs e)
        {
            HudMessageBox.Show(
                "GRIDLOCK: ALIEN SIEGE selected.",
                "SIDE QUEST",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private void BtnQuest2_Click(object sender, EventArgs e)
        {
            HudMessageBox.Show(
                "WEAPON TRIANGLE: XENO CLASH selected.",
                "SIDE QUEST",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        private void BtnQuest3_Click(object sender, EventArgs e)
        {
            HudMessageBox.Show(
                "RECENT BATTLE LOGS selected.",
                "SIDE QUEST",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Info,
                this
            );
        }

        // =========================
        // LOGOUT  ✅ NO CONFIRMATION NOW
        // =========================
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Close(); // immediate logout, no Yes/No prompt
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            DashboardFormStyler.PaintGradientBackground(this, e);
        }
    }
}
