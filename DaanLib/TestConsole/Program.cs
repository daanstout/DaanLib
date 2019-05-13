using DaanLib;
using DaanLib.Maths;
using DaanLib.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
    internal class Program {
        private static void Main() {
            //DaanLib.Datastructures.LinkedList<int> list = new DaanLib.Datastructures.LinkedList<int>();

            //DaanLib.Maths.Vector2D v = new DaanLib.Maths.Vector2D(5, 10);

            //Matrix m = new Matrix(v);

            //Console.WriteLine(m);

            //Console.WriteLine(Matrix.Identity(5));

            Vector2D vec = new Vector2D(1, 3);

            string vecS = vec.ToString();

            Vector2D vec2 = new Vector2D(vecS);

            Console.WriteLine(vec2);

            Vector3D vec3 = new Vector3D(1, 3, 5);

            vecS = vec3.ToString();

            Vector3D vec4 = new Vector3D(vecS);

            Console.WriteLine(vec4);

            Console.ReadKey();
        }
    }

}
