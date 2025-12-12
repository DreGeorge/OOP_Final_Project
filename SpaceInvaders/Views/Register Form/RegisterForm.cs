using SpaceInvaders.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class RegisterForm : Form
    {
        private Panel shadow;

        public RegisterForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            this.Load += RegisterForm_Load;
            this.Resize += RegisterForm_Resize;

            btnRegister.Click += BtnRegister_Click;
            btnBackToLogin.Click += BtnBackToLogin_Click;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbGifBackground.Image = Image.FromFile("space.gif");
                pbGifBackground.SendToBack();
                pnlCard.BringToFront();
            }
            catch
            {
                pbGifBackground.BackColor = Color.Black;
            }

            RegisterFormStyler.SetupStaticUI(
                btnRegister,
                btnBackToLogin,
                pnlUsername,
                pnlEmail,
                pnlPassword,
                pnlFirstName,
                pnlLastName,
                pnlAge,
                pnlContact
            );

            RegisterFormStyler.SetPlaceholder(txtUsername, "Username");
            RegisterFormStyler.SetPlaceholder(txtEmail, "Email");
            RegisterFormStyler.SetPlaceholder(txtPassword, "Password", isPassword: true);
            RegisterFormStyler.SetPlaceholder(txtFirstName, "First Name");
            RegisterFormStyler.SetPlaceholder(txtLastName, "Last Name");
            RegisterFormStyler.SetPlaceholder(txtAge, "Age");
            RegisterFormStyler.SetPlaceholder(txtContact, "Contact Number");

            ApplyUI();
        }

        private void RegisterForm_Resize(object sender, EventArgs e)
        {
            ApplyUI();
        }

        private void ApplyUI()
        {
            shadow = RegisterFormStyler.ApplyRuntimeTweaks(
                this,
                pnlCard,
                shadow,
                lblTitle,
                pnlUsername,
                pnlEmail,
                pnlPassword,
                pnlFirstName,
                pnlLastName,
                pnlAge,
                pnlContact,
                btnRegister,
                btnBackToLogin,
                txtUsername,
                txtEmail,
                txtPassword,
                txtFirstName,
                txtLastName,
                txtAge,
                txtContact
            );
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string contact = txtContact.Text.Trim();

            int age = 0;
            int.TryParse(txtAge.Text.Trim(), out age);

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                age <= 0)
            {
                HudMessageBox.Show(
                    "Please complete all required fields.\n(Age must be a valid number.)",
                    "INCOMPLETE DATA",
                    HudMessageBoxButtons.OK,
                    HudMessageBoxIcon.Warning,
                    this
                );
                return;
            }

            string qUserInfo = @"
                INSERT INTO user_info
                    (UserName, FirstName, LastName, Age, Email, Contact_Number)
                VALUES
                    (@UserName, @FirstName, @LastName, @Age, @Email, @Contact);
            ";

            DbHelper.ExecuteNonQuery(qUserInfo, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
            });

            string qLogin = @"
                INSERT INTO login_info
                    (UserName, Password)
                VALUES
                    (@UserName, @Password);
            ";

            DbHelper.ExecuteNonQuery(qLogin, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
            });

            HudMessageBox.Show(
                "Registration successful!\nYou may now log in.",
                "WELCOME PILOT",
                HudMessageBoxButtons.OK,
                HudMessageBoxIcon.Success,
                this
            );

            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void BtnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
