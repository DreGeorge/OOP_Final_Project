namespace SpaceInvaders
{
    partial class RegisterForm
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
            this.btnBackToLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();

            this.pnlContact = new System.Windows.Forms.Panel();
            this.txtContact = new System.Windows.Forms.TextBox();

            this.pnlAge = new System.Windows.Forms.Panel();
            this.txtAge = new System.Windows.Forms.TextBox();

            this.pnlLastName = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();

            this.pnlFirstName = new System.Windows.Forms.Panel();
            this.txtFirstName = new System.Windows.Forms.TextBox();

            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();

            this.pnlEmail = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();

            this.lblTitle = new SpaceInvaders.HudTitleLabel();

            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).BeginInit();
            this.pnlCard.SuspendLayout();

            this.pnlContact.SuspendLayout();
            this.pnlAge.SuspendLayout();
            this.pnlLastName.SuspendLayout();
            this.pnlFirstName.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            this.pnlUsername.SuspendLayout();

            this.SuspendLayout();
            // 
            // pbGifBackground
            // 
            this.pbGifBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGifBackground.Location = new System.Drawing.Point(0, 0);
            this.pbGifBackground.Name = "pbGifBackground";
            this.pbGifBackground.Size = new System.Drawing.Size(1080, 720);
            this.pbGifBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGifBackground.TabIndex = 99;
            this.pbGifBackground.TabStop = false;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnBackToLogin);
            this.pnlCard.Controls.Add(this.btnRegister);

            this.pnlCard.Controls.Add(this.pnlContact);
            this.pnlCard.Controls.Add(this.pnlAge);
            this.pnlCard.Controls.Add(this.pnlLastName);
            this.pnlCard.Controls.Add(this.pnlFirstName);
            this.pnlCard.Controls.Add(this.pnlPassword);
            this.pnlCard.Controls.Add(this.pnlEmail);
            this.pnlCard.Controls.Add(this.pnlUsername);

            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Location = new System.Drawing.Point(120, 49);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(700, 620);
            this.pnlCard.TabIndex = 0;
            // 
            // btnBackToLogin
            // 
            this.btnBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToLogin.FlatAppearance.BorderSize = 0;
            this.btnBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnBackToLogin.ForeColor = System.Drawing.Color.White;
            this.btnBackToLogin.Location = new System.Drawing.Point(60, 560);
            this.btnBackToLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(560, 40);
            this.btnBackToLogin.TabIndex = 9;
            this.btnBackToLogin.Text = "Back to Login";
            this.btnBackToLogin.UseVisualStyleBackColor = false;
            this.btnBackToLogin.Visible = true;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(60, 502);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(560, 55);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // pnlContact
            // 
            this.pnlContact.BackColor = System.Drawing.Color.White;
            this.pnlContact.Controls.Add(this.txtContact);
            this.pnlContact.Location = new System.Drawing.Point(342, 376);
            this.pnlContact.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(278, 52);
            this.pnlContact.TabIndex = 7;
            // 
            // txtContact
            // 
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContact.ForeColor = System.Drawing.Color.Gray;
            this.txtContact.Location = new System.Drawing.Point(0, 0);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(278, 22);
            this.txtContact.TabIndex = 0;
            this.txtContact.Text = "Contact Number";
            // 
            // pnlAge
            // 
            this.pnlAge.BackColor = System.Drawing.Color.White;
            this.pnlAge.Controls.Add(this.txtAge);
            this.pnlAge.Location = new System.Drawing.Point(60, 376);
            this.pnlAge.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAge.Name = "pnlAge";
            this.pnlAge.Size = new System.Drawing.Size(270, 52);
            this.pnlAge.TabIndex = 6;
            // 
            // txtAge
            // 
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAge.ForeColor = System.Drawing.Color.Gray;
            this.txtAge.Location = new System.Drawing.Point(0, 0);
            this.txtAge.Margin = new System.Windows.Forms.Padding(2);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(270, 22);
            this.txtAge.TabIndex = 0;
            this.txtAge.Text = "Age";
            // 
            // pnlLastName
            // 
            this.pnlLastName.BackColor = System.Drawing.Color.White;
            this.pnlLastName.Controls.Add(this.txtLastName);
            this.pnlLastName.Location = new System.Drawing.Point(342, 199);
            this.pnlLastName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLastName.Name = "pnlLastName";
            this.pnlLastName.Size = new System.Drawing.Size(278, 52);
            this.pnlLastName.TabIndex = 5;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLastName.ForeColor = System.Drawing.Color.Gray;
            this.txtLastName.Location = new System.Drawing.Point(0, 0);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(278, 22);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.Text = "Last Name";
            // 
            // pnlFirstName
            // 
            this.pnlFirstName.BackColor = System.Drawing.Color.White;
            this.pnlFirstName.Controls.Add(this.txtFirstName);
            this.pnlFirstName.Location = new System.Drawing.Point(60, 199);
            this.pnlFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFirstName.Name = "pnlFirstName";
            this.pnlFirstName.Size = new System.Drawing.Size(270, 52);
            this.pnlFirstName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFirstName.ForeColor = System.Drawing.Color.Gray;
            this.txtFirstName.Location = new System.Drawing.Point(0, 0);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(270, 22);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "First Name";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.White;
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(60, 317);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(560, 52);
            this.pnlPassword.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(560, 22);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "Password";
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = System.Drawing.Color.White;
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Location = new System.Drawing.Point(60, 258);
            this.pnlEmail.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(560, 52);
            this.pnlEmail.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEmail.Location = new System.Drawing.Point(0, 0);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(560, 22);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email";
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.White;
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(60, 140);
            this.pnlUsername.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(560, 52);
            this.pnlUsername.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.Location = new System.Drawing.Point(0, 0);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(560, 22);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username";
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "SPACE INVADERS\r\nREGISTRATION"; // ✅ two-line title
            this.lblTitle.Subtitle = "";
            this.lblTitle.Location = new System.Drawing.Point(60, 10);
            this.lblTitle.Size = new System.Drawing.Size(560, 95);
            this.lblTitle.TabIndex = 0;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.pbGifBackground);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterForm";
            this.Text = "Register";

            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).EndInit();
            this.pnlCard.ResumeLayout(false);

            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.pnlAge.ResumeLayout(false);
            this.pnlAge.PerformLayout();
            this.pnlLastName.ResumeLayout(false);
            this.pnlLastName.PerformLayout();
            this.pnlFirstName.ResumeLayout(false);
            this.pnlFirstName.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbGifBackground;
        private System.Windows.Forms.Panel pnlCard;
        private SpaceInvaders.HudTitleLabel lblTitle;

        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Panel pnlFirstName;
        private System.Windows.Forms.TextBox txtFirstName;

        private System.Windows.Forms.Panel pnlLastName;
        private System.Windows.Forms.TextBox txtLastName;

        private System.Windows.Forms.Panel pnlAge;
        private System.Windows.Forms.TextBox txtAge;

        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.TextBox txtContact;

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBackToLogin;
    }
}
