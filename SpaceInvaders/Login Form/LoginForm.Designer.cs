namespace SpaceInvaders
{
    partial class LoginForm
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
            this.ForgotPasswordlbl = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelPass = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblTitle = new SpaceInvaders.HudTitleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.panelPass.SuspendLayout();
            this.panelUsername.SuspendLayout();
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
            this.pnlCard.Controls.Add(this.ForgotPasswordlbl);
            this.pnlCard.Controls.Add(this.lblRegister);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.panelPass);
            this.pnlCard.Controls.Add(this.panelUsername);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Location = new System.Drawing.Point(120, 49);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(700, 520);
            this.pnlCard.TabIndex = 0;
            // 
            // ForgotPasswordlbl
            // 
            this.ForgotPasswordlbl.AutoSize = true;
            this.ForgotPasswordlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForgotPasswordlbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForgotPasswordlbl.ForeColor = System.Drawing.Color.Black;
            this.ForgotPasswordlbl.Location = new System.Drawing.Point(166, 282);
            this.ForgotPasswordlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ForgotPasswordlbl.Name = "ForgotPasswordlbl";
            this.ForgotPasswordlbl.Size = new System.Drawing.Size(127, 19);
            this.ForgotPasswordlbl.TabIndex = 5;
            this.ForgotPasswordlbl.Text = "Forgot Password?";
            this.ForgotPasswordlbl.Click += new System.EventHandler(this.ForgotPasswordlbl_Click);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRegister.ForeColor = System.Drawing.Color.Black;
            this.lblRegister.Location = new System.Drawing.Point(168, 373);
            this.lblRegister.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(122, 19);
            this.lblRegister.TabIndex = 4;
            this.lblRegister.Text = "Create an account";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(60, 316);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(560, 55);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // panelPass
            // 
            this.panelPass.BackColor = System.Drawing.Color.White;
            this.panelPass.Controls.Add(this.txtPassword);
            this.panelPass.Location = new System.Drawing.Point(60, 225);
            this.panelPass.Margin = new System.Windows.Forms.Padding(2);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(560, 55);
            this.panelPass.TabIndex = 2;
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
            // panelUsername
            // 
            this.panelUsername.BackColor = System.Drawing.Color.White;
            this.panelUsername.Controls.Add(this.txtUsername);
            this.panelUsername.Location = new System.Drawing.Point(60, 175);
            this.panelUsername.Margin = new System.Windows.Forms.Padding(2);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Size = new System.Drawing.Size(560, 55);
            this.panelUsername.TabIndex = 1;
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
            // lblTitle (HUD custom)
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Space Invaders";
            this.lblTitle.Subtitle = "";
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(700, 65);
            this.lblTitle.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.pbGifBackground);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbGifBackground)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.panelPass.ResumeLayout(false);
            this.panelPass.PerformLayout();
            this.panelUsername.ResumeLayout(false);
            this.panelUsername.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGifBackground;
        private System.Windows.Forms.Panel pnlCard;
        private SpaceInvaders.HudTitleLabel lblTitle;

        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Panel panelPass;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label ForgotPasswordlbl;
    }
}
