using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public static class DashboardFormStyler
    {
        public static void SetupStaticUI(
            Panel pnlCard,
            Panel pnlProfile,
            Panel pnlMission,
            Panel pnlSideTop,
            Panel pnlSideBottom,
            Panel pnlStatus,
            Panel pnlLogs,
            Panel pnlQuestStrip,
            Panel pnlTime,
            Label lblQuestStripTitle,
            Label lblTimeHeader,
            Label lblTimeValue,
            Label lblHudTitle,
            Label lblWelcome,
            Label lblSub,
            Label lblRank,
            Label lblXP,
            Button btnLogout,
            Button btnDeploy,
            Button btnMIA,
            Button btnQuest1,
            Button btnQuest2,
            Button btnQuest3,
            PictureBox picAvatar)
        {
            pnlCard.BackColor = ColorTranslator.FromHtml("#07161C");
            pnlCard.Paint -= DrawHudCard;
            pnlCard.Paint += DrawHudCard;

            StyleHudPanel(pnlProfile);
            StyleHudPanel(pnlMission);
            StyleHudPanel(pnlSideTop);
            StyleHudPanel(pnlSideBottom);
            StyleHudPanel(pnlStatus);
            StyleHudPanel(pnlLogs);
            StyleHudPanel(pnlQuestStrip);
            StyleHudPanel(pnlTime);

            lblQuestStripTitle.ForeColor = Color.White;
            lblQuestStripTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            lblTimeHeader.Text = "";
            lblTimeHeader.Visible = false;

            lblTimeValue.ForeColor = ColorTranslator.FromHtml("#4FFFEA");
            lblTimeValue.Font = new Font("Consolas", 32F, FontStyle.Bold);
            lblTimeValue.TextAlign = ContentAlignment.MiddleCenter;

            lblHudTitle.ForeColor = ColorTranslator.FromHtml("#4FFFEA");
            lblHudTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);

            lblWelcome.ForeColor = Color.White;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);

            lblSub.Text = "";
            lblSub.Visible = false;

            lblRank.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            lblRank.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            lblXP.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            lblXP.Font = new Font("Segoe UI", 11F);

            // ✅ hide plain XP to avoid redundancy (do not delete)
            lblXP.Visible = false;

            StylePrimaryButton(btnDeploy);
            StylePrimaryButton(btnMIA);

            StyleFooterButton(btnLogout);
            btnLogout.Text = "LOGOUT";
            btnLogout.Visible = true;
            btnLogout.Enabled = true;

            StyleFileButton(btnQuest1);
            StyleFileButton(btnQuest2);
            StyleFileButton(btnQuest3);

            if (picAvatar != null)
            {
                picAvatar.Paint -= DrawAvatarBorder;
                picAvatar.Paint += DrawAvatarBorder;
            }
        }

        public static Panel ApplyRuntimeLayout(
            Form form,
            Panel pnlCard,
            Panel shadow,
            Panel pnlProfile,
            Panel pnlMission,
            Panel pnlSideTop,
            Panel pnlSideBottom,
            Panel pnlStatus,
            Panel pnlLogs,
            Panel pnlQuestStrip,
            Panel pnlTime,
            Label lblHudTitle,
            Button btnLogout)
        {
            int outerMargin = Scale(form, 18, 32);
            pnlCard.Width = form.ClientSize.Width - outerMargin * 2;
            pnlCard.Height = form.ClientSize.Height - outerMargin * 2;

            if (pnlCard.Width < 1100) pnlCard.Width = 1100;
            if (pnlCard.Height < 640) pnlCard.Height = 640;

            pnlCard.Left = (form.ClientSize.Width - pnlCard.Width) / 2;
            pnlCard.Top = (form.ClientSize.Height - pnlCard.Height) / 2;

            ApplyRoundedCorners(pnlCard);

            shadow = EnsureShadow(form, pnlCard, shadow);
            UpdateShadow(pnlCard, shadow);

            int pad = Scale(form, 22, 40);
            int topBar = Scale(form, 70, 95);
            int colGap = Scale(form, 8, 12);

            int usableW = pnlCard.Width - pad * 2;

            int colProfile = (int)(usableW * 0.26);
            int colMission = (int)(usableW * 0.27);
            int colSide = (int)(usableW * 0.27);

            int minProfile = 280;
            int minMission = 300;
            int minSide = 300;
            int minRight = 260;

            if (colProfile < minProfile) colProfile = minProfile;
            if (colMission < minMission) colMission = minMission;
            if (colSide < minSide) colSide = minSide;

            int colRight = usableW - colProfile - colMission - colSide - colGap * 3;

            if (colRight < minRight)
            {
                int need = minRight - colRight;

                int totalStealable = (colMission - minMission) + (colSide - minSide);
                if (totalStealable > 0)
                {
                    int stealMission = (int)(need * ((colMission - minMission) / (float)totalStealable));
                    int stealSide = need - stealMission;

                    colMission -= stealMission;
                    colSide -= stealSide;
                }

                colRight = usableW - colProfile - colMission - colSide - colGap * 3;
                if (colRight < minRight) colRight = minRight;
            }

            int xProfile = pad;
            int xMission = xProfile + colProfile + colGap;
            int xSide = xMission + colMission + colGap;
            int xRight = xSide + colSide + colGap;

            int questStripH = Scale(form, 176, 210);
            int questStripGap = colGap;

            int timePanelH = Scale(form, 95, 120);
            int logoutPanelH = questStripH - timePanelH - colGap;
            if (logoutPanelH < 60) logoutPanelH = 60;

            int contentBottomLimit = pnlCard.Height - questStripH - questStripGap - pad;
            int contentH = contentBottomLimit - topBar;
            if (contentH < 360) contentH = 360;

            pnlProfile.Location = new Point(xProfile, topBar);
            pnlProfile.Size = new Size(colProfile, contentH);

            int midTop = topBar + Scale(form, 40, 60);
            int midHeight = contentH - (midTop - topBar);

            pnlMission.Location = new Point(xMission, midTop);
            pnlMission.Size = new Size(colMission, midHeight);

            int splitGap = colGap;
            int topPanelH = (int)(midHeight * 0.45);
            if (topPanelH < 160) topPanelH = 160;

            pnlSideTop.Location = new Point(xSide, midTop);
            pnlSideTop.Size = new Size(colSide, topPanelH);

            pnlSideBottom.Location = new Point(xSide, pnlSideTop.Bottom + splitGap);
            pnlSideBottom.Size = new Size(colSide, midHeight - topPanelH - splitGap);

            int statusH = (int)(contentH * 0.34);
            if (statusH < 220) statusH = 220;

            pnlStatus.Location = new Point(xRight, topBar);
            pnlStatus.Size = new Size(colRight, statusH);

            pnlLogs.Location = new Point(xRight, pnlStatus.Bottom + colGap);
            pnlLogs.Size = new Size(colRight, contentH - statusH - colGap);

            int stripY = contentBottomLimit + questStripGap;

            pnlQuestStrip.Location = new Point(xProfile, stripY);
            pnlQuestStrip.Size = new Size(colProfile + colMission + colSide + colGap * 2, questStripH);
            LayoutFileTilesInsideStrip(pnlQuestStrip);

            pnlTime.Location = new Point(xRight, stripY);
            pnlTime.Size = new Size(colRight, timePanelH);

            btnLogout.Visible = true;
            btnLogout.Enabled = true;
            btnLogout.Location = new Point(xRight, pnlTime.Bottom + colGap);
            btnLogout.Size = new Size(colRight, logoutPanelH);

            lblHudTitle.Left = (pnlCard.Width - lblHudTitle.Width) / 2;
            lblHudTitle.Top = Scale(form, 8, 12);

            return shadow;
        }

        // ✅ Profile layout includes XP progress block, no plain XP line
        public static void LayoutProfileChildren(
            Panel pnlProfile,
            PictureBox picAvatar,
            Label lblWelcome,
            Label lblRank,
            Label lblXpNextTitle,
            ProgressBar pbXpNext,
            Label lblXpNextValue)
        {
            if (pnlProfile == null) return;

            int pad = 18;
            int w = pnlProfile.Width - pad * 2;
            int y = pad + 8;

            if (picAvatar != null)
            {
                int avatarSize = (int)(w * 0.88);
                if (avatarSize > 260) avatarSize = 260;
                if (avatarSize < 150) avatarSize = 150;

                picAvatar.Size = new Size(avatarSize, avatarSize);
                picAvatar.Location = new Point((pnlProfile.Width - avatarSize) / 2, y);

                y = picAvatar.Bottom + 18;
            }

            if (lblWelcome != null)
            {
                lblWelcome.AutoSize = true;
                lblWelcome.Location = new Point(pad, y);
                y = lblWelcome.Bottom + 8;
            }

            if (lblRank != null)
            {
                lblRank.AutoSize = true;
                lblRank.Location = new Point(pad, y);
                y = lblRank.Bottom + 22;
            }

            if (lblXpNextTitle != null)
            {
                lblXpNextTitle.AutoSize = true;
                lblXpNextTitle.Location = new Point(pad, y);
                y = lblXpNextTitle.Bottom + 8;
            }

            if (pbXpNext != null)
            {
                pbXpNext.Width = w;
                pbXpNext.Height = 22;
                pbXpNext.Location = new Point(pad, y);
                y = pbXpNext.Bottom + 8;
            }

            if (lblXpNextValue != null)
            {
                lblXpNextValue.AutoSize = true;
                lblXpNextValue.Location = new Point(pad, y);
            }
        }

        // ✅ Mission countdown deadspace layout
        public static void LayoutMissionCountdown(
            Panel pnlMission,
            Label lblMissionHeader,
            Label lblMissionCountdown)
        {
            if (pnlMission == null || lblMissionCountdown == null) return;

            int pad = 18;
            int headerBottom = (lblMissionHeader != null)
                ? lblMissionHeader.Bottom + 14
                : pad;

            lblMissionCountdown.AutoSize = false;
            lblMissionCountdown.Location = new Point(pad, headerBottom);
            lblMissionCountdown.Size = new Size(
                pnlMission.Width - pad * 2,
                pnlMission.Height / 2
            );
            lblMissionCountdown.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void LayoutLogsChildren(
            Panel pnlLogs,
            Label lblLogsHeader,
            PictureBox pbAdminLogo)
        {
            if (pnlLogs == null) return;

            int pad = 18;
            int y = pad;

            if (lblLogsHeader != null)
            {
                lblLogsHeader.AutoSize = true;
                lblLogsHeader.Location = new Point(pad, y);
                y = lblLogsHeader.Bottom + 18;
            }

            if (pbAdminLogo != null)
            {
                int size = (int)(pnlLogs.Width * 0.62);
                if (size > 220) size = 220;
                if (size < 120) size = 120;

                pbAdminLogo.Size = new Size(size, size);
                pbAdminLogo.Location = new Point((pnlLogs.Width - size) / 2, y);
            }
        }

        public static void LayoutStatusChildren(
            Panel pnlStatus,
            Label lblStatusHeader,
            ProgressBar pbStatusArc,
            Label lblCritical)
        {
            if (pnlStatus == null) return;

            int pad = 18;
            int width = pnlStatus.Width - pad * 2;
            int y = pad;

            if (lblStatusHeader != null)
            {
                lblStatusHeader.AutoSize = true;
                lblStatusHeader.Location = new Point(pad, y);
                y = lblStatusHeader.Bottom + 14;
            }

            if (pbStatusArc != null)
            {
                pbStatusArc.Width = width;
                pbStatusArc.Height = 26;
                pbStatusArc.Location = new Point(pad, y);
                y = pbStatusArc.Bottom + 18;
            }

            if (lblCritical != null)
            {
                lblCritical.AutoSize = true;
                lblCritical.TextAlign = ContentAlignment.MiddleCenter;

                int cx = (pnlStatus.Width - lblCritical.Width) / 2;
                if (cx < pad) cx = pad;

                lblCritical.Location = new Point(cx, y);

                if (lblCritical.Bottom > pnlStatus.Height - pad)
                    lblCritical.Top = pnlStatus.Height - pad - lblCritical.Height;
            }
        }

        public static void PaintGradientBackground(Form form, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, form.Width, form.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(6, 10, 25),
                Color.FromArgb(35, 12, 60),
                45f))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        public static void SetCriticalStatusState(Label lbl, bool deployed)
        {
            if (lbl == null) return;

            lbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl.AutoSize = true;

            if (deployed)
                lbl.ForeColor = ColorTranslator.FromHtml("#4FFFEA");
            else
                lbl.ForeColor = ColorTranslator.FromHtml("#F5B942");
        }

        public static void StyleAchievementSlot(Panel slot)
        {
            if (slot == null) return;
            slot.BackColor = Color.Transparent;
            slot.Padding = new Padding(2);
        }

        public static void SetAchievementHover(Panel slot, bool hover)
        {
            if (slot == null) return;
            slot.BackColor = hover
                ? Color.FromArgb(40, 79, 255, 234)
                : Color.Transparent;
        }

        public static void StyleAchievementIcon(PictureBox pic)
        {
            if (pic == null) return;
            pic.Paint -= DrawAchievementFrame;
            pic.Paint += DrawAchievementFrame;
        }

        public static void StyleAchievementTitle(Label lbl)
        {
            if (lbl == null) return;
            lbl.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.Transparent;
        }

        public static void StyleAchievementLockLabel(Label lbl)
        {
            if (lbl == null) return;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(220, 255, 90, 90);
            lbl.BackColor = Color.FromArgb(160, 0, 0, 0);
            lbl.Text = "LOCKED";
            lbl.Visible = false;
        }

        public static void ApplyAchievementState(PictureBox pic, Label title, Label lockLbl, bool unlocked)
        {
            if (pic == null || title == null || lockLbl == null) return;

            if (unlocked)
            {
                pic.Image = GetDefaultBadgeIcon();
                title.ForeColor = Color.White;
                lockLbl.Visible = false;
                pic.Enabled = true;
            }
            else
            {
                pic.Image = GetLockedBadgeIcon();
                title.ForeColor = Color.Gray;
                lockLbl.Visible = true;
                pic.Enabled = false;
            }
        }

        public static void StyleAchievementNavButton(Button b)
        {
            if (b == null) return;

            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = Color.FromArgb(3, 26, 34);
            b.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            b.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
        }

        public static void StyleAchievementPageLabel(Label lbl)
        {
            if (lbl == null) return;

            lbl.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbl.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            lbl.BackColor = Color.Transparent;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void StyleAchievementPopup(Form pop, Label lblTitle, Label lblDesc, Button btnOk)
        {
            pop.BackColor = Color.FromArgb(3, 12, 18);
            pop.ForeColor = Color.White;
            pop.Text = "ACHIEVEMENT DATA";

            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = ColorTranslator.FromHtml("#4FFFEA");
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(16, 12);
            lblTitle.Size = new Size(pop.Width - 32, 32);

            lblDesc.AutoSize = false;
            lblDesc.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblDesc.ForeColor = Color.White;
            lblDesc.TextAlign = ContentAlignment.MiddleCenter;
            lblDesc.Location = new Point(24, 52);
            lblDesc.Size = new Size(pop.Width - 48, 110);

            btnOk.Text = "CONFIRM";
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.BackColor = ColorTranslator.FromHtml("#031A22");
            btnOk.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            btnOk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnOk.FlatAppearance.BorderSize = 1;
            btnOk.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
            btnOk.Size = new Size(120, 32);
            btnOk.Location = new Point((pop.Width - btnOk.Width) / 2, pop.Height - 70);
        }

        private static void DrawAchievementFrame(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rOuter = new Rectangle(0, 0, pic.Width - 1, pic.Height - 1);
            Rectangle rInner = new Rectangle(3, 3, pic.Width - 7, pic.Height - 7);

            Color neon = ColorTranslator.FromHtml("#4FFFEA");

            using (Pen pOuter = new Pen(neon, 2))
                e.Graphics.DrawRectangle(pOuter, rOuter);

            using (Pen pInner = new Pen(Color.FromArgb(100, neon), 1))
                e.Graphics.DrawRectangle(pInner, rInner);

            Point[] notch =
            {
                new Point(0,0),
                new Point(18,0),
                new Point(0,18)
            };

            using (SolidBrush b = new SolidBrush(Color.FromArgb(35, neon)))
                e.Graphics.FillPolygon(b, notch);

            using (Pen pn = new Pen(neon, 1))
                e.Graphics.DrawPolygon(pn, notch);
        }

        public static Image GetDefaultBadgeIcon()
        {
            Bitmap bmp = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen p = new Pen(ColorTranslator.FromHtml("#4FFFEA"), 3))
                    g.DrawEllipse(p, 8, 8, 48, 48);
                using (Brush b = new SolidBrush(Color.FromArgb(35, 79, 255, 234)))
                    g.FillEllipse(b, 8, 8, 48, 48);
            }
            return bmp;
        }

        public static Image GetLockedBadgeIcon()
        {
            Bitmap bmp = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen p = new Pen(Color.Gray, 3))
                    g.DrawEllipse(p, 8, 8, 48, 48);
                using (Brush b = new SolidBrush(Color.FromArgb(30, 120, 120, 120)))
                    g.FillEllipse(b, 8, 8, 48, 48);
                using (Pen px = new Pen(Color.Gray, 4))
                {
                    g.DrawLine(px, 20, 20, 44, 44);
                    g.DrawLine(px, 44, 20, 20, 44);
                }
            }
            return bmp;
        }

        public static void StyleLeaderboardsViewButton(Button b)
        {
            if (b == null) return;

            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = Color.FromArgb(3, 26, 34);
            b.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
            b.Text = "VIEW";
        }

        public static void StyleLeaderboardNameLabel(Label lbl)
        {
            if (lbl == null) return;

            lbl.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.FromArgb(4, 18, 24);
            lbl.Padding = new Padding(6);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void DrawLeaderboardNameBorder(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rOuter = new Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1);
            Rectangle rInner = new Rectangle(3, 3, lbl.Width - 7, lbl.Height - 7);

            Color neon = ColorTranslator.FromHtml("#4FFFEA");

            using (Pen pOuter = new Pen(neon, 2))
                e.Graphics.DrawRectangle(pOuter, rOuter);

            using (Pen pInner = new Pen(Color.FromArgb(120, neon), 1))
                e.Graphics.DrawRectangle(pInner, rInner);

            Point[] notch =
            {
                new Point(0,0),
                new Point(22,0),
                new Point(0,22)
            };

            using (SolidBrush b = new SolidBrush(Color.FromArgb(30, neon)))
                e.Graphics.FillPolygon(b, notch);

            using (Pen pn = new Pen(neon, 1))
                e.Graphics.DrawPolygon(pn, notch);
        }

        public static void SetLeaveBattlefieldVisualState(Button btnLeave, Button btnDeployOrNull)
        {
            if (btnLeave == null) return;

            if (btnDeployOrNull == null)
            {
                btnLeave.BackColor = Color.FromArgb(40, 40, 40);
                btnLeave.ForeColor = Color.Gray;
            }
            else
            {
                btnLeave.BackColor = btnDeployOrNull.BackColor;
                btnLeave.ForeColor = btnDeployOrNull.ForeColor;
            }
        }

        public static void StyleAdminPromptButtons(Button confirm, Button cancel)
        {
            if (confirm != null)
            {
                confirm.BackColor = Color.Cyan;
                confirm.ForeColor = Color.Black;
                confirm.FlatStyle = FlatStyle.Flat;
                confirm.FlatAppearance.BorderSize = 0;
            }

            if (cancel != null)
            {
                cancel.BackColor = Color.FromArgb(40, 40, 40);
                cancel.ForeColor = Color.White;
                cancel.FlatStyle = FlatStyle.Flat;
                cancel.FlatAppearance.BorderSize = 0;
            }
        }

        private static void StyleHudPanel(Panel p)
        {
            if (p == null) return;
            p.BackColor = ColorTranslator.FromHtml("#031A22");
            p.Padding = new Padding(18);
            p.Paint -= DrawNeonBorder;
            p.Paint += DrawNeonBorder;
        }

        private static void StylePrimaryButton(Button b)
        {
            if (b == null) return;
            b.BackColor = ColorTranslator.FromHtml("#031A22");
            b.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
            b.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        private static void StyleFooterButton(Button b)
        {
            if (b == null) return;
            b.BackColor = ColorTranslator.FromHtml("#4FFFEA");
            b.ForeColor = ColorTranslator.FromHtml("#07161C");
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        private static void StyleFileButton(Button b)
        {
            if (b == null) return;
            b.BackColor = ColorTranslator.FromHtml("#061E26");
            b.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
            b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Cursor = Cursors.Hand;

            b.Paint -= DrawFileButtonNotch;
            b.Paint += DrawFileButtonNotch;
        }

        private static void DrawFileButtonNotch(object sender, PaintEventArgs e)
        {
            Button b = sender as Button;
            if (b == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Point[] notch =
            {
                new Point(0,0),
                new Point(30,0),
                new Point(0,30)
            };

            using (SolidBrush br = new SolidBrush(ColorTranslator.FromHtml("#0C3B44")))
                e.Graphics.FillPolygon(br, notch);
            using (Pen pn = new Pen(ColorTranslator.FromHtml("#4FFFEA"), 1))
                e.Graphics.DrawPolygon(pn, notch);
        }

        private static void DrawHudCard(object sender, PaintEventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle outer = new Rectangle(1, 1, card.Width - 3, card.Height - 3);
            Rectangle inner = new Rectangle(8, 8, card.Width - 16, card.Height - 16);

            using (LinearGradientBrush depth = new LinearGradientBrush(
                inner,
                Color.FromArgb(255, 8, 26, 34),
                Color.FromArgb(255, 4, 18, 24),
                45f))
            {
                e.Graphics.FillRectangle(depth, inner);
            }

            using (Pen ring = new Pen(Color.FromArgb(140, 79, 255, 234), 2))
                e.Graphics.DrawRectangle(ring, outer);
        }

        private static void DrawNeonBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;
            using (Pen pen = new Pen(ColorTranslator.FromHtml("#4FFFEA"), 1))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        private static void LayoutFileTilesInsideStrip(Panel strip)
        {
            Button b1 = null, b2 = null, b3 = null;
            Label title = null;

            foreach (Control c in strip.Controls)
            {
                if (c is Button btn)
                {
                    if (b1 == null) b1 = btn;
                    else if (b2 == null) b2 = btn;
                    else if (b3 == null) b3 = btn;
                }
                else if (c is Label lbl)
                {
                    title = lbl;
                }
            }

            if (title != null)
            {
                title.Left = 18;
                title.Top = 10;
            }

            int innerPad = 18;
            int gap = 12;
            int top = (title != null) ? title.Bottom + 8 : 26;

            int usableW = strip.Width - innerPad * 2;
            int btnW = (usableW - gap * 2) / 3;
            int btnH = strip.Height - top - 12;
            if (btnH < 50) btnH = 50;

            if (b1 != null)
            {
                b1.Size = new Size(btnW, btnH);
                b1.Location = new Point(innerPad, top);
            }

            if (b2 != null)
            {
                b2.Size = new Size(btnW, btnH);
                b2.Location = new Point(innerPad + btnW + gap, top);
            }

            if (b3 != null)
            {
                b3.Size = new Size(btnW, btnH);
                b3.Location = new Point(innerPad + (btnW + gap) * 2, top);
            }
        }

        private static int Scale(Form form, int min, int max)
        {
            float t = (form.ClientSize.Width - 1100f) / 800f;
            if (t < 0) t = 0;
            if (t > 1) t = 1;
            return (int)(min + (max - min) * t);
        }

        private static void ApplyRoundedCorners(Control c)
        {
            int radius = 22;
            Rectangle r = new Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddArc(r.Left, r.Top, radius, radius, 180, 90);
                gp.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
                gp.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                gp.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
                gp.CloseFigure();
                c.Region = new Region(gp);
            }
        }

        private static Panel EnsureShadow(Form form, Panel card, Panel shadow)
        {
            if (shadow != null && form.Controls.Contains(shadow))
                return shadow;

            shadow = new Panel();
            shadow.BackColor = Color.FromArgb(60, 0, 0, 0);
            shadow.Location = new Point(card.Left + 6, card.Top + 6);
            shadow.Size = card.Size;
            shadow.SendToBack();
            form.Controls.Add(shadow);
            card.BringToFront();
            return shadow;
        }

        private static void UpdateShadow(Panel card, Panel shadow)
        {
            if (shadow == null) return;
            shadow.Location = new Point(card.Left + 6, card.Top + 6);
            shadow.Size = card.Size;
        }

        private static void DrawAvatarBorder(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rOuter = new Rectangle(0, 0, pic.Width - 1, pic.Height - 1);
            Rectangle rInner = new Rectangle(3, 3, pic.Width - 7, pic.Height - 7);

            Color neon = ColorTranslator.FromHtml("#4FFFEA");

            using (Pen pOuter = new Pen(neon, 2))
                e.Graphics.DrawRectangle(pOuter, rOuter);

            using (Pen pInner = new Pen(Color.FromArgb(100, neon), 1))
                e.Graphics.DrawRectangle(pInner, rInner);
        }
    }
}
