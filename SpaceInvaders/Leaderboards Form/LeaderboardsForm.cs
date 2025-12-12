// LeaderboardsForm.cs  (C# 7.3 compatible)
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SpaceInvaders.Data; // centralized DB folder (DbHelper/DbConnectionFactory/DbConfig)

namespace SpaceInvaders
{
    public partial class LeaderboardsForm : Form
    {
        private Panel shadow;
        private readonly string currentUserId;

        private enum RankType { XP, SQ1, SQ2, SQ3 }
        private RankType activeType = RankType.XP;

        private DataTable currentTable;

        // REMOVED redundant connStr param + local MySql usage
        public LeaderboardsForm(string userId)
        {
            InitializeComponent();

            currentUserId = userId;

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            KeyPreview = true;

            Load += LeaderboardsForm_Load;
            Resize += LeaderboardsForm_Resize;
            KeyDown += LeaderboardsForm_KeyDown;

            btnBack.Click += (s, e) => Close();
            btnRefresh.Click += (s, e) => ReloadActiveLeaderboard();

            btnTabXP.Click += (s, e) => SwitchType(RankType.XP);
            btnTabSQ1.Click += (s, e) => SwitchType(RankType.SQ1);
            btnTabSQ2.Click += (s, e) => SwitchType(RankType.SQ2);
            btnTabSQ3.Click += (s, e) => SwitchType(RankType.SQ3);

            cmbScope.SelectedIndexChanged += (s, e) => ReloadActiveLeaderboard();
            txtSearch.TextChanged += (s, e) => ApplySearchFilter();
        }

        private void LeaderboardsForm_Load(object sender, EventArgs e)
        {
            LeaderboardsFormStyler.SetupStaticUI(
                pnlCard, pnlHeader, pnlTabs, pnlGrid, pnlTop3, pnlFooter,
                lblTitle, lblSubtitle, lblTop3Header,
                btnBack, btnRefresh,
                btnTabXP, btnTabSQ1, btnTabSQ2, btnTabSQ3,
                dgvLeaderboard,
                lblTop1Rank, lblTop1Name, lblTop1Score,
                lblTop2Rank, lblTop2Name, lblTop2Score,
                lblTop3Rank, lblTop3Name, lblTop3Score,
                lblScope, cmbScope, lblSearch, txtSearch, lblCount, lblLastSync
            );

            cmbScope.Items.Clear();
            cmbScope.Items.AddRange(new object[] { "All-Time", "This Month", "This Week" });
            cmbScope.SelectedIndex = 0;

            ApplyUI();
            ReloadActiveLeaderboard();
        }

        private void LeaderboardsForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = LeaderboardsFormStyler.ApplyRuntimeLayout(
                this, pnlCard, shadow, pnlHeader, pnlTabs, pnlMain, pnlFooter, pnlTop3
            );
        }

        private void SwitchType(RankType type)
        {
            activeType = type;
            LeaderboardsFormStyler.SetActiveTab(btnTabXP, btnTabSQ1, btnTabSQ2, btnTabSQ3, activeType);
            ReloadActiveLeaderboard();
        }

        private void ReloadActiveLeaderboard()
        {
            string scope = cmbScope.SelectedItem != null ? cmbScope.SelectedItem.ToString() : "All-Time";

            currentTable = LoadLeaderboardDataSafe(activeType, scope);
            dgvLeaderboard.DataSource = currentTable;

            ApplySearchFilter();
            UpdateTop3Panel();
            UpdateCountsAndSync();
        }

        private void ApplySearchFilter()
        {
            if (currentTable == null) return;

            string q = (txtSearch.Text ?? "").Trim().Replace("'", "''");
            DataView view = currentTable.DefaultView;

            if (string.IsNullOrWhiteSpace(q))
            {
                view.RowFilter = "";
            }
            else
            {
                view.RowFilter = "Name LIKE '%" + q + "%'";
            }

            dgvLeaderboard.DataSource = view.ToTable();
            lblCount.Text = "TOTAL CADETS: " + view.Count;
            UpdateTop3Panel();
        }

        private void UpdateCountsAndSync()
        {
            int count = 0;
            DataTable dt = dgvLeaderboard.DataSource as DataTable;
            if (dt != null)
                count = dt.Rows.Count;

            lblCount.Text = "TOTAL CADETS: " + count;
            lblLastSync.Text = "Last Sync: " + DateTime.Now.ToString("hh:mm tt");
        }

        private void UpdateTop3Panel()
        {
            var rows = new List<DataRow>();

            DataTable dt = dgvLeaderboard.DataSource as DataTable;
            if (dt != null)
                rows = dt.AsEnumerable().Take(3).ToList();

            SetTopSlot(rows, 0, lblTop1Rank, lblTop1Name, lblTop1Score);
            SetTopSlot(rows, 1, lblTop2Rank, lblTop2Name, lblTop2Score);
            SetTopSlot(rows, 2, lblTop3Rank, lblTop3Name, lblTop3Score);

            // C# 7.3 switch statement (no switch expression)
            switch (activeType)
            {
                case RankType.XP:
                    lblTop3Header.Text = "TOP 3 XP CADETS";
                    break;
                case RankType.SQ1:
                    lblTop3Header.Text = "TOP 3 SIDE QUEST 1";
                    break;
                case RankType.SQ2:
                    lblTop3Header.Text = "TOP 3 SIDE QUEST 2";
                    break;
                case RankType.SQ3:
                    lblTop3Header.Text = "TOP 3 SIDE QUEST 3";
                    break;
                default:
                    lblTop3Header.Text = "TOP 3 PODIUM";
                    break;
            }
        }

        private void SetTopSlot(List<DataRow> rows, int idx, Label rank, Label name, Label score)
        {
            if (idx >= rows.Count)
            {
                rank.Text = "#" + (idx + 1);
                name.Text = "---";
                score.Text = "---";
                return;
            }

            DataRow r = rows[idx];
            rank.Text = "#" + (idx + 1);
            name.Text = r["Name"] != null ? r["Name"].ToString() : "---";
            score.Text = r["Score"] != null ? r["Score"].ToString() : "---";
        }

        // Uses centralized DbHelper. No local connections / connStr.
        private DataTable LoadLeaderboardDataSafe(RankType type, string scope)
        {
            DataTable fallback = BuildMockTable(type);

            try
            {
                // C# 7.3 switch statement
                string scoreColumn;
                switch (type)
                {
                    case RankType.XP:
                        scoreColumn = "XP";
                        break;
                    case RankType.SQ1:
                        scoreColumn = "SideQuest1";
                        break;
                    case RankType.SQ2:
                        scoreColumn = "SideQuest2";
                        break;
                    case RankType.SQ3:
                        scoreColumn = "SideQuest3";
                        break;
                    default:
                        scoreColumn = "XP";
                        break;
                }

                // Scope filter placeholder (optional later)
                string whereScope = "";
                if (scope == "This Month")
                    whereScope = "";  // TODO: add date filter
                else if (scope == "This Week")
                    whereScope = "";  // TODO: add date filter

                string q =
                    "SELECT CONCAT(FirstName,' ',LastName) AS Name, " +
                    scoreColumn + " AS Score, RankTitle AS Title " +
                    "FROM student_info " +
                    whereScope + " " +
                    "ORDER BY Score DESC";

                DataTable dt = DbHelper.ExecuteQuery(q);

                if (dt == null || !dt.Columns.Contains("Name") || !dt.Columns.Contains("Score"))
                    return fallback;

                return dt;
            }
            catch
            {
                return fallback;
            }
        }

        private DataTable BuildMockTable(RankType type)
        {
            var dt = new DataTable();
            dt.Columns.Add("Rank", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Score", typeof(int));

            int baseScore;
            switch (type)
            {
                case RankType.XP:
                    baseScore = 1200;
                    break;
                case RankType.SQ1:
                    baseScore = 300;
                    break;
                case RankType.SQ2:
                    baseScore = 260;
                    break;
                case RankType.SQ3:
                    baseScore = 220;
                    break;
                default:
                    baseScore = 100;
                    break;
            }

            string[] names = { "Lt. Shadow", "Lt. Nova", "Lt. Orion", "Cadet Vega", "Cadet Helix", "Cadet Echo" };

            for (int i = 0; i < names.Length; i++)
            {
                dt.Rows.Add(i + 1, names[i], "Operative", baseScore - i * 35);
            }

            return dt;
        }

        private void LeaderboardsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            LeaderboardsFormStyler.PaintGradientBackground(this, e);
        }
    }
}
