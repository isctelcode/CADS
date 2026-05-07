using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct19
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTreeSet<int> set = new MyTreeSet<int>();
            set.Add(13);
            set.Add(28);
            set.Add(773);
            set.Add(4);
            set.Add(90);
            set.Add(3);
            set.Add(64);
            set.Add(3);
            set.Add(7);
            set.Add(1350);
            set.Add(53);
            set.Add(27);
            set.Add(7);
            set.Add(85);
            Console.WriteLine(String.Join(" ", set.ToArray()));
            Console.WriteLine(set.Ceiling(86));
            Console.WriteLine(set.Floor(86));
            set.Remove(13);
            Console.WriteLine(String.Join(" ", set.ToArray()));
            Console.WriteLine(set.Contains(1350));
            Console.WriteLine(set.Contains(1351));
            Console.WriteLine(set.Contains(773));
        }
    }
}
