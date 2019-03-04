using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menus {
    /// <summary>
    /// Represents a tab in the menu
    /// </summary>
    /// <typeparam name="T">The type of data stored</typeparam>
    public abstract class ATab<T> {
        /// <summary>
        /// The name of the tab
        /// </summary>
        protected internal string tabName;
        /// <summary>
        /// The data stored in the tab
        /// </summary>
        protected internal T data;
        /// <summary>
        /// Indicates whether the tab is currently selected
        /// </summary>
        protected internal bool isSelected = false;

        /// <summary>
        /// An empty Constructor used by the activator
        /// </summary>
        protected internal ATab() { }

        /// <summary>
        /// Instantiates a new tab
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data stored in the tab</param>
        protected internal ATab(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        /// <summary>
        /// Sets the tab name and the tab data
        /// </summary>
        /// <param name="tabName">The tab name</param>
        /// <param name="data">The data in the tab</param>
        protected internal virtual void SetInformation(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        /// <summary>
        /// Selects the tab
        /// </summary>
        /// <returns></returns>
        protected internal virtual T Select() {
            isSelected = true;
            return data;
        }

        /// <summary>
        /// Deselects the tab
        /// </summary>
        protected internal virtual void Deselect() => isSelected = false;

        /// <summary>
        /// Draws the tab border and text
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tabSize">The size of the tab</param>
        /// <param name="location">The location of the tab</param>
        /// <param name="textFont">The font used for the tab</param>
        /// <param name="textColor">The color for the text</param>
        /// <param name="tabColor">The color for the tab</param>
        /// <param name="borderColor">The color for the border</param>
        /// <param name="borderWidth">The width of the border</param>
        protected internal virtual void Draw(Graphics g, SizeF tabSize, PointF location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            // Create a rectangle for the tab
            using (SolidBrush tabBrush = new SolidBrush(tabColor))
                g.FillRectangle(tabBrush, new RectangleF(location, tabSize));

            // Draw a border around the tab
            using (Pen pen = new Pen(borderColor, borderWidth))
                g.DrawRectangle(pen, location.X, location.Y, tabSize.Width, tabSize.Height);

            // Draw the text of the tab
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                SizeF tabNameSize = g.MeasureString(tabName, textFont);
                PointF tabNamePoint = new PointF((tabSize.Width - tabNameSize.Width) / 2 + location.X, (tabSize.Height - tabNameSize.Height) / 2 + location.Y);

                g.DrawString(tabName, textFont, textBrush, tabNamePoint);
            }
        }
    }
}
