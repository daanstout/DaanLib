using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menus {
    public abstract class ATab<T> {
        protected internal readonly string tabName;
        protected internal readonly T data;
        protected internal bool isSelected;

        protected internal ATab(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        protected internal virtual T Select() {
            isSelected = true;
            return data;
        }

        protected internal virtual void Deselect() => isSelected = false;

        protected internal virtual void Draw(Graphics g, SizeF tabSize, PointF location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            using (SolidBrush tabBrush = new SolidBrush(tabColor))
                g.FillRectangle(tabBrush, new RectangleF(location, tabSize));

            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                SizeF tabNameSize = g.MeasureString(tabName, textFont);
                PointF tabNamePoint = new PointF((tabSize.Width - tabNameSize.Width) / 2 + location.X, (tabSize.Height - tabNameSize.Height) / 2 + location.Y);

                g.DrawString(tabName, textFont, textBrush, tabNamePoint);
            }
        }
    }
}
