using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menus {
    /// <summary>
    /// A menu used in a panel to display different things
    /// </summary>
    /// <typeparam name="T">The type of object the tabs store</typeparam>
    public abstract class AMenu<T> {
        /// <summary>
        /// The default color of the text - Black
        /// </summary>
        protected internal virtual Color defaultTextColor => Color.Black;
        /// <summary>
        /// The default color of the tab - White
        /// </summary>
        protected internal virtual Color defaultTabColor => Color.White;
        /// <summary>
        /// The default color of the border - Black
        /// </summary>
        protected internal virtual Color defaultBorderColor => Color.Black;
        /// <summary>
        /// The default font used for the text - Arial at size 12
        /// </summary>
        protected internal virtual Font defaultFont => new Font("Arial", 12);

        /// <summary>
        /// The tabs in the menu
        /// </summary>
        protected internal readonly List<ATab<T>> tabList;
        /// <summary>
        /// The size of a tab
        /// </summary>
        protected internal readonly SizeF tabSize;
        /// <summary>
        /// The parent panel of the menu
        /// </summary>
        protected internal Panel panel;
        /// <summary>
        /// The current tab
        /// </summary>
        protected internal int current = -1;

        /// <summary>
        /// The color of the text
        /// </summary>
        protected internal Color? _textColor;
        /// <summary>
        /// The color of the tab
        /// </summary>
        protected internal Color? _tabColor;
        /// <summary>
        /// The color of the border
        /// </summary>
        protected internal Color? _borderColor;
        /// <summary>
        /// The font for the text
        /// </summary>
        protected internal Font _tabFont;

        /// <summary>
        /// The type of tab that is used in the menu
        /// </summary>
        protected internal Type _tabType;

        /// <summary>
        /// The width of the border
        /// </summary>
        protected internal int _borderWidth = 2;

        /// <summary>
        /// The type of click used to switch tabs
        /// </summary>
        protected internal MouseModes currentMouseMode { get; private set; } = MouseModes.mouseUp;

        /// <summary>
        /// The color for the text
        /// </summary>
        public virtual Color textColor { get => (Color)_textColor; set => _textColor = value; }
        /// <summary>
        /// The color for the tab
        /// </summary>
        public virtual Color tabColor { get => (Color)_tabColor; set => _tabColor = value; }
        /// <summary>
        /// The color for the border
        /// </summary>
        public virtual Color bordorColor { get => (Color)_borderColor; set => _borderColor = value; }
        /// <summary>
        /// The font used for the text
        /// </summary>
        public virtual Font tabFont { get => _tabFont; set => _tabFont = value; }

        /// <summary>
        /// The width of the border
        /// </summary>
        public virtual int borderWidth { get => _borderWidth; set => _borderWidth = value; }

        /// <summary>
        /// The type of tab that is used in the menu
        /// </summary>
        public virtual Type tabType {
            set {
                // If the type is not of ATab, return.
                if (!(value is ATab<T>))
                    return;

                _tabType = value;
            }
        }

        /// <summary>
        /// Instantiates a new menu
        /// </summary>
        /// <param name="panel">The parent panel of this menu</param>
        /// <param name="tabSize">The size of a tab</param>
        protected internal AMenu(Panel panel, SizeF tabSize) {
            tabList = new List<ATab<T>>();
            this.tabSize = tabSize;
            this.panel = panel;

            // Subscribe to paint and mouse up event
            panel.Paint += OnDraw;
            panel.MouseUp += OnClick;
        }

        /// <summary>
        /// Instantiates a new menu
        /// </summary>
        /// <param name="panel">The parent panel of this menu</param>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="tabType">The type of tab used by this menu</param>
        protected internal AMenu(Panel panel, SizeF tabSize, Type tabType) : this(panel, tabSize) => _tabType = tabType;

        /// <summary>
        /// Creates a new tab
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data for this tab</param>
        public virtual void CreateTab(string tabName, T data) {
            // If the type of tab is null, we can't add it
            if (_tabType == null)
                throw new NullReferenceException("Tab type has not been set");

            // Create the new tab and add it to the list
            tabList.Add((ATab<T>)Activator.CreateInstance(_tabType, new object[2] { tabName, data }));
        }

        /// <summary>
        /// Draws the menu
        /// </summary>
        /// <param name="g">The graphics instance to draw with</param>
        protected internal virtual void Draw(Graphics g) {
            // Draw a border around the menu
            using (Pen pen = new Pen(_borderColor ?? defaultBorderColor, _borderWidth))
                g.DrawRectangle(pen, panel.DisplayRectangle);
        }

        /// <summary>
        /// Sets the type of mouse click used for the click event
        /// </summary>
        /// <param name="mode">The type of click used to activate the tab change event</param>
        protected internal virtual void SetMouseMode(MouseModes mode) {
            // Unsubscribe from the mouse mode we are currently subscribed to
            switch (currentMouseMode) {
                case MouseModes.mouseUp:
                    panel.MouseUp -= OnClick;
                    break;
                case MouseModes.mouseClick:
                    panel.MouseClick -= OnClick;
                    break;
                case MouseModes.mouseDown:
                    panel.MouseDown -= OnClick;
                    break;
                case MouseModes.mouseDubbleClick:
                    panel.MouseDoubleClick -= OnClick;
                    break;
            }

            // Update the mouse mode
            currentMouseMode = mode;

            // Subscribe to the mouse mode we want to swap to
            switch (currentMouseMode) {
                case MouseModes.mouseUp:
                    panel.MouseUp += OnClick;
                    break;
                case MouseModes.mouseClick:
                    panel.MouseClick += OnClick;
                    break;
                case MouseModes.mouseDown:
                    panel.MouseDown += OnClick;
                    break;
                case MouseModes.mouseDubbleClick:
                    panel.MouseDoubleClick += OnClick;
                    break;
            }
        }

        /// <summary>
        /// Handles switching to the new tab based on a location of the click
        /// </summary>
        /// <param name="location">The location of the click</param>
        protected internal abstract void Click(Point location);

        public virtual void ChangeTab(int index) {
            if (index < 0 || index >= tabList.Count || index == current)
                return;

            if (current != -1)
                tabList[current].Deselect();

            current = index;

            T data = tabList[current].Select();

            TabChangedEventArgs<T> args = new TabChangedEventArgs<T>(data, index);

            onTabChanged(args);
        }

        /// <summary>
        /// The OnDraw function that is fired when the panel redraws
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The PaintEventArgs of the event</param>
        protected internal virtual void OnDraw(object sender, PaintEventArgs e) => Draw(e.Graphics);
        /// <summary>
        /// The OnClick function that is fired when the panel is clicked on with the correct click mode
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The MouseEventArgs of the event</param>
        protected internal virtual void OnClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                Click(e.Location);
        }

        /// <summary>
        /// The delegate used for the TabChanged event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The TabChangedEventArgs of the event</param>
        public delegate void TabChange(object sender, TabChangedEventArgs<T> e);

        /// <summary>
        /// The TabChange event
        /// </summary>
        public event TabChange tabChanged;

        /// <summary>
        /// Invokes the TabChanged event with the given arguments
        /// </summary>
        /// <param name="e">The arguments for the event</param>
        protected internal virtual void onTabChanged(TabChangedEventArgs<T> e) => tabChanged?.Invoke(this, e);
    }

    /// <summary>
    /// The mouse modes that can be used to click on a tab
    /// </summary>
    public enum MouseModes {
        /// <summary>
        /// Reacts when the user releases the button
        /// </summary>
        mouseUp,
        /// <summary>
        /// Reacts when the user presses the button down
        /// </summary>
        mouseDown,
        /// <summary>
        /// Reacts when the user clicks with the mouse button
        /// </summary>
        mouseClick,
        /// <summary>
        /// Reacts when the user double clicks
        /// </summary>
        mouseDubbleClick
    }

    /// <summary>
    /// The TabChangedEventArgs used when the user clicks on a tab
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tabs</typeparam>
    public class TabChangedEventArgs<T> : EventArgs {
        /// <summary>
        /// The data stored in the tab
        /// </summary>
        public T data { get; private set; }
        /// <summary>
        /// The index of the tab
        /// </summary>
        public int tabIndex { get; private set; }

        /// <summary>
        /// Instantiates new empty arguments
        /// </summary>
        public TabChangedEventArgs() { }
        /// <summary>
        /// Instantiates new arguments with data
        /// </summary>
        /// <param name="data">The data stored in the tab</param>
        /// <param name="tabIndex">The index of the tab</param>
        public TabChangedEventArgs(T data, int tabIndex) {
            this.data = data;
            this.tabIndex = tabIndex;
        }
    }
}
