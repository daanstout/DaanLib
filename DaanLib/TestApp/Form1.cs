using DaanLib.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp {
    public partial class Form1 : Form {
        private AMenu<string> menu1;
        private AMenu<string> menu2;


        public Form1() {
            InitializeComponent();

            menu1 = new HorizontalMenu<string>(panel1, new SizeF(50, 50));
            menu2 = new VerticalMenu<string>(panel2, new SizeF(50, 50));

            menu1.tabType = typeof(testTab<string>);

            menu1.tabChanged += onTabChange;
            menu2.tabChanged += onTabChange;

            for (int i = 0; i < 5; i++) {
                menu1.CreateTab("tab" + i, i.ToString());
                menu2.CreateTab(new VerticalTab<string>("tab" + i, i.ToString()));
            }

            menu1.ChangeTab(0);
            menu2.ChangeTab(0);
        }

        private void onTabChange(object sender, TabChangedEventArgs<string> e) => Console.WriteLine(e.data);
    }

    public class testTab<T> : HorizontalTab<T> { }
}
