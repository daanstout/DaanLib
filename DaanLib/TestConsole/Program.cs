using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
    class Program {
        static void Main(string[] args) {
            DaanLib.Datastructures.LinkedList<int> list = new DaanLib.Datastructures.LinkedList<int>();

            for (int i = 0; i < 10; i++) {
                list.Add(i);
            }

            foreach (int i in list) {
                Console.WriteLine(i);
            }
        }
    }
}
