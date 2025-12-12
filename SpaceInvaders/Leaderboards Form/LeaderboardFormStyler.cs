// LeaderboardsFormStyler.cs  (FIXED: DataGridView GridColor no transparency)
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public static class LeaderboardsFormStyler
    {
        private static readonly Color Neon = ColorTranslator.FromHtml("#4FFFEA");
        private static readonly Color HudDark = ColorTranslator.FromHtml("#031A22");
        private static readonly Color CardDark = ColorTranslator.FromHtml("#07161C");
        private static readonly Color TextSoft = ColorTranslator.FromHtml("#E6FFF9");
        private static readonly Color TextMuted = ColorTranslator.FromHtml("#9AD7CF");

        public static void SetupStaticUI(
            Panel pnlCard, Panel pnlHeader, Panel pnlTabs, Panel pnlGrid, Panel pnlTop3, Panel pnlFooter,
            Label lblTitle, Label lblSubtitle, Label lblTop3Header,
            Button btnBack, Button btnRefresh,
            Button btnTabXP, Button btnTabSQ1, Button btnTabSQ2, Button btnTabSQ3,
            DataGridView dgv,
            Label top1Rank, Label top1Name, Label top1Score,
            Label top2Rank, Label top2Name, Label top2Score,
            Label top3Rank, Label top3Name, Label top3Score,
            Label lblScope, ComboBox cmbScope, Label lblSearch, TextBox txtSearch,
            Label lblCount, Label lblLastSync)
        {
            // Card
            pnlCard.BackColor = CardDark;
            pnlCard.Paint -= DrawHudCard;
            pnlCard.Paint += DrawHudCard;

            StyleHudPanel(pnlHeader);
            StyleHudPanel(pnlTabs);
            StyleHudPanel(pnlGrid);
            StyleHudPanel(pnlTop3);
            StyleHudPanel(pnlFooter);

            // Headers
            lblTitle.ForeColor = Neon;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);

            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            lblTop3Header.ForeColor = Neon;
            lblTop3Header.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Buttons
            StylePrimaryButton(btnBack);
            btnBack.Text = "RETURN";

            StylePrimaryButton(btnRefresh);
            btnRefresh.Text = "REFRESH";

            StyleTabButton(btnTabXP);
            StyleTabButton(btnTabSQ1);
            StyleTabButton(btnTabSQ2);
            StyleTabButton(btnTabSQ3);

            // Default active tab
            SetActiveTab(btnTabXP, btnTabSQ1, btnTabSQ2, btnTabSQ3, (object)0);

            // Grid
            StyleLeaderboardGrid(dgv);

            // Top 3 labels
            StyleTopRankLabel(top1Rank, 15F);
            StyleTopNameLabel(top1Name, 14F);
            StyleTopScoreLabel(top1Score, 13F);

            StyleTopRankLabel(top2Rank, 14F);
            StyleTopNameLabel(top2Name, 13F);
            StyleTopScoreLabel(top2Score, 12F);

            StyleTopRankLabel(top3Rank, 14F);
            StyleTopNameLabel(top3Name, 13F);
            StyleTopScoreLabel(top3Score, 12F);

            // Footer
            lblScope.ForeColor = TextMuted;
            lblScope.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            cmbScope.BackColor = HudDark;
            cmbScope.ForeColor = TextSoft;
            cmbScope.FlatStyle = FlatStyle.Flat;
            cmbScope.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            lblSearch.ForeColor = TextMuted;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            txtSearch.BackColor = Color.FromArgb(4, 18, 24);
            txtSearch.ForeColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);

            lblCount.ForeColor = Color.White;
            lblCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            lblLastSync.ForeColor = TextMuted;
            lblLastSync.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        public static Panel ApplyRuntimeLayout(
            Form form,
            Panel pnlCard,
            Panel shadow,
            Panel pnlHeader,
            Panel pnlTabs,
            Panel pnlMain,
            Panel pnlFooter,
            Panel pnlTop3)
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

            int podiumW = Scale(form, 260, 340);
            pnlTop3.Width = podiumW;

            return shadow;
        }

        public static void SetActiveTab(
            Button btnXP, Button btnSQ1, Button btnSQ2, Button btnSQ3, object activeEnum)
        {
            int active = Convert.ToInt32(activeEnum);

            Button[] tabs = { btnXP, btnSQ1, btnSQ2, btnSQ3 };
            for (int i = 0; i < tabs.Length; i++)
            {
                if (tabs[i] == null) continue;

                bool isActive = i == active;
                tabs[i].BackColor = isActive ? Color.FromArgb(10, 60, 70) : HudDark;
                tabs[i].ForeColor = isActive ? Neon : TextSoft;
                tabs[i].FlatAppearance.BorderSize = isActive ? 2 : 1;
            }
        }

        // =========================
        // STYLE HELPERS
        // =========================

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

        private static void StyleTabButton(Button b)
        {
            if (b == null) return;
            b.BackColor = HudDark;
            b.ForeColor = TextSoft;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Neon;
            b.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.TextAlign = ContentAlignment.MiddleCenter;

            b.Paint -= DrawFileButtonNotch;
            b.Paint += DrawFileButtonNotch;
        }

        private static void StyleLeaderboardGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = HudDark;
            dgv.BorderStyle = BorderStyle.None;

            // FIX: GridColor must be fully opaque (alpha 255)
            dgv.GridColor = Neon;  // was Color.FromArgb(40, Neon)

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(4, 18, 24);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 79, 255, 234);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = HudDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Neon;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 34;

            dgv.RowTemplate.Height = 30;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleTopRankLabel(Label lbl, float size)
        {
            if (lbl == null) return;
            lbl.ForeColor = Neon;
            lbl.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
        }

        private static void StyleTopNameLabel(Label lbl, float size)
        {
            if (lbl == null) return;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
        }

        private static void StyleTopScoreLabel(Label lbl, float size)
        {
            if (lbl == null) return;
            lbl.ForeColor = TextMuted;
            lbl.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
        }

        private static void DrawFileButtonNotch(object sender, PaintEventArgs e)
        {
            Button b = sender as Button;
            if (b == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Point[] notch =
            {
                new Point(0,0),
                new Point(26,0),
                new Point(0,26)
            };

            using (SolidBrush br = new SolidBrush(ColorTranslator.FromHtml("#0C3B44")))
                e.Graphics.FillPolygon(br, notch);
            using (Pen pn = new Pen(Neon, 1))
                e.Graphics.DrawPolygon(pn, notch);
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
