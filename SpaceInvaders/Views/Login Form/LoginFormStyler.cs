using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SpaceInvaders
{
    public static class LoginFormStyler
    {
        private static Timer pulseTimer;
        private static float pulse = 0f;
        private static bool pulseUp = true;

        public static void SetupStaticUI(
            Button btnLogin,
            Label lblRegister,
            Panel panelUsername,
            Panel panelPass)
        {
            // Login button
            btnLogin.BackColor = ColorTranslator.FromHtml("#4FFFEA");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#07161C");
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Height = 52;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;

            btnLogin.MouseEnter += (s, e) =>
                btnLogin.BackColor = ColorTranslator.FromHtml("#29C7B8");
            btnLogin.MouseLeave += (s, e) =>
                btnLogin.BackColor = ColorTranslator.FromHtml("#4FFFEA");

            // Input panels
            StyleInputPanel(panelUsername);
            StyleInputPanel(panelPass);

            panelUsername.Paint -= DrawNeonBorder;
            panelPass.Paint -= DrawNeonBorder;
            panelUsername.Paint += DrawNeonBorder;
            panelPass.Paint += DrawNeonBorder;

            // Register link
            lblRegister.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            lblRegister.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            lblRegister.MouseEnter += (s, e) =>
                lblRegister.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            lblRegister.MouseLeave += (s, e) =>
                lblRegister.ForeColor = ColorTranslator.FromHtml("#9AD7CF");

            // Soft pulse on button
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

                    btnLogin.BackColor = Color.FromArgb(r, g, b);
                };
                pulseTimer.Start();
            }
        }

        public static Panel ApplyRuntimeTweaks(
            Form form,
            Panel pnlCard,
            Panel shadow,
            Control lblTitle,
            Panel panelUsername,
            Panel panelPass,
            Button btnLogin,
            Label lblRegister,
            TextBox txtUsername,
            TextBox txtPassword,
            Label ForgotPasswordlbl)
        {
            // Card sizing
            pnlCard.Width = (int)(form.ClientSize.Width * 0.62);
            pnlCard.Height = (int)(form.ClientSize.Height * 0.52);
            if (pnlCard.Width < 700) pnlCard.Width = 700;
            if (pnlCard.Height < 420) pnlCard.Height = 420;

            CenterCard(form, pnlCard);

            ApplyRoundedCorners(pnlCard, radius: 28);

            shadow = EnsureShadow(form, pnlCard, shadow);
            UpdateShadow(pnlCard, shadow);

            pnlCard.BackColor = ColorTranslator.FromHtml("#07161C");
            pnlCard.Paint -= DrawHudCard;
            pnlCard.Paint += DrawHudCard;

            // Title block (same design)
            int titleMarginLR = 22;
            int titleMarginTop = 10;
            int titleHeaderHeight = 88;
            float titleFontSize = 24F;
            string titleFontFamily = "Bahnschrift SemiBold";

            if (lblTitle is Label titleLabel)
            {
                titleLabel.BorderStyle = BorderStyle.None;
                titleLabel.BackColor = Color.Transparent;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;

                titleLabel.Padding = new Padding(titleMarginLR, 0, titleMarginLR, 0);
                titleLabel.Font = new Font(titleFontFamily, titleFontSize, FontStyle.Bold);

                titleLabel.AutoSize = false;
            }

            lblTitle.Top = titleMarginTop;
            lblTitle.Left = titleMarginLR;
            lblTitle.Width = pnlCard.Width - (titleMarginLR * 2);
            lblTitle.Height = titleHeaderHeight;

            // Links
            ForgotPasswordlbl.BackColor = Color.Transparent;
            lblRegister.BackColor = Color.Transparent;

            ForgotPasswordlbl.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            ForgotPasswordlbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            lblRegister.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            lblRegister.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            int sidePad = 65;
            int fullWidth = pnlCard.Width - (sidePad * 2);

            panelUsername.Width = fullWidth;
            panelUsername.Height = 52;
            panelPass.Width = fullWidth;
            panelPass.Height = 52;
            btnLogin.Width = fullWidth;
            btnLogin.Height = 52;

            int gap1 = 12;
            int gap2 = 10;
            int gap3 = 6;
            int gap4 = 10;
            int gap5 = 8;

            panelUsername.Left = sidePad;
            panelUsername.Top = lblTitle.Bottom + gap1;

            panelPass.Left = sidePad;
            panelPass.Top = panelUsername.Bottom + gap2;

            ForgotPasswordlbl.Left = sidePad;
            ForgotPasswordlbl.Top = panelPass.Bottom + gap3;

            btnLogin.Left = sidePad;
            btnLogin.Top = ForgotPasswordlbl.Bottom + gap4;

            lblRegister.Left = (pnlCard.Width - lblRegister.Width) / 2;
            lblRegister.Top = btnLogin.Bottom + gap5 + 8;

            int bottomPadTarget = 18;
            int currentBottomPad = pnlCard.Height - lblRegister.Bottom;

            if (currentBottomPad > bottomPadTarget)
            {
                int shiftDown = currentBottomPad - bottomPadTarget;
                shiftDown = Math.Min(shiftDown, 80);

                panelUsername.Top += shiftDown;
                panelPass.Top += shiftDown;
                ForgotPasswordlbl.Top += shiftDown;
                btnLogin.Top += shiftDown;
                lblRegister.Top += shiftDown;
            }

            int maxBottom = pnlCard.Height - bottomPadTarget;
            if (lblRegister.Bottom > maxBottom)
            {
                int pullUp = lblRegister.Bottom - maxBottom;
                panelUsername.Top -= pullUp;
                panelPass.Top -= pullUp;
                ForgotPasswordlbl.Top -= pullUp;
                btnLogin.Top -= pullUp;
                lblRegister.Top -= pullUp;
            }

            AlignInPanel(txtUsername, panelUsername);
            AlignInPanel(txtPassword, panelPass);
            StyleTextBox(txtUsername);
            StyleTextBox(txtPassword);

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

            using (Pen ring = new Pen(Color.FromArgb(140, 79, 255, 234), 2))
            {
                e.Graphics.DrawRectangle(ring, outer);
            }

            using (Pen topLight = new Pen(Color.FromArgb(80, 230, 255, 250), 2))
            {
                e.Graphics.DrawLine(topLight, outer.Left + 2, outer.Top + 2, outer.Right - 2, outer.Top + 2);
                e.Graphics.DrawLine(topLight, outer.Left + 2, outer.Top + 2, outer.Left + 2, outer.Bottom - 2);
            }

            using (Pen bottomShade = new Pen(Color.FromArgb(120, 0, 0, 0), 3))
            {
                e.Graphics.DrawLine(bottomShade, outer.Left + 2, outer.Bottom - 2, outer.Right - 2, outer.Bottom - 2);
                e.Graphics.DrawLine(bottomShade, outer.Right - 2, outer.Top + 2, outer.Right - 2, outer.Bottom - 2);
            }

            int c = 26;
            int o = 6;
            using (Pen corner = new Pen(Color.FromArgb(220, 79, 255, 234), 3))
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
            {
                e.Graphics.FillRectangle(haze, inner);
            }
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

            using (Pen pen = new Pen(ColorTranslator.FromHtml("#4FFFEA"), 1))
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
    }
}