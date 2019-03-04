using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menus {
    public class VerticalTab<T> : ATab<T> {
        public VerticalTab() : base() { }

        public VerticalTab(string tabName, T data) : base(tabName, data) { }

        protected internal override void Draw(Graphics g, SizeF tabSize, PointF location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            base.Draw(g, tabSize, location, textFont, textColor, tabColor, borderColor, borderWidth);

            if (isSelected)
                using (Pen pen = new Pen(tabColor, borderWidth))
                    g.DrawLine(pen, location.X, location.Y, location.X, location.Y + tabSize.Height);
        }
    }
}
