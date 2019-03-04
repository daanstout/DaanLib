using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menus {
    /// <summary>
    /// A horizontal tab that is meant to be put above the application
    /// </summary>
    /// <typeparam name="T">The type of data stored</typeparam>
    public class HorizontalTab<T> : ATab<T> {
        /// <summary>
        /// An empty constructor
        /// </summary>
        public HorizontalTab() : base() { }

        /// <summary>
        /// Instantiates a new tab
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data stored in the tab</param>
        public HorizontalTab(string tabName, T data) : base(tabName, data) { }

        /// <summary>
        /// Draws the tab
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tabSize">The size of the tab</param>
        /// <param name="location">The location of the tab</param>
        /// <param name="textFont">The font used for the text</param>
        /// <param name="textColor">The color of the text</param>
        /// <param name="tabColor">The color of the tab</param>
        /// <param name="borderColor">The color of the border</param>
        /// <param name="borderWidth">The width of the border</param>
        protected internal override void Draw(Graphics g, SizeF tabSize, PointF location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            base.Draw(g, tabSize, location, textFont, textColor, tabColor, borderColor, borderWidth);

            // If the current tab is selected, remove the border below the tab to indicate as such
            if (isSelected)
                using (Pen pen = new Pen(tabColor, borderWidth))
                    // Xstart = the x location of the tab + the border width
                    // Ystart = the y location of the tab + the height
                    // Xend = the x location of the tab + the width - the border width
                    // Yend = the y location of the tab + the height
                    g.DrawLine(pen, location.X + borderWidth, location.Y + tabSize.Height, location.X + tabSize.Width - borderWidth, location.Y + tabSize.Height);
        }
    }
}
