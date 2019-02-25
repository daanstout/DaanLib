using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;

namespace DaanLib.Menus {
    public class VerticalMenu<T> : AMenu<T> {
        public VerticalMenu(Vector2D tabSize, Vector2D menuSize) : base(tabSize, menuSize) {
        }
    }
}
