// LeaderboardsForm.Designer.cs
namespace SpaceInvaders
{
    partial class LeaderboardsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabXP = new System.Windows.Forms.Button();
            this.btnTabSQ1 = new System.Windows.Forms.Button();
            this.btnTabSQ2 = new System.Windows.Forms.Button();
            this.btnTabSQ3 = new System.Windows.Forms.Button();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvLeaderboard = new System.Windows.Forms.DataGridView();
            this.pnlTop3 = new System.Windows.Forms.Panel();
            this.lblTop3Header = new System.Windows.Forms.Label();
            this.pnlTop1 = new System.Windows.Forms.Panel();
            this.lblTop1Rank = new System.Windows.Forms.Label();
            this.lblTop1Name = new System.Windows.Forms.Label();
            this.lblTop1Score = new System.Windows.Forms.Label();
            this.pnlTop2 = new System.Windows.Forms.Panel();
            this.lblTop2Rank = new System.Windows.Forms.Label();
            this.lblTop2Name = new System.Windows.Forms.Label();
            this.lblTop2Score = new System.Windows.Forms.Label();
            this.pnlTop3Slot = new System.Windows.Forms.Panel();
            this.lblTop3Rank = new System.Windows.Forms.Label();
            this.lblTop3Name = new System.Windows.Forms.Label();
            this.lblTop3Score = new System.Windows.Forms.Label();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScope = new System.Windows.Forms.Label();
            this.cmbScope = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblLastSync = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).BeginInit();
            this.pnlTop3.SuspendLayout();
            this.pnlTop1.SuspendLayout();
            this.pnlTop2.SuspendLayout();
            this.pnlTop3Slot.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.Controls.Add(this.pnlFooter);
            this.pnlCard.Controls.Add(this.pnlMain);
            this.pnlCard.Controls.Add(this.pnlTabs);
            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Location = new System.Drawing.Point(30, 30);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1200, 700);
            this.pnlCard.TabIndex = 0;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Height = 80;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(18, 10);
            this.lblTitle.Size = new System.Drawing.Size(520, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "LEADERBOARDS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitle.Size = new System.Drawing.Size(720, 25);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "RANKING DATABASE // PROJECT XTREME";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // btnBack
            // 
            this.btnBack.Name = "btnBack";
            this.btnBack.Text = "RETURN";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.Location = new System.Drawing.Point(1020, 20);
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // 
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Size = new System.Drawing.Size(120, 34);
            this.btnRefresh.Location = new System.Drawing.Point(890, 20);
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabs.Controls.Add(this.btnTabSQ3);
            this.pnlTabs.Controls.Add(this.btnTabSQ2);
            this.pnlTabs.Controls.Add(this.btnTabSQ1);
            this.pnlTabs.Controls.Add(this.btnTabXP);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Height = 62;

            // 
            // btnTabXP
            // 
            this.btnTabXP.Name = "btnTabXP";
            this.btnTabXP.Text = "XP RANKING";
            this.btnTabXP.Size = new System.Drawing.Size(220, 44);
            this.btnTabXP.Location = new System.Drawing.Point(18, 9);

            // 
            // btnTabSQ1
            // 
            this.btnTabSQ1.Name = "btnTabSQ1";
            this.btnTabSQ1.Text = "SIDE QUEST 1";
            this.btnTabSQ1.Size = new System.Drawing.Size(220, 44);
            this.btnTabSQ1.Location = new System.Drawing.Point(248, 9);

            // 
            // btnTabSQ2
            // 
            this.btnTabSQ2.Name = "btnTabSQ2";
            this.btnTabSQ2.Text = "SIDE QUEST 2";
            this.btnTabSQ2.Size = new System.Drawing.Size(220, 44);
            this.btnTabSQ2.Location = new System.Drawing.Point(478, 9);

            // 
            // btnTabSQ3
            // 
            this.btnTabSQ3.Name = "btnTabSQ3";
            this.btnTabSQ3.Text = "SIDE QUEST 3";
            this.btnTabSQ3.Size = new System.Drawing.Size(220, 44);
            this.btnTabSQ3.Location = new System.Drawing.Point(708, 9);

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlTop3);
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Name = "pnlMain";

            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.dgvLeaderboard);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(14);

            // 
            // dgvLeaderboard
            // 
            this.dgvLeaderboard.AllowUserToAddRows = false;
            this.dgvLeaderboard.AllowUserToDeleteRows = false;
            this.dgvLeaderboard.AllowUserToResizeRows = false;
            this.dgvLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaderboard.Name = "dgvLeaderboard";
            this.dgvLeaderboard.ReadOnly = true;
            this.dgvLeaderboard.RowHeadersVisible = false;

            // 
            // pnlTop3
            // 
            this.pnlTop3.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop3.Controls.Add(this.pnlTop3Slot);
            this.pnlTop3.Controls.Add(this.pnlTop2);
            this.pnlTop3.Controls.Add(this.pnlTop1);
            this.pnlTop3.Controls.Add(this.lblTop3Header);
            this.pnlTop3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTop3.Name = "pnlTop3";
            this.pnlTop3.Width = 320;
            this.pnlTop3.Padding = new System.Windows.Forms.Padding(14);

            // 
            // lblTop3Header
            // 
            this.lblTop3Header.AutoSize = false;
            this.lblTop3Header.Name = "lblTop3Header";
            this.lblTop3Header.Text = "TOP 3 PODIUM";
            this.lblTop3Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop3Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop3Header.Height = 40;

            // 
            // pnlTop1
            // 
            this.pnlTop1.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop1.Controls.Add(this.lblTop1Score);
            this.pnlTop1.Controls.Add(this.lblTop1Name);
            this.pnlTop1.Controls.Add(this.lblTop1Rank);
            this.pnlTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop1.Height = 150;
            this.pnlTop1.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);

            this.lblTop1Rank.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop1Rank.Height = 32;
            this.lblTop1Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop1Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop1Name.Height = 52;
            this.lblTop1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop1Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTop1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlTop2
            // 
            this.pnlTop2.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop2.Controls.Add(this.lblTop2Score);
            this.pnlTop2.Controls.Add(this.lblTop2Name);
            this.pnlTop2.Controls.Add(this.lblTop2Rank);
            this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop2.Height = 140;

            this.lblTop2Rank.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop2Rank.Height = 32;
            this.lblTop2Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop2Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop2Name.Height = 50;
            this.lblTop2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop2Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTop2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlTop3Slot
            // 
            this.pnlTop3Slot.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop3Slot.Controls.Add(this.lblTop3Score);
            this.pnlTop3Slot.Controls.Add(this.lblTop3Name);
            this.pnlTop3Slot.Controls.Add(this.lblTop3Rank);
            this.pnlTop3Slot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop3Slot.Height = 140;

            this.lblTop3Rank.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop3Rank.Height = 32;
            this.lblTop3Rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop3Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop3Name.Height = 50;
            this.lblTop3Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTop3Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTop3Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.lblLastSync);
            this.pnlFooter.Controls.Add(this.lblCount);
            this.pnlFooter.Controls.Add(this.txtSearch);
            this.pnlFooter.Controls.Add(this.lblSearch);
            this.pnlFooter.Controls.Add(this.cmbScope);
            this.pnlFooter.Controls.Add(this.lblScope);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Height = 52;
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(12);

            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Location = new System.Drawing.Point(16, 16);
            this.lblScope.Name = "lblScope";
            this.lblScope.Text = "Scope:";

            // 
            // cmbScope
            // 
            this.cmbScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScope.Location = new System.Drawing.Point(72, 12);
            this.cmbScope.Width = 140;
            this.cmbScope.Name = "cmbScope";

            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(230, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(295, 12);
            this.txtSearch.Width = 220;
            this.txtSearch.Name = "txtSearch";

            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(540, 16);
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "TOTAL CADETS: 0";

            // 
            // lblLastSync
            // 
            this.lblLastSync.AutoSize = true;
            this.lblLastSync.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLastSync.Location = new System.Drawing.Point(980, 16);
            this.lblLastSync.Name = "lblLastSync";
            this.lblLastSync.Text = "Last Sync: --:--";

            // 
            // LeaderboardsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.Name = "LeaderboardsForm";
            this.Text = "Leaderboards";

            this.pnlCard.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).EndInit();
            this.pnlTop3.ResumeLayout(false);
            this.pnlTop1.ResumeLayout(false);
            this.pnlTop2.ResumeLayout(false);
            this.pnlTop3Slot.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabXP;
        private System.Windows.Forms.Button btnTabSQ1;
        private System.Windows.Forms.Button btnTabSQ2;
        private System.Windows.Forms.Button btnTabSQ3;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvLeaderboard;
        private System.Windows.Forms.Panel pnlTop3;
        private System.Windows.Forms.Label lblTop3Header;

        private System.Windows.Forms.Panel pnlTop1;
        private System.Windows.Forms.Label lblTop1Rank;
        private System.Windows.Forms.Label lblTop1Name;
        private System.Windows.Forms.Label lblTop1Score;

        private System.Windows.Forms.Panel pnlTop2;
        private System.Windows.Forms.Label lblTop2Rank;
        private System.Windows.Forms.Label lblTop2Name;
        private System.Windows.Forms.Label lblTop2Score;

        private System.Windows.Forms.Panel pnlTop3Slot;
        private System.Windows.Forms.Label lblTop3Rank;
        private System.Windows.Forms.Label lblTop3Name;
        private System.Windows.Forms.Label lblTop3Score;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.ComboBox cmbScope;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblLastSync;
    }
}
