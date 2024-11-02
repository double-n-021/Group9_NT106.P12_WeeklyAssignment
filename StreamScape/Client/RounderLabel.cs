using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal class RounderLabel: Label
    {
        public int BorderRadius { get; set; } = 15; // Độ bo góc mặc định

        protected override void OnPaint(PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                // Vẽ hình chữ nhật với độ bo góc
                path.StartFigure();
                path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
                path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
                path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
                path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
            base.OnPaint(e);
        }
    }
}
