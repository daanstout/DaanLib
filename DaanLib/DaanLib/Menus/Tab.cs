using DaanLib.Maths;
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
        private bool isSelected;

        protected internal ATab(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        protected internal virtual T Select() {
            isSelected = true;
            return data;
        }

        protected internal virtual void Deselect() => isSelected = false;

        protected internal virtual void Draw(Graphics g, SizeF tabSize, int y, Font textFont, Color? textColor = null, Color? tabColor = null, Color? borderColor = null) {
            textColor = textColor ?? Color.Black;
            tabColor = tabColor ?? Color.White;
            borderColor = borderColor ?? Color.Black;

            using (SolidBrush brush = new SolidBrush((Color)textColor)) {
                SizeF tabNameSize = g.MeasureString(tabName, textFont);
                PointF tabNamePoint = new PointF((tabSize.Width - tabNameSize.Width) / 2, (tabSize.Height - tabNameSize.Height) / 2);

                g.DrawString(tabName, textFont, brush, tabNamePoint);
            }
        }
    }
}
