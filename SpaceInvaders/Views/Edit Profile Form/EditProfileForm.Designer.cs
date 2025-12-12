// EditProfileForm.Designer.cs
namespace SpaceInvaders
{
    partial class EditProfileForm
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
            this.lblAccountHeader = new System.Windows.Forms.Label();

            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();

            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();

            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();

            this.lblSection = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();

            this.lblYear = new System.Windows.Forms.Label();
            this.txtYearLevel = new System.Windows.Forms.TextBox();

            this.lblContact = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblSecurityHeader = new System.Windows.Forms.Label();

            this.lblOldPass = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();

            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();

            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();

            this.lblNote = new System.Windows.Forms.Label();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(520, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "EDIT PROFILE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblSubtitle
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitle.Size = new System.Drawing.Size(720, 25);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "COMMANDER DATA FILE // UPDATE";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnBack
            this.btnBack.Name = "btnBack";
            this.btnBack.Text = "RETURN";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.Location = new System.Drawing.Point(1020, 20);
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
            this.pnlLeft.Controls.Add(this.txtContactNo);
            this.pnlLeft.Controls.Add(this.lblContact);
            this.pnlLeft.Controls.Add(this.txtYearLevel);
            this.pnlLeft.Controls.Add(this.lblYear);
            this.pnlLeft.Controls.Add(this.txtSection);
            this.pnlLeft.Controls.Add(this.lblSection);
            this.pnlLeft.Controls.Add(this.txtUsername);
            this.pnlLeft.Controls.Add(this.lblUsername);
            this.pnlLeft.Controls.Add(this.txtLastName);
            this.pnlLeft.Controls.Add(this.lblLastName);
            this.pnlLeft.Controls.Add(this.txtFirstName);
            this.pnlLeft.Controls.Add(this.lblFirstName);
            this.pnlLeft.Controls.Add(this.lblAccountHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(18);

            // lblAccountHeader
            this.lblAccountHeader.AutoSize = false;
            this.lblAccountHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAccountHeader.Height = 40;
            this.lblAccountHeader.Text = "ACCOUNT DETAILS";
            this.lblAccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            int leftX = 30, topY = 70, gapY = 65, lblW = 130, txtW = 360, txtH = 28;

            // First Name
            this.lblFirstName.Text = "First Name:";
            this.lblFirstName.Location = new System.Drawing.Point(leftX, topY);
            this.lblFirstName.Size = new System.Drawing.Size(lblW, 24);

            this.txtFirstName.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtFirstName.Size = new System.Drawing.Size(txtW, txtH);

            // Last Name
            topY += gapY;
            this.lblLastName.Text = "Last Name:";
            this.lblLastName.Location = new System.Drawing.Point(leftX, topY);
            this.lblLastName.Size = new System.Drawing.Size(lblW, 24);

            this.txtLastName.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtLastName.Size = new System.Drawing.Size(txtW, txtH);

            // Username
            topY += gapY;
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(leftX, topY);
            this.lblUsername.Size = new System.Drawing.Size(lblW, 24);

            this.txtUsername.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtUsername.Size = new System.Drawing.Size(txtW, txtH);

            // Section
            topY += gapY;
            this.lblSection.Text = "Section:";
            this.lblSection.Location = new System.Drawing.Point(leftX, topY);
            this.lblSection.Size = new System.Drawing.Size(lblW, 24);

            this.txtSection.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtSection.Size = new System.Drawing.Size(txtW, txtH);

            // Year Level
            topY += gapY;
            this.lblYear.Text = "Year Level:";
            this.lblYear.Location = new System.Drawing.Point(leftX, topY);
            this.lblYear.Size = new System.Drawing.Size(lblW, 24);

            this.txtYearLevel.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtYearLevel.Size = new System.Drawing.Size(txtW, txtH);

            // Contact No
            topY += gapY;
            this.lblContact.Text = "Contact No:";
            this.lblContact.Location = new System.Drawing.Point(leftX, topY);
            this.lblContact.Size = new System.Drawing.Size(lblW, 24);

            this.txtContactNo.Location = new System.Drawing.Point(leftX + lblW, topY - 2);
            this.txtContactNo.Size = new System.Drawing.Size(txtW, txtH);

            // pnlRight
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.lblNote);
            this.pnlRight.Controls.Add(this.txtConfirmPass);
            this.pnlRight.Controls.Add(this.lblConfirmPass);
            this.pnlRight.Controls.Add(this.txtNewPass);
            this.pnlRight.Controls.Add(this.lblNewPass);
            this.pnlRight.Controls.Add(this.txtOldPass);
            this.pnlRight.Controls.Add(this.lblOldPass);
            this.pnlRight.Controls.Add(this.lblSecurityHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(18);
            this.pnlRight.Width = 420;

            // lblSecurityHeader
            this.lblSecurityHeader.AutoSize = false;
            this.lblSecurityHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSecurityHeader.Height = 40;
            this.lblSecurityHeader.Text = "SECURITY / PASSWORD";
            this.lblSecurityHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            int rightX = 30, rTopY = 70;

            // Old Pass
            this.lblOldPass.Text = "Old Password:";
            this.lblOldPass.Location = new System.Drawing.Point(rightX, rTopY);
            this.lblOldPass.Size = new System.Drawing.Size(160, 24);

            this.txtOldPass.Location = new System.Drawing.Point(rightX, rTopY + 26);
            this.txtOldPass.Size = new System.Drawing.Size(330, txtH);
            this.txtOldPass.UseSystemPasswordChar = true;

            // New Pass
            rTopY += 90;
            this.lblNewPass.Text = "New Password:";
            this.lblNewPass.Location = new System.Drawing.Point(rightX, rTopY);
            this.lblNewPass.Size = new System.Drawing.Size(160, 24);

            this.txtNewPass.Location = new System.Drawing.Point(rightX, rTopY + 26);
            this.txtNewPass.Size = new System.Drawing.Size(330, txtH);
            this.txtNewPass.UseSystemPasswordChar = true;

            // Confirm Pass
            rTopY += 90;
            this.lblConfirmPass.Text = "Confirm Password:";
            this.lblConfirmPass.Location = new System.Drawing.Point(rightX, rTopY);
            this.lblConfirmPass.Size = new System.Drawing.Size(170, 24);

            this.txtConfirmPass.Location = new System.Drawing.Point(rightX, rTopY + 26);
            this.txtConfirmPass.Size = new System.Drawing.Size(330, txtH);
            this.txtConfirmPass.UseSystemPasswordChar = true;

            // lblNote
            rTopY += 80;
            this.lblNote.AutoSize = false;
            this.lblNote.Location = new System.Drawing.Point(rightX, rTopY);
            this.lblNote.Size = new System.Drawing.Size(350, 120);
            this.lblNote.Text = "Leave password fields empty if you don’t want to change it.";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopLeft;

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Controls.Add(this.btnReset);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Height = 70;
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(14);

            // btnSave
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "SAVE CHANGES";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.Location = new System.Drawing.Point(18, 14);

            // btnReset
            this.btnReset.Name = "btnReset";
            this.btnReset.Text = "RESET";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.Location = new System.Drawing.Point(210, 14);

            // lblStatus
            this.lblStatus.AutoSize = false;
            this.lblStatus.Location = new System.Drawing.Point(360, 18);
            this.lblStatus.Size = new System.Drawing.Size(800, 32);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // EditProfileForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlCard);
            this.DoubleBuffered = true;
            this.Name = "EditProfileForm";
            this.Text = "Edit Profile";

            this.pnlCard.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
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
        private System.Windows.Forms.Label lblAccountHeader;

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYearLevel;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContactNo;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblSecurityHeader;

        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label lblNote;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblStatus;
    }
}
