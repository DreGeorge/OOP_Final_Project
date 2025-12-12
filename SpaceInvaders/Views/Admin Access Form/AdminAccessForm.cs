// AdminAccessForm.cs
using Org.BouncyCastle.Asn1.Cmp;
using SpaceInvaders.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class AdminAccessForm : Form
    {
        private Panel shadow;
        private string selectedTable = null;

        private List<string> allTables = new List<string>();

        public AdminAccessForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            KeyPreview = true;

            Load += AdminAccessForm_Load;
            Resize += AdminAccessForm_Resize;
            KeyDown += AdminAccessForm_KeyDown;

            btnBack.Click += (s, e) => Close();
            btnReloadTables.Click += (s, e) => LoadTables();
            btnRefresh.Click += (s, e) => RefreshCurrentTable();
            txtSearch.TextChanged += (s, e) => ApplyTableFilter();
            lstTables.SelectedIndexChanged += LstTables_SelectedIndexChanged;
        }

        private void AdminAccessForm_Load(object sender, EventArgs e)
        {
            AdminAccessFormStyler.SetupStaticUI(
                pnlCard, pnlHeader, pnlLeft, pnlRight, pnlTopBar, pnlFooter,
                lblTitle, lblSubtitle,
                lblTablesHeader, lblActiveTable, lblRowCount, lblStatus,
                txtSearch, lstTables,
                btnBack, btnRefresh, btnReloadTables,
                gridDb
            );

            ApplyUI();
            LoadTables();
        }

        private void AdminAccessForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = AdminAccessFormStyler.ApplyRuntimeLayout(this, pnlCard, shadow);
        }

        private void AdminAccessForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            AdminAccessFormStyler.PaintGradientBackground(this, e);
        }

        private void LoadTables()
        {
            lblStatus.Text = "SCANNING DATABASE...";
            lblRowCount.Text = "ROWS: 0";
            lblActiveTable.Text = "SELECT A TABLE";
            selectedTable = null;
            gridDb.DataSource = null;

            allTables.Clear();
            lstTables.Items.Clear();

            try
            {
                if (string.IsNullOrWhiteSpace(DbConfig.ConnectionString))
                {
                    lblStatus.Text = "DB CONNECTION STRING NOT SET (DbConfig.ConnectionString).";
                    return;
                }

                // Discover tables in current database
                string q =
                    "SELECT TABLE_NAME " +
                    "FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_SCHEMA = DATABASE() " +
                    "ORDER BY TABLE_NAME;";

                DataTable dt = DbHelper.ExecuteQuery(q);

                foreach (DataRow r in dt.Rows)
                {
                    string name = r["TABLE_NAME"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(name))
                        allTables.Add(name);
                }

                ApplyTableFilter();
                lblStatus.Text = $"TABLES LOADED: {allTables.Count}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "FAILED TO LOAD TABLES: " + ex.Message;
            }
        }

        private void ApplyTableFilter()
        {
            string filter = (txtSearch.Text ?? "").Trim().ToLowerInvariant();

            var filtered = string.IsNullOrWhiteSpace(filter)
                ? allTables
                : allTables.Where(t => t.ToLowerInvariant().Contains(filter)).ToList();

            lstTables.BeginUpdate();
            lstTables.Items.Clear();
            foreach (var t in filtered)
                lstTables.Items.Add(t);
            lstTables.EndUpdate();
        }

        private void LstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem == null) return;

            string table = lstTables.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(table)) return;

            selectedTable = table;
            LoadTableData(table);
        }

        private void RefreshCurrentTable()
        {
            if (string.IsNullOrWhiteSpace(selectedTable))
            {
                lblStatus.Text = "NO TABLE SELECTED.";
                return;
            }

            LoadTableData(selectedTable);
        }

        private void LoadTableData(string tableName)
        {
            lblStatus.Text = $"LOADING: {tableName}";
            lblActiveTable.Text = $"TABLE: {tableName}";
            lblRowCount.Text = "ROWS: 0";

            try
            {
                if (string.IsNullOrWhiteSpace(DbConfig.ConnectionString))
                {
                    lblStatus.Text = "DB CONNECTION STRING NOT SET (DbConfig.ConnectionString).";
                    return;
                }

                // NOTE: This is a viewer; pull a large chunk safely.
                // We avoid parameterizing table name; we validate it against discovered list.
                if (!allTables.Contains(tableName))
                {
                    lblStatus.Text = "SECURITY BLOCK: TABLE NOT IN DISCOVERED LIST.";
                    return;
                }

                string q = $"SELECT * FROM `{tableName}`;";

                DataTable dt = DbHelper.ExecuteQuery(q);
                gridDb.DataSource = dt;

                lblRowCount.Text = $"ROWS: {dt.Rows.Count}";
                lblStatus.Text = $"READY. LOADED {tableName}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "FAILED TO LOAD TABLE: " + ex.Message;
            }
        }
    }
}
