using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public enum HudMessageBoxButtons
    {
        OK,
        YesNo
    }

    public enum HudMessageBoxIcon
    {
        None,
        Info,
        Warning,
        Error,
        Success
    }

    public class HudMessageBox : Form
    {
        private Label lblTitle;
        private Label lblMessage;
        private Button btnPrimary;
        private Button btnSecondary;
        private Panel pnlCard;

        private HudMessageBoxButtons _buttons;

        private HudMessageBox(string title, string message, HudMessageBoxButtons buttons, HudMessageBoxIcon icon)
        {
            _buttons = buttons;

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.Black; // outer shadow
            Opacity = 0.98;
            Size = new Size(520, 240);
            DoubleBuffered = true;
            ShowInTaskbar = false;

            // Card panel
            pnlCard = new Panel
            {
                BackColor = ColorTranslator.FromHtml("#07161C"),
                Location = new Point(8, 8),
                Size = new Size(504, 224)
            };
            pnlCard.Paint += PnlCard_Paint;
            Controls.Add(pnlCard);

            // Title
            lblTitle = new Label
            {
                Text = title,
                ForeColor = ColorTranslator.FromHtml("#E6FFF9"),
                Font = new Font("Bahnschrift SemiBold", 16F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 54
            };

            // Message
            lblMessage = new Label
            {
                Text = message,
                ForeColor = ColorTranslator.FromHtml("#9AD7CF"),
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(28, 6, 28, 6)
            };

            // Buttons
            btnPrimary = new Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Height = 44,
                Width = 160,
                BackColor = ColorTranslator.FromHtml("#4FFFEA"),
                ForeColor = ColorTranslator.FromHtml("#07161C"),
                Text = (buttons == HudMessageBoxButtons.YesNo) ? "Yes" : "OK"
            };
            btnPrimary.MouseEnter += (s, e) => btnPrimary.BackColor = ColorTranslator.FromHtml("#29C7B8");
            btnPrimary.MouseLeave += (s, e) => btnPrimary.BackColor = ColorTranslator.FromHtml("#4FFFEA");
            btnPrimary.Click += (s, e) =>
            {
                DialogResult = (buttons == HudMessageBoxButtons.YesNo) ? DialogResult.Yes : DialogResult.OK;
                Close();
            };

            btnSecondary = new Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 1, BorderColor = ColorTranslator.FromHtml("#7C5CFF") },
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Height = 44,
                Width = 160,
                BackColor = ColorTranslator.FromHtml("#031A22"),
                ForeColor = ColorTranslator.FromHtml("#9AD7CF"),
                Text = "No",
                Visible = (buttons == HudMessageBoxButtons.YesNo)
            };
            btnSecondary.MouseEnter += (s, e) =>
            {
                btnSecondary.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4FFFEA");
                btnSecondary.ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            };
            btnSecondary.MouseLeave += (s, e) =>
            {
                btnSecondary.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#7C5CFF");
                btnSecondary.ForeColor = ColorTranslator.FromHtml("#9AD7CF");
            };
            btnSecondary.Click += (s, e) =>
            {
                DialogResult = DialogResult.No;
                Close();
            };

            // Bottom button bar
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 62,
                Padding = new Padding(0, 6, 0, 10)
            };
            pnlButtons.Controls.Add(btnPrimary);
            pnlButtons.Controls.Add(btnSecondary);

            pnlCard.Controls.Add(lblMessage);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(pnlButtons);

            // Icon accent (optional tint)
            ApplyIconTheme(icon);

            // Center buttons
            pnlButtons.Resize += (s, e) => LayoutButtons(pnlButtons);
            LayoutButtons(pnlButtons);

            // Allow drag by title area
            lblTitle.MouseDown += Drag_MouseDown;
            lblMessage.MouseDown += Drag_MouseDown;

            // Rounded card
            pnlCard.Region = new Region(GetRoundedPath(new Rectangle(0, 0, pnlCard.Width, pnlCard.Height), 22));
            pnlCard.Resize += (s, e) =>
                pnlCard.Region = new Region(GetRoundedPath(new Rectangle(0, 0, pnlCard.Width, pnlCard.Height), 22));
        }

        private void LayoutButtons(Panel pnlButtons)
        {
            int gap = 12;
            int totalW = btnPrimary.Width + (btnSecondary.Visible ? (gap + btnSecondary.Width) : 0);
            int startX = (pnlButtons.Width - totalW) / 2;

            btnPrimary.Left = startX;
            btnPrimary.Top = 6;

            if (btnSecondary.Visible)
            {
                btnSecondary.Left = btnPrimary.Right + gap;
                btnSecondary.Top = 6;
            }
        }

        private void ApplyIconTheme(HudMessageBoxIcon icon)
        {
            // subtle color shifts based on type
            switch (icon)
            {
                case HudMessageBoxIcon.Success:
                    lblTitle.ForeColor = ColorTranslator.FromHtml("#B8FFB1");
                    break;
                case HudMessageBoxIcon.Warning:
                    lblTitle.ForeColor = ColorTranslator.FromHtml("#FFE7A1");
                    break;
                case HudMessageBoxIcon.Error:
                    lblTitle.ForeColor = ColorTranslator.FromHtml("#FFB0B0");
                    break;
                case HudMessageBoxIcon.Info:
                    lblTitle.ForeColor = ColorTranslator.FromHtml("#AEE8FF");
                    break;
            }
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(1, 1, pnlCard.Width - 3, pnlCard.Height - 3);

            using (Pen neon = new Pen(Color.FromArgb(190, 79, 255, 234), 3))
                e.Graphics.DrawRectangle(neon, r);

            // Corner brackets
            int c = 22;
            int o = 6;
            using (Pen corner = new Pen(Color.FromArgb(235, 79, 255, 234), 3))
            {
                e.Graphics.DrawLine(corner, o, o, o + c, o);
                e.Graphics.DrawLine(corner, o, o, o, o + c);

                e.Graphics.DrawLine(corner, pnlCard.Width - o - c, o, pnlCard.Width - o, o);

                e.Graphics.DrawLine(corner, o, pnlCard.Height - o, o + c, pnlCard.Height - o);
                e.Graphics.DrawLine(corner, o, pnlCard.Height - o - c, o, pnlCard.Height - o);

                e.Graphics.DrawLine(corner, pnlCard.Width - o - c, pnlCard.Height - o, pnlCard.Width - o, pnlCard.Height - o);
                e.Graphics.DrawLine(corner, pnlCard.Width - o, pnlCard.Height - o - c, pnlCard.Width - o, pnlCard.Height - o);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Drag support
        private Point _dragStart;
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragStart = e.Location;
            MouseMove += Drag_MouseMove;
            MouseUp += Drag_MouseUp;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _dragStart.X;
            Top += e.Y - _dragStart.Y;
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            MouseMove -= Drag_MouseMove;
            MouseUp -= Drag_MouseUp;
        }

        // ===== Static API =====
        public static DialogResult Show(string message, string title = "NOTICE",
            HudMessageBoxButtons buttons = HudMessageBoxButtons.OK,
            HudMessageBoxIcon icon = HudMessageBoxIcon.None,
            IWin32Window owner = null)
        {
            using (var box = new HudMessageBox(title, message, buttons, icon))
            {
                return owner == null ? box.ShowDialog() : box.ShowDialog(owner);
            }
        }
    }
}
