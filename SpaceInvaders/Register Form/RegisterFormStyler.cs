using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SpaceInvaders
{
    public static class RegisterFormStyler
    {
        private static Timer pulseTimer;
        private static float pulse = 0f;
        private static bool pulseUp = true;

        public static void SetupStaticUI(
            Button btnRegister,
            Button btnBackToLogin,
            params Panel[] inputPanels)
        {
            btnRegister.BackColor = ColorTranslator.FromHtml("#4FFFEA");
            btnRegister.ForeColor = ColorTranslator.FromHtml("#07161C");
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Height = 52;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.Cursor = Cursors.Hand;

            btnRegister.MouseEnter += (s, e) =>
                btnRegister.BackColor = ColorTranslator.FromHtml("#29C7B8");
            btnRegister.MouseLeave += (s, e) =>
                btnRegister.BackColor = ColorTranslator.FromHtml("#4FFFEA");

            if (btnBackToLogin != null)
            {
                btnBackToLogin.Visible = true;
                btnBackToLogin.BackColor = ColorTranslator.FromHtml("#031A22");
                btnBackToLogin.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
                btnBackToLogin.FlatStyle = FlatStyle.Flat;
                btnBackToLogin.FlatAppearance.BorderSize = 1;
                btnBackToLogin.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#7C5CFF");
                btnBackToLogin.Height = 40;
                btnBackToLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                btnBackToLogin.Cursor = Cursors.Hand;

                btnBackToLogin.MouseEnter += (s, e) =>
                {
                    btnBackToLogin.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
                    btnBackToLogin.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
                };
                btnBackToLogin.MouseLeave += (s, e) =>
                {
                    btnBackToLogin.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
                    btnBackToLogin.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#7C5CFF");
                };
            }

            foreach (var p in inputPanels)
            {
                StyleInputPanel(p);
                p.Paint -= DrawNeonBorder;
                p.Paint += DrawNeonBorder;
            }

            if (pulseTimer == null)
            {
                pulseTimer = new Timer { Interval = 40 };
                pulseTimer.Tick += (s, e) =>
                {
                    pulse += pulseUp ? 0.02f : -0.02f;
                    if (pulse >= 1f) pulseUp = false;
                    if (pulse <= 0f) pulseUp = true;

                    int r = 79 + (int)(pulse * 10);
                    int g = 255 - (int)(pulse * 20);
                    int b = 234 - (int)(pulse * 8);

                    btnRegister.BackColor = Color.FromArgb(r, g, b);
                };
                pulseTimer.Start();
            }
        }

        public static Panel ApplyRuntimeTweaks(
            Form form,
            Panel pnlCard,
            Panel shadow,
            Control lblTitle,
            Panel pnlUsername,
            Panel pnlEmail,
            Panel pnlPassword,
            Panel pnlFirstName,
            Panel pnlLastName,
            Panel pnlAge,
            Panel pnlContact,
            Button btnRegister,
            Button btnBackToLogin,
            TextBox txtUsername,
            TextBox txtEmail,
            TextBox txtPassword,
            TextBox txtFirstName,
            TextBox txtLastName,
            TextBox txtAge,
            TextBox txtContact)
        {
            pnlCard.Width = (int)(form.ClientSize.Width * 0.62);
            pnlCard.Height = (int)(form.ClientSize.Height * 0.75);
            if (pnlCard.Width < 760) pnlCard.Width = 760;
            if (pnlCard.Height < 580) pnlCard.Height = 580;

            CenterCard(form, pnlCard);
            ApplyRoundedCorners(pnlCard, radius: 36);

            shadow = EnsureShadow(form, pnlCard, shadow);
            UpdateShadow(pnlCard, shadow);

            pnlCard.BackColor = ColorTranslator.FromHtml("#07161C");
            pnlCard.Paint -= DrawHudCard;
            pnlCard.Paint += DrawHudCard;

            int sidePad = 65;
            int fullWidth = pnlCard.Width - (sidePad * 2);

            int colGap = 12;
            int colWidth = (fullWidth - colGap) / 2;

            Panel[] fullPanels = { pnlUsername, pnlEmail, pnlPassword };
            Panel[] leftPanels = { pnlFirstName, pnlAge };
            Panel[] rightPanels = { pnlLastName, pnlContact };

            foreach (var p in fullPanels)
            {
                p.Width = fullWidth;
                p.Height = 52;
                p.Left = sidePad;
            }

            for (int i = 0; i < leftPanels.Length; i++)
            {
                leftPanels[i].Width = colWidth;
                leftPanels[i].Height = 52;
                leftPanels[i].Left = sidePad;

                rightPanels[i].Width = colWidth;
                rightPanels[i].Height = 52;
                rightPanels[i].Left = sidePad + colWidth + colGap;
            }

            btnRegister.Width = fullWidth;
            btnRegister.Height = 52;
            btnRegister.Left = sidePad;

            btnBackToLogin.Visible = true;
            btnBackToLogin.Width = fullWidth;
            btnBackToLogin.Left = sidePad;

            // ===== TITLE FULL-WIDTH + TALLER FIX =====
            int titleMarginLR = 26;
            int titleTop = 8;

            // ✅ taller height to avoid cutouts
            int titleHeight = 118;

            if (lblTitle is Label titleLabel)
            {
                titleLabel.AutoSize = false;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                titleLabel.BorderStyle = BorderStyle.None;
                titleLabel.BackColor = Color.Transparent;

                titleLabel.Text = "SPACE INVADERS\r\nREGISTRATION";

                // ✅ add vertical breathing room
                titleLabel.Padding = new Padding(titleMarginLR, 6, titleMarginLR, 6);
            }

            lblTitle.Left = titleMarginLR;
            lblTitle.Top = titleTop;
            lblTitle.Width = pnlCard.Width - (titleMarginLR * 2);
            lblTitle.Height = titleHeight;
            // ===== END TITLE FIX =====

            // gaps (kept tight)
            int gapTitle = 6;
            int gapField = 6;
            int gapRow = 6;
            int gapButtons = 8;

            int currentTop = lblTitle.Bottom + gapTitle;

            pnlUsername.Top = currentTop;
            currentTop = pnlUsername.Bottom + gapField;

            pnlFirstName.Top = currentTop;
            pnlLastName.Top = currentTop;
            currentTop = pnlFirstName.Bottom + gapRow;

            pnlEmail.Top = currentTop;
            currentTop = pnlEmail.Bottom + gapField;

            pnlPassword.Top = currentTop;
            currentTop = pnlPassword.Bottom + gapRow;

            pnlAge.Top = currentTop;
            pnlContact.Top = currentTop;
            currentTop = pnlAge.Bottom + gapRow;

            btnRegister.Top = currentTop + gapButtons;
            btnBackToLogin.Top = btnRegister.Bottom + 6;

            int bottomPadTarget = 18;
            int leftover = pnlCard.Height - btnBackToLogin.Bottom - bottomPadTarget;
            if (leftover > 0)
            {
                int shiftDown = Math.Min(leftover, 120);
                pnlUsername.Top += shiftDown;
                pnlFirstName.Top += shiftDown;
                pnlLastName.Top += shiftDown;
                pnlEmail.Top += shiftDown;
                pnlPassword.Top += shiftDown;
                pnlAge.Top += shiftDown;
                pnlContact.Top += shiftDown;
                btnRegister.Top += shiftDown;
                btnBackToLogin.Top += shiftDown;
            }

            AlignInPanel(txtUsername, pnlUsername);
            AlignInPanel(txtEmail, pnlEmail);
            AlignInPanel(txtPassword, pnlPassword);
            AlignInPanel(txtFirstName, pnlFirstName);
            AlignInPanel(txtLastName, pnlLastName);
            AlignInPanel(txtAge, pnlAge);
            AlignInPanel(txtContact, pnlContact);

            StyleTextBox(txtUsername);
            StyleTextBox(txtEmail);
            StyleTextBox(txtPassword);
            StyleTextBox(txtFirstName);
            StyleTextBox(txtLastName);
            StyleTextBox(txtAge);
            StyleTextBox(txtContact);

            btnRegister.BringToFront();
            btnBackToLogin.BringToFront();

            return shadow;
        }

        private static void DrawHudCard(object sender, PaintEventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle outer = new Rectangle(1, 1, card.Width - 3, card.Height - 3);
            Rectangle inner = new Rectangle(8, 8, card.Width - 16, card.Height - 16);

            using (LinearGradientBrush depth = new LinearGradientBrush(
                inner,
                Color.FromArgb(255, 8, 26, 34),
                Color.FromArgb(255, 4, 18, 24),
                45f))
            {
                e.Graphics.FillRectangle(depth, inner);
            }

            using (Pen ring = new Pen(Color.FromArgb(170, 79, 255, 234), 3))
                e.Graphics.DrawRectangle(ring, outer);

            using (Pen topLight = new Pen(Color.FromArgb(90, 230, 255, 250), 2))
            {
                e.Graphics.DrawLine(topLight, outer.Left + 2, outer.Top + 2, outer.Right - 2, outer.Top + 2);
                e.Graphics.DrawLine(topLight, outer.Left + 2, outer.Top + 2, outer.Left + 2, outer.Bottom - 2);
            }

            using (Pen bottomShade = new Pen(Color.FromArgb(130, 0, 0, 0), 3))
            {
                e.Graphics.DrawLine(bottomShade, outer.Left + 2, outer.Bottom - 2, outer.Right - 2, outer.Bottom - 2);
                e.Graphics.DrawLine(bottomShade, outer.Right - 2, outer.Top + 2, outer.Right - 2, outer.Bottom - 2);
            }

            int c = 28;
            int o = 6;
            using (Pen corner = new Pen(Color.FromArgb(235, 79, 255, 234), 4))
            {
                e.Graphics.DrawLine(corner, o, o, o + c, o);
                e.Graphics.DrawLine(corner, o, o, o, o + c);

                e.Graphics.DrawLine(corner, card.Width - o - c, o, card.Width - o, o);

                e.Graphics.DrawLine(corner, o, card.Height - o, o + c, card.Height - o);
                e.Graphics.DrawLine(corner, o, card.Height - o - c, o, card.Height - o);

                e.Graphics.DrawLine(corner, card.Width - o - c, card.Height - o, card.Width - o, card.Height - o);
                e.Graphics.DrawLine(corner, card.Width - o, card.Height - o - c, card.Width - o, card.Height - o);
            }

            using (SolidBrush haze = new SolidBrush(Color.FromArgb(10, 124, 92, 255)))
                e.Graphics.FillRectangle(haze, inner);
        }

        private static void StyleInputPanel(Panel p)
        {
            p.BackColor = ColorTranslator.FromHtml("#031A22");
            p.Padding = new Padding(12, 0, 12, 0);
        }

        private static void StyleTextBox(TextBox t)
        {
            t.BorderStyle = BorderStyle.None;
            t.BackColor = ColorTranslator.FromHtml("#031A22");
            t.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            t.Font = new Font("Segoe UI", 12F);
        }

        private static void DrawNeonBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;

            using (Pen pen = new Pen(ColorTranslator.FromHtml("#4FFFEA"), 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        private static void AlignInPanel(TextBox tb, Panel p)
        {
            tb.AutoSize = false;
            tb.Height = 27;
            tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            tb.Top = (p.Height - tb.Height) / 2;
            tb.Left = p.Padding.Left;

            int w = p.ClientSize.Width - p.Padding.Horizontal;
            if (w > 0) tb.Width = w;
        }

        private static void ApplyRoundedCorners(Panel pnlCard, int radius = 20)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new Rectangle(pnlCard.Width - radius, 0, radius, radius), 270, 90);
                path.AddArc(new Rectangle(pnlCard.Width - radius, pnlCard.Height - radius, radius, radius), 0, 90);
                path.AddArc(new Rectangle(0, pnlCard.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();
                pnlCard.Region = new Region(path);
            }
        }

        private static void CenterCard(Form form, Panel pnlCard)
        {
            pnlCard.Left = (form.ClientSize.Width - pnlCard.Width) / 2;
            pnlCard.Top = (form.ClientSize.Height - pnlCard.Height) / 2;
            pnlCard.Top -= 20;
            if (pnlCard.Top < 20) pnlCard.Top = 20;
        }

        private static Panel EnsureShadow(Form form, Panel pnlCard, Panel shadow)
        {
            if (shadow == null)
            {
                shadow = new Panel
                {
                    Size = pnlCard.Size,
                    BackColor = Color.FromArgb(130, 0, 0, 0),
                    Enabled = false
                };
                form.Controls.Add(shadow);
                shadow.SendToBack();
            }
            return shadow;
        }

        private static void UpdateShadow(Panel pnlCard, Panel shadow)
        {
            if (shadow == null) return;
            shadow.Size = pnlCard.Size;
            shadow.Location = new Point(pnlCard.Left + 10, pnlCard.Top + 10);
            shadow.SendToBack();
            pnlCard.BringToFront();
        }

        public static void SetPlaceholder(TextBox tb, string placeholder, bool isPassword = false)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.FromArgb(120, 180, 165);
            tb.UseSystemPasswordChar = false;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
                    if (isPassword) tb.UseSystemPasswordChar = true;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = Color.FromArgb(120, 180, 165);
                    if (isPassword) tb.UseSystemPasswordChar = false;
                }
            };
        }
    }
}
