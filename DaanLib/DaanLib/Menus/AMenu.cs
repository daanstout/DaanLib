using DaanLib.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menus {
    public abstract class AMenu<T> : IMenu<T> {
        protected readonly List<ATab<T>> tabList;
        protected readonly Vector2D tabSize;
        protected readonly Vector2D menuSize;
        protected int current = -1;

        public AMenu(Vector2D tabSize, Vector2D menuSize) {
            tabList = new List<ATab<T>>();
            this.tabSize = tabSize;
            this.menuSize = menuSize;
        }

        public virtual void CreateTab(string tabName, T data) { }
    }
}
