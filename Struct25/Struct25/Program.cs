using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hashSet = new HashSet<int>(32);
            hashSet.Add(20);
            hashSet.Add(8);
            hashSet.Add(456);
            hashSet.Add(76);
            hashSet.Add(987);
            hashSet.Add(789);
            hashSet.Add(22345);
            hashSet.Add(245);
            hashSet.Add(4094);
            hashSet.Add(18);
            hashSet.Add(8123);

            Console.WriteLine(String.Join(" ", hashSet.ToArray()));

            hashSet.Remove(22345);
            hashSet.Remove(20);
            hashSet.Remove(8);
            hashSet.Remove(987);

            Console.WriteLine(String.Join(" ", hashSet.ToArray()));

            hashSet.RetainAll(new int[]{ 76, 8123, 456, 789 });

            Console.WriteLine(String.Join(" ", hashSet.ToArray()));

            HashSet<string> stringHashSet = new HashSet<string>(64);
            stringHashSet.Add("a moon shaped pool");
            stringHashSet.Add("fake plastic trees");
            stringHashSet.Add("black star");
            stringHashSet.Add("OK COMPUTER");

            Console.WriteLine(String.Join("\n", stringHashSet.ToArray()));
        }
    }
}
