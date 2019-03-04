using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menus {
    public class VerticalMenu<T> : AMenu<T> {
        public VerticalMenu(Control control, SizeF tabSize) : base(control, tabSize) => _tabType = typeof(VerticalTab<T>);
        public VerticalMenu(Control control, SizeF tabSize, Type tabType) : base(control, tabSize, tabType) { }

        protected internal override void Draw(Graphics g) {
            base.Draw(g);

            int y = 0;
            foreach (ATab<T> tab in tabList) {
                tab.Draw(g, tabSize, new PointF(0, y), _tabFont ?? defaultFont, _textColor ?? defaultTextColor, _tabColor ?? defaultTabColor, _borderColor ?? defaultBorderColor, _borderWidth);
                y += (int)tabSize.Height;
            }
        }

        protected internal override void Click(Point location) {
            int index = (int)(location.Y / tabSize.Height);

            ChangeTab(index);
        }
    }
}
