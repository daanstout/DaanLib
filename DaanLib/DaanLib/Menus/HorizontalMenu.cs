using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menus {
    /// <summary>
    /// A horizontal menu, where the tabs are next to eachother
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tabs</typeparam>
    public class HorizontalMenu<T> : AMenu<T> {
        /// <summary>
        /// Instantiates a new menu with the horizontal tab as the default tab type
        /// </summary>
        /// <param name="control">The parent panel of the menu</param>
        /// <param name="tabSize">The size of a tab</param>
        public HorizontalMenu(Control control, SizeF tabSize) : base(control, tabSize) => _tabType = typeof(HorizontalTab<T>);

        /// <summary>
        /// Instantiates a new menu
        /// </summary>
        /// <param name="control">The parent panel of the menu</param>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="tabType">The type of tab used by the menu</param>
        public HorizontalMenu(Control control, SizeF tabSize, Type tabType) : base(control, tabSize, tabType) { }

        /// <summary>
        /// Draws the  menu
        /// </summary>
        /// <param name="g">The graphics instance used for drawing</param>
        protected internal override void Draw(Graphics g) {
            // Let the base class draw the border
            base.Draw(g);

            // The current x-position
            int x = 0;
            // Foreach tab, draw it and increment the x-position
            foreach(ATab<T> tab in tabList) {
                tab.Draw(g, tabSize, new PointF(x, 0), _tabFont ?? defaultFont, _textColor ?? defaultTextColor, _tabColor ?? defaultTabColor, _borderColor ?? defaultBorderColor, _borderWidth);
                x += (int)tabSize.Width;
            }
        }

        /// <summary>
        /// Handles when the user clicks on a new tab
        /// </summary>
        /// <param name="location">The location of the click</param>
        protected internal override void Click(Point location) {
            // Calculate the index of the tab
            int index = (int)(location.X / tabSize.Width);

            // Update the tab
            ChangeTab(index);
        }
    }
}
