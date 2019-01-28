using DaanLib;
using DaanLib.Maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
    internal class Program {
        private static void Main(string[] args) {
            DaanLib.Datastructures.LinkedList<int> list = new DaanLib.Datastructures.LinkedList<int>();

            Vector2D v = new Vector2D(5, 10);

            Matrix m = new Matrix(v);

            Console.WriteLine(m);

            Console.WriteLine(Matrix.Identity(5));

            Console.ReadKey();
        }
    }
}
