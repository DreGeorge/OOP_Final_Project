// EditProfileFormStyler.cs
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public static class EditProfileFormStyler
    {
        private static readonly Color Neon = ColorTranslator.FromHtml("#4FFFEA");
        private static readonly Color HudDark = ColorTranslator.FromHtml("#031A22");
        private static readonly Color CardDark = ColorTranslator.FromHtml("#07161C");
        private static readonly Color TextSoft = ColorTranslator.FromHtml("#E6FFF9");
        private static readonly Color TextMuted = ColorTranslator.FromHtml("#9AD7CF");

        public static void SetupStaticUI(
            Panel pnlCard, Panel pnlHeader, Panel pnlLeft, Panel pnlRight, Panel pnlFooter,
            Label lblTitle, Label lblSubtitle,
            Label lblAccountHeader, Label lblSecurityHeader,
            Button btnBack, Button btnSave, Button btnReset,
            Label lblFirstName, TextBox txtFirstName,
            Label lblLastName, TextBox txtLastName,
            Label lblUsername, TextBox txtUsername,
            Label lblSection, TextBox txtSection,
            Label lblYear, TextBox txtYear,
            Label lblContact, TextBox txtContact,
            Label lblOldPass, TextBox txtOldPass,
            Label lblNewPass, TextBox txtNewPass,
            Label lblConfirmPass, TextBox txtConfirmPass,
            Label lblNote, Label lblStatus)
        {
            pnlCard.BackColor = CardDark;
            pnlCard.Paint -= DrawHudCard;
            pnlCard.Paint += DrawHudCard;

            StyleHudPanel(pnlHeader);
            StyleHudPanel(pnlLeft);
            StyleHudPanel(pnlRight);
            StyleHudPanel(pnlFooter);

            lblTitle.ForeColor = Neon;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);

            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            lblAccountHeader.ForeColor = Neon;
            lblAccountHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            lblSecurityHeader.ForeColor = Neon;
            lblSecurityHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            StylePrimaryButton(btnBack);
            btnBack.Text = "RETURN";

            StylePrimaryButton(btnSave);
            btnSave.Text = "SAVE CHANGES";

            StylePrimaryButton(btnReset);
            btnReset.Text = "RESET";

            StyleFieldLabel(lblFirstName);
            StyleFieldBox(txtFirstName);

            StyleFieldLabel(lblLastName);
            StyleFieldBox(txtLastName);

            StyleFieldLabel(lblUsername);
            StyleFieldBox(txtUsername);

            StyleFieldLabel(lblSection);
            StyleFieldBox(txtSection);

            StyleFieldLabel(lblYear);
            StyleFieldBox(txtYear);

            StyleFieldLabel(lblContact);
            StyleFieldBox(txtContact);

            StyleFieldLabel(lblOldPass);
            StyleFieldBox(txtOldPass);

            StyleFieldLabel(lblNewPass);
            StyleFieldBox(txtNewPass);

            StyleFieldLabel(lblConfirmPass);
            StyleFieldBox(txtConfirmPass);

            lblNote.ForeColor = TextMuted;
            lblNote.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);

            lblStatus.ForeColor = Color.White;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        public static Panel ApplyRuntimeLayout(Form form, Panel pnlCard, Panel shadow, Panel pnlRight)
        {
            int outer = Scale(form, 18, 32);

            pnlCard.Width = form.ClientSize.Width - outer * 2;
            pnlCard.Height = form.ClientSize.Height - outer * 2;

            if (pnlCard.Width < 1100) pnlCard.Width = 1100;
            if (pnlCard.Height < 640) pnlCard.Height = 640;

            pnlCard.Left = (form.ClientSize.Width - pnlCard.Width) / 2;
            pnlCard.Top = (form.ClientSize.Height - pnlCard.Height) / 2;

            ApplyRoundedCorners(pnlCard);

            shadow = EnsureShadow(form, pnlCard, shadow);
            UpdateShadow(pnlCard, shadow);

            int rightW = Scale(form, 360, 460);
            pnlRight.Width = rightW;

            return shadow;
        }

        // -------- style helpers --------
        private static void StyleHudPanel(Panel p)
        {
            if (p == null) return;
            p.BackColor = HudDark;
            p.Padding = new Padding(14);
            p.Paint -= DrawNeonBorder;
            p.Paint += DrawNeonBorder;
        }

        private static void StylePrimaryButton(Button b)
        {
            if (b == null) return;
            b.BackColor = HudDark;
            b.ForeColor = TextSoft;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Neon;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        private static void StyleFieldLabel(Label l)
        {
            if (l == null) return;
            l.ForeColor = TextMuted;
            l.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            l.BackColor = Color.Transparent;
        }

        private static void StyleFieldBox(TextBox t)
        {
            if (t == null) return;
            t.BackColor = Color.FromArgb(4, 18, 24);
            t.ForeColor = Color.White;
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10F);
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
                e.Graphics.DrawRectangle(ring, outer);
        }

        private static void DrawNeonBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;

            using (Pen pen = new Pen(Neon, 1))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        public static void PaintGradientBackground(Form form, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, form.Width, form.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(6, 10, 25),
                Color.FromArgb(35, 12, 60),
                45f))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private static int Scale(Form form, int min, int max)
        {
            float t = (form.ClientSize.Width - 1100f) / 800f;
            if (t < 0) t = 0;
            if (t > 1) t = 1;
            return (int)(min + (max - min) * t);
        }

        private static void ApplyRoundedCorners(Control c)
        {
            int radius = 22;
            Rectangle r = new Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddArc(r.Left, r.Top, radius, radius, 180, 90);
                gp.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
                gp.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                gp.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
                gp.CloseFigure();
                c.Region = new Region(gp);
            }
        }

        private static Panel EnsureShadow(Form form, Panel card, Panel shadow)
        {
            if (shadow != null && form.Controls.Contains(shadow))
                return shadow;

            shadow = new Panel();
            shadow.BackColor = Color.FromArgb(60, 0, 0, 0);
            shadow.Location = new Point(card.Left + 6, card.Top + 6);
            shadow.Size = card.Size;
            shadow.SendToBack();
            form.Controls.Add(shadow);
            card.BringToFront();
            return shadow;
        }

        private static void UpdateShadow(Panel card, Panel shadow)
        {
            if (shadow == null) return;
            shadow.Location = new Point(card.Left + 6, card.Top + 6);
            shadow.Size = card.Size;
        }
    }
}
