// EditProfileForm.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SpaceInvaders.Data;

namespace SpaceInvaders
{
    public partial class EditProfileForm : Form
    {
        private Panel shadow;
        private readonly string currentUserId;

        // store original values for Reset
        private string oFirst, oLast, oUser, oSection, oYear, oContact;

        public EditProfileForm(string userId, string connStr)
        {
            InitializeComponent();

            currentUserId = userId;

            // Sync with centralized DB config (optional override for compatibility)
            if (!string.IsNullOrWhiteSpace(connStr))
                DbConfig.ConnectionString = connStr;

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            KeyPreview = true;

            Load += EditProfileForm_Load;
            Resize += EditProfileForm_Resize;
            KeyDown += EditProfileForm_KeyDown;

            btnBack.Click += (s, e) => Close();
            btnReset.Click += (s, e) => ResetFields();
            btnSave.Click += (s, e) => SaveProfile();
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            EditProfileFormStyler.SetupStaticUI(
                pnlCard, pnlHeader, pnlLeft, pnlRight, pnlFooter,
                lblTitle, lblSubtitle,
                lblAccountHeader, lblSecurityHeader,
                btnBack, btnSave, btnReset,
                lblFirstName, txtFirstName,
                lblLastName, txtLastName,
                lblUsername, txtUsername,
                lblSection, txtSection,
                lblYear, txtYearLevel,
                lblContact, txtContactNo,
                lblOldPass, txtOldPass,
                lblNewPass, txtNewPass,
                lblConfirmPass, txtConfirmPass,
                lblNote, lblStatus
            );

            ApplyUI();
            LoadUserProfile();
        }

        private void EditProfileForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = EditProfileFormStyler.ApplyRuntimeLayout(this, pnlCard, shadow, pnlRight);
        }

        private void LoadUserProfile()
        {
            lblStatus.Text = "";

            // fallback mock if missing config/user
            if (string.IsNullOrWhiteSpace(DbConfig.ConnectionString) || string.IsNullOrWhiteSpace(currentUserId))
            {
                txtFirstName.Text = oFirst = "Demo";
                txtLastName.Text = oLast = "User";
                txtUsername.Text = oUser = "demo_user";
                txtSection.Text = oSection = "BSCS-2A";
                txtYearLevel.Text = oYear = "2";
                txtContactNo.Text = oContact = "09XXXXXXXXX";
                return;
            }

            try
            {
                // TODO: Adjust column names if yours differ
                string q =
                    "SELECT FirstName, LastName, Username, Section, YearLevel, ContactNo " +
                    "FROM student_info " +
                    "WHERE StudentID = @id LIMIT 1;";

                DataTable dt = DbHelper.ExecuteQuery(q, cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", currentUserId);
                });

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    txtFirstName.Text = oFirst = r["FirstName"]?.ToString() ?? "";
                    txtLastName.Text = oLast = r["LastName"]?.ToString() ?? "";
                    txtUsername.Text = oUser = r["Username"]?.ToString() ?? "";
                    txtSection.Text = oSection = r["Section"]?.ToString() ?? "";
                    txtYearLevel.Text = oYear = r["YearLevel"]?.ToString() ?? "";
                    txtContactNo.Text = oContact = r["ContactNo"]?.ToString() ?? "";
                }
                else
                {
                    lblStatus.Text = "User data not found.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Load failed: " + ex.Message;
            }
        }

        private void ResetFields()
        {
            txtFirstName.Text = oFirst;
            txtLastName.Text = oLast;
            txtUsername.Text = oUser;
            txtSection.Text = oSection;
            txtYearLevel.Text = oYear;
            txtContactNo.Text = oContact;

            txtOldPass.Clear();
            txtNewPass.Clear();
            txtConfirmPass.Clear();

            lblStatus.Text = "Fields reset.";
        }

        private void SaveProfile()
        {
            lblStatus.Text = "";

            // basic validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblStatus.Text = "First name, last name, and username are required.";
                return;
            }

            bool wantsPasswordChange =
                !string.IsNullOrWhiteSpace(txtOldPass.Text) ||
                !string.IsNullOrWhiteSpace(txtNewPass.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmPass.Text);

            if (wantsPasswordChange)
            {
                if (txtNewPass.Text != txtConfirmPass.Text)
                {
                    lblStatus.Text = "New password does not match confirmation.";
                    return;
                }

                if (txtNewPass.Text.Length < 4)
                {
                    lblStatus.Text = "New password is too short.";
                    return;
                }
            }

            // centralized DB required
            if (string.IsNullOrWhiteSpace(DbConfig.ConnectionString))
            {
                // mock save
                oFirst = txtFirstName.Text.Trim();
                oLast = txtLastName.Text.Trim();
                oUser = txtUsername.Text.Trim();
                oSection = txtSection.Text.Trim();
                oYear = txtYearLevel.Text.Trim();
                oContact = txtContactNo.Text.Trim();
                lblStatus.Text = "Mock save complete (no DB).";
                return;
            }

            try
            {
                // 1) Update account details
                string updateInfo =
                    "UPDATE student_info SET " +
                    "FirstName=@fn, LastName=@ln, Username=@un, " +
                    "Section=@sec, YearLevel=@yr, ContactNo=@cn " +
                    "WHERE StudentID=@id;";

                DbHelper.ExecuteNonQuery(updateInfo, cmd =>
                {
                    cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@un", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@sec", txtSection.Text.Trim());
                    cmd.Parameters.AddWithValue("@yr", txtYearLevel.Text.Trim());
                    cmd.Parameters.AddWithValue("@cn", txtContactNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", currentUserId);
                });

                // 2) Optional password change
                if (wantsPasswordChange)
                {
                    // TODO: Adjust column name if different (ex: PasswordHash)
                    string checkOld =
                        "SELECT Password FROM student_info WHERE StudentID=@id LIMIT 1;";

                    object res = DbHelper.ExecuteScalar(checkOld, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@id", currentUserId);
                    });

                    string oldDb = res?.ToString();

                    if (string.IsNullOrEmpty(oldDb) || oldDb != txtOldPass.Text)
                    {
                        lblStatus.Text = "Old password is incorrect.";
                        return;
                    }

                    string updatePass =
                        "UPDATE student_info SET Password=@pw WHERE StudentID=@id;";

                    DbHelper.ExecuteNonQuery(updatePass, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@pw", txtNewPass.Text);
                        cmd.Parameters.AddWithValue("@id", currentUserId);
                    });
                }

                // update originals after save
                oFirst = txtFirstName.Text.Trim();
                oLast = txtLastName.Text.Trim();
                oUser = txtUsername.Text.Trim();
                oSection = txtSection.Text.Trim();
                oYear = txtYearLevel.Text.Trim();
                oContact = txtContactNo.Text.Trim();

                txtOldPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();

                lblStatus.Text = "Profile updated successfully.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Save failed: " + ex.Message;
            }
        }

        private void EditProfileForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            EditProfileFormStyler.PaintGradientBackground(this, e);
        }
    }
}
