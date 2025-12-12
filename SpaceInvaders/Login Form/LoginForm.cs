using SpaceInvaders.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class LoginForm : Form
    {
        private Panel shadow;

        private const string PH_USERNAME = "Username";
        private const string PH_PASSWORD = "Password";

        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color InputColor = ColorTranslator.FromHtml("#E6FFF9");

        public LoginForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            this.Load += LoginForm_Load;
            this.Resize += LoginForm_Resize;

            btnLogin.Click += BtnLogin_Click;
            lblRegister.Click += LblRegister_Click;
            ForgotPasswordlbl.Click += ForgotPasswordlbl_Click;

            this.AcceptButton = btnLogin;

            txtUsername.Enter += TxtUsername_Enter;
            txtUsername.Leave += TxtUsername_Leave;

            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Leave += TxtPassword_Leave;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbGifBackground.Image = Image.FromFile("space.gif");
                pbGifBackground.SendToBack();
            }
            catch
            {
                pbGifBackground.BackColor = Color.Black;
            }

            LoginFormStyler.SetupStaticUI(
                btnLogin,
                lblRegister,
                panelUsername,
                panelPass
            );

            ApplyUsernamePlaceholder();
            ApplyPasswordPlaceholder();

            ApplyUI();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = LoginFormStyler.ApplyRuntimeTweaks(
                this,
                pnlCard,
                shadow,
                lblTitle,
                panelUsername,
                panelPass,
                btnLogin,
                lblRegister,
                txtUsername,
                txtPassword,
                ForgotPasswordlbl
            );
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == PH_USERNAME)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = InputColor;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                ApplyUsernamePlaceholder();
        }

        private void ApplyUsernamePlaceholder()
        {
            txtUsername.Text = PH_USERNAME;
            txtUsername.ForeColor = PlaceholderColor;
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == PH_PASSWORD)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = InputColor;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                ApplyPasswordPlaceholder();
        }

        private void ApplyPasswordPlaceholder()
        {
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = PH_PASSWORD;
            txtPassword.ForeColor = PlaceholderColor;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = (txtUsername.Text == PH_USERNAME) ? "" : txtUsername.Text;
            string password = (txtPassword.Text == PH_PASSWORD) ? "" : txtPassword.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                HudMessageBox.Show(
                    "Please enter your username and password.",
                    "INPUT REQUIRED",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Warning,
                    this
                );
                return;
            }

            var loginRepo = new LoginRepository();
            bool valid = loginRepo.ValidateLogin(userName, password);

            if (valid)
            {
                OpenFormByName("SpaceInvaders.DashboardForm", userName);
                this.Hide();
            }
            else
            {
                HudMessageBox.Show(
                    "Wrong username or password.",
                    "ACCESS DENIED",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Error,
                    this
                );
            }
        }

        private void ForgotPasswordlbl_Click(object sender, EventArgs e)
        {
            OpenFormByName("SpaceInvaders.ForgotPasswordForm");
            this.Hide();
        }

        private void LblRegister_Click(object sender, EventArgs e)
        {
            OpenFormByName("SpaceInvaders.RegisterForm");
            this.Hide();
        }

        private void OpenFormByName(string fullTypeName, params object[] args)
        {
            try
            {
                Type t = Type.GetType(fullTypeName);

                if (t == null)
                {
                    HudMessageBox.Show(
                        $"Form not found yet:\n{fullTypeName}",
                        "FORM MISSING",
                        HudMessageBoxButtons.OK,
                        HudMessageBoxIcon.Warning,
                        this
                    );
                    this.Show();
                    return;
                }

                Form f = (Form)Activator.CreateInstance(t, args);
                f.FormClosed += (s, e) => this.Show();
                f.Show();
            }
            catch (Exception ex)
            {
                HudMessageBox.Show(
                    $"Could not open form:\n{fullTypeName}\n\n{ex.Message}",
                    "ERROR",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Error,
                    this
                );
                this.Show();
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e) { }
        private void btnLogin_Click_1(object sender, EventArgs e) { }
    }
}
