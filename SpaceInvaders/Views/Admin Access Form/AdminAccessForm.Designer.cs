// AdminAccessForm.Designer.cs
namespace SpaceInvaders
{
    partial class AdminAccessForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTablesHeader = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblActiveTable = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReloadTables = new System.Windows.Forms.Button();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.gridDb = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDb)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlCard
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.Controls.Add(this.pnlFooter);
            this.pnlCard.Controls.Add(this.pnlMain);
            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Location = new System.Drawing.Point(30, 30);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1200, 700);
            this.pnlCard.TabIndex = 0;

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Height = 80;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(18, 10);
            this.lblTitle.Size = new System.Drawing.Size(720, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "ADMIN ACCESS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblSubtitle
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitle.Size = new System.Drawing.Size(860, 25);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "CLASSIFIED DATABASE CONSOLE // READOUT";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnBack
            this.btnBack.Name = "btnBack";
            this.btnBack.Text = "RETURN";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.Location = new System.Drawing.Point(1040, 20);
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(14);

            // pnlLeft
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.lstTables);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.Controls.Add(this.lblTablesHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(14);
            this.pnlLeft.Width = 320;

            // lblTablesHeader
            this.lblTablesHeader.AutoSize = false;
            this.lblTablesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTablesHeader.Height = 40;
            this.lblTablesHeader.Text = "TABLES";
            this.lblTablesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Height = 30;

            // lstTables
            this.lstTables.Name = "lstTables";
            this.lstTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTables.IntegralHeight = false;

            // pnlRight
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.gridDb);
            this.pnlRight.Controls.Add(this.pnlTopBar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(14);

            // pnlTopBar
            this.pnlTopBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.Controls.Add(this.lblRowCount);
            this.pnlTopBar.Controls.Add(this.btnReloadTables);
            this.pnlTopBar.Controls.Add(this.btnRefresh);
            this.pnlTopBar.Controls.Add(this.lblActiveTable);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Height = 46;

            // lblActiveTable
            this.lblActiveTable.AutoSize = false;
            this.lblActiveTable.Location = new System.Drawing.Point(6, 8);
            this.lblActiveTable.Size = new System.Drawing.Size(520, 30);
            this.lblActiveTable.Name = "lblActiveTable";
            this.lblActiveTable.Text = "SELECT A TABLE";
            this.lblActiveTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnRefresh
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Size = new System.Drawing.Size(120, 32);
            this.btnRefresh.Location = new System.Drawing.Point(580, 7);
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // btnReloadTables
            this.btnReloadTables.Name = "btnReloadTables";
            this.btnReloadTables.Text = "RELOAD";
            this.btnReloadTables.Size = new System.Drawing.Size(120, 32);
            this.btnReloadTables.Location = new System.Drawing.Point(708, 7);
            this.btnReloadTables.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // lblRowCount
            this.lblRowCount.AutoSize = false;
            this.lblRowCount.Location = new System.Drawing.Point(836, 8);
            this.lblRowCount.Size = new System.Drawing.Size(260, 30);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Text = "ROWS: 0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // gridDb
            this.gridDb.Name = "gridDb";
            this.gridDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDb.AllowUserToAddRows = false;
            this.gridDb.AllowUserToDeleteRows = false;
            this.gridDb.ReadOnly = true;
            this.gridDb.RowHeadersVisible = false;
            this.gridDb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDb.MultiSelect = false;
            this.gridDb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Height = 48;
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(14);

            // lblStatus
            this.lblStatus.AutoSize = false;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "READY.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // AdminAccessForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.Name = "AdminAccessForm";
            this.Text = "Admin Access";

            this.pnlCard.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDb)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTablesHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lstTables;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblActiveTable;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReloadTables;
        private System.Windows.Forms.Label lblRowCount;

        private System.Windows.Forms.DataGridView gridDb;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatus;
    }
}
