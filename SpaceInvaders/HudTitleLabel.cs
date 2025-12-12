using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SpaceInvaders
{
    public class HudTitleLabel : Control
    {
        private readonly Timer pulseTimer;
        private float glow = 0f;
        private bool glowUp = true;

        public string Subtitle { get; set; } = "SYSTEM ACCESS // AUTH REQUIRED";

        public HudTitleLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            Font = new Font("Bahnschrift SemiBold", 24f, FontStyle.Bold);
            ForeColor = ColorTranslator.FromHtml("#E6FFF9");
            Size = new Size(560, 100);

            pulseTimer = new Timer { Interval = 40 };
            pulseTimer.Tick += (s, e) =>
            {
                glow += glowUp ? 0.03f : -0.03f;
                if (glow >= 1f) glowUp = false;
                if (glow <= 0f) glowUp = true;
                Invalidate();
            };
            pulseTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // ===== Palette =====
            Color plasmaCyan = ColorTranslator.FromHtml("#4FFFEA");
            Color ionTeal = ColorTranslator.FromHtml("#29C7B8");
            Color voidViolet = ColorTranslator.FromHtml("#7C5CFF");

            // Header plate depth colors
            Color plateTop = ColorTranslator.FromHtml("#0C2A36");
            Color plateMid = ColorTranslator.FromHtml("#071C25");
            Color plateBottom = ColorTranslator.FromHtml("#041118");

            Color glowColor = Blend(plasmaCyan, voidViolet, glow * 0.6f);

            // ===== Measure title =====
            string title = Text ?? "PROJECT XTREME";
            string spaced = string.Join(" ", title.ToCharArray());

            SizeF titleSize = g.MeasureString(spaced, Font);
            float tx = (Width - titleSize.Width) / 2f;
            float ty = 10f;

            // ===== FULL-WIDTH TITLE PLATE (depth + bevel) =====
            int plateInsetX = 8;     // near edge, but safe for glow
            int platePadY = 12;

            Rectangle plate = new Rectangle(
                plateInsetX,
                (int)ty - platePadY + 2,
                Width - plateInsetX * 2,
                (int)titleSize.Height + platePadY * 2 - 6
            );

            using (GraphicsPath platePath = RoundedRect(plate, 7))
            {
                // Base depth gradient
                using (LinearGradientBrush depthBrush = new LinearGradientBrush(
                    plate, plateTop, plateBottom, 90f))
                {
                    // add a mid stop so it feels 3D beveled
                    depthBrush.InterpolationColors = new ColorBlend
                    {
                        Colors = new[] { plateTop, plateMid, plateBottom },
                        Positions = new[] { 0f, 0.55f, 1f }
                    };

                    g.FillPath(depthBrush, platePath);
                }

                // Soft inner shadow rim (inset feel)
                using (Pen innerShadow = new Pen(Color.FromArgb(80, 0, 0, 0), 2f))
                {
                    Rectangle inner = Rectangle.Inflate(plate, -2, -2);
                    using (GraphicsPath innerPath = RoundedRect(inner, 6))
                        g.DrawPath(innerShadow, innerPath);
                }

                // Top bevel highlight
                using (Pen bevelLight = new Pen(Color.FromArgb(70, 255, 255, 255), 2f))
                {
                    g.DrawLine(bevelLight, plate.Left + 6, plate.Top + 2, plate.Right - 6, plate.Top + 2);
                }

                // Bottom bevel shadow
                using (Pen bevelDark = new Pen(Color.FromArgb(120, 0, 0, 0), 3f))
                {
                    g.DrawLine(bevelDark, plate.Left + 8, plate.Bottom - 2, plate.Right - 8, plate.Bottom - 2);
                }

                // Neon outer edge (kept subtle)
                using (Pen plateEdge = new Pen(Color.FromArgb(120, glowColor), 1.4f))
                {
                    g.DrawPath(plateEdge, platePath);
                }
            }

            // ===== Your bracket/line style (same vibe) =====
            int topY = 2;
            int barInset = 24;

            using (Pen topBar = new Pen(Color.FromArgb(180, glowColor), 2f))
            {
                g.DrawLine(topBar, barInset, topY, Width - barInset, topY);
            }

            int wingY = plate.Top + 4;
            int wingLen = 70;
            int wingHeight = 18;
            int wingGap = 10;

            using (Pen wingPen = new Pen(Color.FromArgb(210, glowColor), 2f))
            {
                wingPen.LineJoin = LineJoin.Miter;

                Point[] leftWing =
                {
                    new Point(plate.Left - wingGap - wingLen, wingY),
                    new Point(plate.Left - wingGap, wingY),
                    new Point(plate.Left - wingGap + 10, wingY + wingHeight),
                    new Point(plate.Left - wingGap + 34, wingY + wingHeight)
                };
                g.DrawLines(wingPen, leftWing);

                Point[] rightWing =
                {
                    new Point(plate.Right + wingGap + wingLen, wingY),
                    new Point(plate.Right + wingGap, wingY),
                    new Point(plate.Right + wingGap - 10, wingY + wingHeight),
                    new Point(plate.Right + wingGap - 34, wingY + wingHeight)
                };
                g.DrawLines(wingPen, rightWing);
            }

            using (Pen tickPen = new Pen(Color.FromArgb(160, plasmaCyan), 2f))
            {
                int tickX1 = (int)tx - 6;
                int tickX2 = (int)(tx + titleSize.Width + 6);
                g.DrawLine(tickPen, tickX1, topY, tickX1, plate.Top + 2);
                g.DrawLine(tickPen, tickX2, topY, tickX2, plate.Top + 2);
            }

            // ===== Title text (embedded, same as you liked) =====
            using (Brush engraveDark = new SolidBrush(Color.FromArgb(175, 0, 0, 0)))
                g.DrawString(spaced, Font, engraveDark, tx + 1.6f, ty + 1.6f);

            using (Brush innerGlow = new SolidBrush(Color.FromArgb(95, glowColor)))
                g.DrawString(spaced, Font, innerGlow, tx - 0.5f, ty - 0.5f);

            using (Brush fill = new SolidBrush(ForeColor))
                g.DrawString(spaced, Font, fill, tx, ty);

            using (GraphicsPath textPath = new GraphicsPath())
            {
                textPath.AddString(
                    spaced,
                    Font.FontFamily,
                    (int)Font.Style,
                    g.DpiY * Font.Size / 72,
                    new PointF(tx, ty),
                    StringFormat.GenericDefault
                );

                using (Pen stroke = new Pen(Color.FromArgb(160, glowColor), 1.2f))
                {
                    stroke.LineJoin = LineJoin.Round;
                    g.DrawPath(stroke, textPath);
                }
            }

            // ===== Subtitle LOWER (as you wanted) =====
            using (Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Brush subBrush = new SolidBrush(Color.FromArgb(190, ionTeal)))
            {
                SizeF subSize = g.MeasureString(Subtitle, subFont);
                float sx = (Width - subSize.Width) / 2f;

                float sy = plate.Bottom + 8f; // lowered
                g.DrawString(Subtitle, subFont, subBrush, sx, sy);
            }

            // Divider line (same style)
            int lineY = plate.Bottom + 24;
            using (Pen linePen = new Pen(Color.FromArgb(140, plasmaCyan), 1.1f))
            {
                g.DrawLine(linePen, Width * 0.28f, lineY, Width * 0.72f, lineY);
            }
        }

        private GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.Left, r.Top, radius, radius, 180, 90);
            p.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
            p.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            p.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
            p.CloseFigure();
            return p;
        }

        private Color Blend(Color a, Color b, float t)
        {
            t = Math.Max(0, Math.Min(1, t));
            int r = (int)(a.R + (b.R - a.R) * t);
            int g = (int)(a.G + (b.G - a.G) * t);
            int bl = (int)(a.B + (b.B - a.B) * t);
            return Color.FromArgb(r, g, bl);
        }
    }
}
