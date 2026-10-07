using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EbootExpress
{
    public sealed class ThemedProgressBar : Control
    {
        private int minimum;
        private int maximum = 100;
        private int value;

        public ThemedProgressBar()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TrackColor = Color.FromArgb(13, 22, 35);
            ProgressColor = Color.FromArgb(42, 211, 193);
            ProgressTextColor = Color.FromArgb(229, 237, 247);
            ShowPercentage = true;
        }

        internal int Minimum
        {
            get { return minimum; }
            set
            {
                if (value > maximum)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                minimum = value;
                if (this.value < minimum)
                {
                    this.value = minimum;
                }
                Invalidate();
            }
        }

        internal int Maximum
        {
            get { return maximum; }
            set
            {
                if (value < minimum)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                maximum = value;
                if (this.value > maximum)
                {
                    this.value = maximum;
                }
                Invalidate();
            }
        }

        internal int Value
        {
            get { return value; }
            set
            {
                if (value < minimum || value > maximum)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                this.value = value;
                Invalidate();
            }
        }

        public Color TrackColor { get; set; }
        public Color ProgressColor { get; set; }
        public Color ProgressTextColor { get; set; }
        internal bool ShowPercentage { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 4 || Height < 4)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle bounds = ClientRectangle;
            bounds.Inflate(-1, -1);
            int cornerRadius = Math.Max(2, Math.Min(6, bounds.Height / 2));

            using (GraphicsPath trackPath = CreateRoundedRectangle(bounds, cornerRadius))
            using (SolidBrush trackBrush = new SolidBrush(TrackColor))
            using (SolidBrush progressBrush = new SolidBrush(ProgressColor))
            {
                e.Graphics.FillPath(trackBrush, trackPath);
                if (maximum > minimum && value > minimum)
                {
                    float percent = (value - minimum) / (float)(maximum - minimum);
                    int fillWidth = (int)Math.Round(bounds.Width * percent);
                    if (fillWidth > 0)
                    {
                        GraphicsState state = e.Graphics.Save();
                        e.Graphics.SetClip(trackPath);
                        e.Graphics.FillRectangle(progressBrush,
                            bounds.X, bounds.Y, fillWidth, bounds.Height);
                        e.Graphics.Restore(state);
                    }
                }
            }

            if (ShowPercentage)
            {
                int percent = maximum == minimum
                    ? 100
                    : (int)Math.Round((value - minimum) * 100.0 / (maximum - minimum));
                TextRenderer.DrawText(e.Graphics, percent + "%", Font, bounds,
                    ProgressTextColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    | TextFormatFlags.NoPadding);
            }
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
