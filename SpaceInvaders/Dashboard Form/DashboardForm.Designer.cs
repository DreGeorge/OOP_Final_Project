namespace SpaceInvaders
{
    partial class DashboardForm
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
            this.pbGifBackground = new System.Windows.Forms.PictureBox();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblHudTitle = new System.Windows.Forms.Label();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.lblXP = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlMission = new System.Windows.Forms.Panel();
            this.lblMissionHeader = new System.Windows.Forms.Label();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.btnMIA = new System.Windows.Forms.Button();
            this.pnlSideTopActions = new System.Windows.Forms.Panel();
            this.lblSideTopHeader = new System.Windows.Forms.Label();
            this.pnlSideBottomActions = new System.Windows.Forms.Panel();
            this.lblSideBottomHeader = new System.Windows.Forms.Label();
            this.pnlQuestStrip = new System.Windows.Forms.Panel();
            this.lblQuestStripTitle = new System.Windows.Forms.Label();
            this.btnQuest1 = new System.Windows.Forms.Button();
            this.btnQuest2 = new System.Windows.Forms.Button();
            this.btnQuest3 = new System.Windows.Forms.Button();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblTimeHeader = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.pbStatusArc = new System.Windows.Forms.ProgressBar();
            this.lblCritical = new System.Windows.Forms.Label();
            this.pnlLogs = new System.Windows.Forms.Panel();
            this.lblLogsHeader = new System.Windows.Forms.Label();
            this.pbAdminLogo = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlMission.SuspendLayout();
            this.pnlSideTopActions.SuspendLayout();
            this.pnlSideBottomActions.SuspendLayout();
            this.pnlQuestStrip.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdminLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGifBackground
            // 
            this.pbGifBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGifBackground.Location = new System.Drawing.Point(0, 0);
            this.pbGifBackground.Name = "pbGifBackground";
            this.pbGifBackground.Size = new System.Drawing.Size(1280, 720);
            this.pbGifBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGifBackground.TabIndex = 999;
            this.pbGifBackground.TabStop = false;
            this.pbGifBackground.Visible = false;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(22)))), ((int)(((byte)(28)))));
            this.pnlCard.Controls.Add(this.lblHudTitle);
            this.pnlCard.Controls.Add(this.pnlProfile);
            this.pnlCard.Controls.Add(this.pnlMission);
            this.pnlCard.Controls.Add(this.pnlSideTopActions);
            this.pnlCard.Controls.Add(this.pnlSideBottomActions);
            this.pnlCard.Controls.Add(this.pnlQuestStrip);
            this.pnlCard.Controls.Add(this.pnlTime);
            this.pnlCard.Controls.Add(this.pnlStatus);
            this.pnlCard.Controls.Add(this.pnlLogs);
            this.pnlCard.Controls.Add(this.btnLogout);
            this.pnlCard.Location = new System.Drawing.Point(53, 37);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1600, 812);
            this.pnlCard.TabIndex = 0;
            // 
            // lblHudTitle
            // 
            this.lblHudTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblHudTitle.ForeColor = System.Drawing.Color.White;
            this.lblHudTitle.Location = new System.Drawing.Point(0, 12);
            this.lblHudTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHudTitle.Name = "lblHudTitle";
            this.lblHudTitle.Size = new System.Drawing.Size(1600, 74);
            this.lblHudTitle.TabIndex = 0;
            this.lblHudTitle.Text = "PROJECT XTREME";
            this.lblHudTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProfile
            // 
            this.pnlProfile.Controls.Add(this.picAvatar);
            this.pnlProfile.Controls.Add(this.lblWelcome);
            this.pnlProfile.Controls.Add(this.lblRank);
            this.pnlProfile.Controls.Add(this.lblXP);
            this.pnlProfile.Controls.Add(this.lblSub);
            this.pnlProfile.Location = new System.Drawing.Point(53, 111);
            this.pnlProfile.Margin = new System.Windows.Forms.Padding(4);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(373, 640);
            this.pnlProfile.TabIndex = 1;
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(80, 25);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(213, 197);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(80, 246);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(158, 37);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Lt. Shadow";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRank.ForeColor = System.Drawing.Color.White;
            this.lblRank.Location = new System.Drawing.Point(80, 295);
            this.lblRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(127, 25);
            this.lblRank.TabIndex = 2;
            this.lblRank.Text = "LIEUTENANT";
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblXP.ForeColor = System.Drawing.Color.White;
            this.lblXP.Location = new System.Drawing.Point(80, 338);
            this.lblXP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(83, 25);
            this.lblXP.TabIndex = 3;
            this.lblXP.Text = "0 XP";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSub.ForeColor = System.Drawing.Color.White;
            this.lblSub.Location = new System.Drawing.Point(80, 418);
            this.lblSub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(135, 28);
            this.lblSub.TabIndex = 4;
            this.lblSub.Text = "SIDE QUESTS";
            // 
            // pnlMission
            // 
            this.pnlMission.Controls.Add(this.lblMissionHeader);
            this.pnlMission.Controls.Add(this.btnDeploy);
            this.pnlMission.Controls.Add(this.btnMIA);
            this.pnlMission.Location = new System.Drawing.Point(467, 185);
            this.pnlMission.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMission.Name = "pnlMission";
            this.pnlMission.Size = new System.Drawing.Size(427, 443);
            this.pnlMission.TabIndex = 2;
            // 
            // lblMissionHeader
            // 
            this.lblMissionHeader.AutoSize = true;
            this.lblMissionHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMissionHeader.ForeColor = System.Drawing.Color.White;
            this.lblMissionHeader.Location = new System.Drawing.Point(27, 25);
            this.lblMissionHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionHeader.Name = "lblMissionHeader";
            this.lblMissionHeader.Size = new System.Drawing.Size(234, 28);
            this.lblMissionHeader.TabIndex = 0;
            this.lblMissionHeader.Text = "TODAY'S MISSION";
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(27, 86);
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(373, 86);
            this.btnDeploy.TabIndex = 1;
            this.btnDeploy.Text = "DEPLOY";
            // 
            // btnMIA
            // 
            this.btnMIA.Location = new System.Drawing.Point(27, 197);
            this.btnMIA.Margin = new System.Windows.Forms.Padding(4);
            this.btnMIA.Name = "btnMIA";
            this.btnMIA.Size = new System.Drawing.Size(373, 86);
            this.btnMIA.TabIndex = 2;
            this.btnMIA.Text = "LEAVE BATTLEFIELD";
            // 
            // pnlSideTopActions
            // 
            this.pnlSideTopActions.Controls.Add(this.lblSideTopHeader);
            this.pnlSideTopActions.Location = new System.Drawing.Point(920, 185);
            this.pnlSideTopActions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSideTopActions.Name = "pnlSideTopActions";
            this.pnlSideTopActions.Size = new System.Drawing.Size(427, 209);
            this.pnlSideTopActions.TabIndex = 3;
            // 
            // lblSideTopHeader
            // 
            this.lblSideTopHeader.AutoSize = true;
            this.lblSideTopHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSideTopHeader.ForeColor = System.Drawing.Color.White;
            this.lblSideTopHeader.Location = new System.Drawing.Point(27, 25);
            this.lblSideTopHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSideTopHeader.Name = "lblSideTopHeader";
            this.lblSideTopHeader.Size = new System.Drawing.Size(147, 28);
            this.lblSideTopHeader.TabIndex = 0;
            this.lblSideTopHeader.Text = "ACHIEVEMENTS";
            // 
            // pnlSideBottomActions
            // 
            this.pnlSideBottomActions.Controls.Add(this.lblSideBottomHeader);
            this.pnlSideBottomActions.Location = new System.Drawing.Point(920, 418);
            this.pnlSideBottomActions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSideBottomActions.Name = "pnlSideBottomActions";
            this.pnlSideBottomActions.Size = new System.Drawing.Size(427, 209);
            this.pnlSideBottomActions.TabIndex = 4;
            // 
            // lblSideBottomHeader
            // 
            this.lblSideBottomHeader.AutoSize = true;
            this.lblSideBottomHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSideBottomHeader.ForeColor = System.Drawing.Color.White;
            this.lblSideBottomHeader.Location = new System.Drawing.Point(27, 25);
            this.lblSideBottomHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSideBottomHeader.Name = "lblSideBottomHeader";
            this.lblSideBottomHeader.Size = new System.Drawing.Size(109, 28);
            this.lblSideBottomHeader.TabIndex = 0;
            this.lblSideBottomHeader.Text = "LEADERBOARDS";
            // 
            // pnlQuestStrip
            // 
            this.pnlQuestStrip.Controls.Add(this.lblQuestStripTitle);
            this.pnlQuestStrip.Controls.Add(this.btnQuest1);
            this.pnlQuestStrip.Controls.Add(this.btnQuest2);
            this.pnlQuestStrip.Controls.Add(this.btnQuest3);
            this.pnlQuestStrip.Location = new System.Drawing.Point(53, 578);
            this.pnlQuestStrip.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuestStrip.Name = "pnlQuestStrip";
            this.pnlQuestStrip.Size = new System.Drawing.Size(1200, 246);
            this.pnlQuestStrip.TabIndex = 5;
            // 
            // lblQuestStripTitle
            // 
            this.lblQuestStripTitle.AutoSize = true;
            this.lblQuestStripTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuestStripTitle.ForeColor = System.Drawing.Color.White;
            this.lblQuestStripTitle.Location = new System.Drawing.Point(24, 12);
            this.lblQuestStripTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestStripTitle.Name = "lblQuestStripTitle";
            this.lblQuestStripTitle.Size = new System.Drawing.Size(170, 25);
            this.lblQuestStripTitle.TabIndex = 0;
            this.lblQuestStripTitle.Text = "SIDE QUEST FILES";
            // 
            // btnQuest1
            // 
            this.btnQuest1.Location = new System.Drawing.Point(24, 62);
            this.btnQuest1.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuest1.Name = "btnQuest1";
            this.btnQuest1.Size = new System.Drawing.Size(347, 148);
            this.btnQuest1.TabIndex = 1;
            this.btnQuest1.Text = "GRIDLOCK: ALIEN SIEGE";
            // 
            // btnQuest2
            // 
            this.btnQuest2.Location = new System.Drawing.Point(413, 62);
            this.btnQuest2.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuest2.Name = "btnQuest2";
            this.btnQuest2.Size = new System.Drawing.Size(347, 148);
            this.btnQuest2.TabIndex = 2;
            this.btnQuest2.Text = "WEAPON TRIANGLE: XENO CLASH";
            // 
            // btnQuest3
            // 
            this.btnQuest3.Location = new System.Drawing.Point(803, 62);
            this.btnQuest3.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuest3.Name = "btnQuest3";
            this.btnQuest3.Size = new System.Drawing.Size(347, 148);
            this.btnQuest3.TabIndex = 3;
            this.btnQuest3.Text = "RECENT BATTLE LOGS";
            // 
            // pnlTime
            // 
            this.pnlTime.Controls.Add(this.lblTimeHeader);
            this.pnlTime.Controls.Add(this.lblTimeValue);
            this.pnlTime.Location = new System.Drawing.Point(1360, 578);
            this.pnlTime.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(347, 135);
            this.pnlTime.TabIndex = 6;
            // 
            // lblTimeHeader
            // 
            this.lblTimeHeader.AutoSize = true;
            this.lblTimeHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimeHeader.ForeColor = System.Drawing.Color.White;
            this.lblTimeHeader.Location = new System.Drawing.Point(24, 15);
            this.lblTimeHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeHeader.Name = "lblTimeHeader";
            this.lblTimeHeader.Size = new System.Drawing.Size(121, 25);
            this.lblTimeHeader.TabIndex = 0;
            this.lblTimeHeader.Text = "LOCAL TIME";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeValue.Font = new System.Drawing.Font("Consolas", 22F, System.Drawing.FontStyle.Bold);
            this.lblTimeValue.ForeColor = System.Drawing.Color.White;
            this.lblTimeValue.Location = new System.Drawing.Point(0, 0);
            this.lblTimeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(347, 135);
            this.lblTimeValue.TabIndex = 1;
            this.lblTimeValue.Text = "00:00:00";
            this.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblStatusHeader);
            this.pnlStatus.Controls.Add(this.pbStatusArc);
            this.pnlStatus.Controls.Add(this.lblCritical);
            this.pnlStatus.Location = new System.Drawing.Point(1360, 111);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(347, 271);
            this.pnlStatus.TabIndex = 7;
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.AutoSize = true;
            this.lblStatusHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusHeader.ForeColor = System.Drawing.Color.White;
            this.lblStatusHeader.Location = new System.Drawing.Point(27, 25);
            this.lblStatusHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(84, 28);
            this.lblStatusHeader.TabIndex = 0;
            this.lblStatusHeader.Text = "STATUS";
            // 
            // pbStatusArc
            // 
            this.pbStatusArc.Location = new System.Drawing.Point(27, 86);
            this.pbStatusArc.Margin = new System.Windows.Forms.Padding(4);
            this.pbStatusArc.Name = "pbStatusArc";
            this.pbStatusArc.Size = new System.Drawing.Size(293, 31);
            this.pbStatusArc.TabIndex = 1;
            this.pbStatusArc.Value = 35;
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCritical.ForeColor = System.Drawing.Color.Red;
            this.lblCritical.Location = new System.Drawing.Point(93, 135);
            this.lblCritical.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(136, 37);
            this.lblCritical.TabIndex = 2;
            this.lblCritical.Text = "ON STANDBY";
            // 
            // pnlLogs
            // 
            this.pnlLogs.Controls.Add(this.lblLogsHeader);
            this.pnlLogs.Controls.Add(this.pbAdminLogo);
            this.pnlLogs.Location = new System.Drawing.Point(1360, 394);
            this.pnlLogs.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogs.Name = "pnlLogs";
            this.pnlLogs.Size = new System.Drawing.Size(347, 394);
            this.pnlLogs.TabIndex = 8;
            // 
            // lblLogsHeader
            // 
            this.lblLogsHeader.AutoSize = true;
            this.lblLogsHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogsHeader.ForeColor = System.Drawing.Color.White;
            this.lblLogsHeader.Location = new System.Drawing.Point(27, 25);
            this.lblLogsHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogsHeader.Name = "lblLogsHeader";
            this.lblLogsHeader.Size = new System.Drawing.Size(194, 28);
            this.lblLogsHeader.TabIndex = 0;
            this.lblLogsHeader.Text = "CLASSIFIED ACCESS";
            // 
            // pbAdminLogo
            // 
            this.pbAdminLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbAdminLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdminLogo.Location = new System.Drawing.Point(67, 135);
            this.pbAdminLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbAdminLogo.Name = "pbAdminLogo";
            this.pbAdminLogo.Size = new System.Drawing.Size(213, 197);
            this.pbAdminLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAdminLogo.TabIndex = 1;
            this.pbAdminLogo.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1360, 726);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(347, 98);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "LOGOUT";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 886);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlMission.ResumeLayout(false);
            this.pnlMission.PerformLayout();
            this.pnlSideTopActions.ResumeLayout(false);
            this.pnlSideTopActions.PerformLayout();
            this.pnlSideBottomActions.ResumeLayout(false);
            this.pnlSideBottomActions.PerformLayout();
            this.pnlQuestStrip.ResumeLayout(false);
            this.pnlQuestStrip.PerformLayout();
            this.pnlTime.ResumeLayout(false);
            this.pnlTime.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlLogs.ResumeLayout(false);
            this.pnlLogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdminLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbGifBackground;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblHudTitle;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlMission;
        private System.Windows.Forms.Label lblMissionHeader;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Button btnMIA;
        private System.Windows.Forms.Panel pnlSideTopActions;
        private System.Windows.Forms.Label lblSideTopHeader;
        private System.Windows.Forms.Panel pnlSideBottomActions;
        private System.Windows.Forms.Label lblSideBottomHeader;
        private System.Windows.Forms.Panel pnlQuestStrip;
        private System.Windows.Forms.Label lblQuestStripTitle;
        private System.Windows.Forms.Button btnQuest1;
        private System.Windows.Forms.Button btnQuest2;
        private System.Windows.Forms.Button btnQuest3;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Label lblTimeHeader;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusHeader;
        private System.Windows.Forms.ProgressBar pbStatusArc;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Panel pnlLogs;
        private System.Windows.Forms.Label lblLogsHeader;
        private System.Windows.Forms.PictureBox pbAdminLogo;
        private System.Windows.Forms.Button btnLogout;
    }
}
