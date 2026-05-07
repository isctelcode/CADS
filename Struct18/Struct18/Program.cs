using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct18
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTreeMap<int> treeMap = new MyTreeMap<int>();
            treeMap.Put(12, 2411);
            treeMap.Put(11, 234);
            treeMap.Put(3, 97);
            treeMap.Put(4, 6);
            treeMap.Put(6, 9871);
            treeMap.Put(2, 7);
            treeMap.Put(16, 678);
            treeMap.Put(18, 6);
            treeMap.Put(43, 897);
            treeMap.Put(2, 39);
            treeMap.Put(1, 208);
            treeMap.Put(82, 28);
            treeMap.Put(24, 211);
            treeMap.Put(63, 1578);

            Console.WriteLine(treeMap.Get(11));
            treeMap.EntrySet();
            Console.WriteLine();

            treeMap.Remove(3);
            treeMap.Remove(24);
            treeMap.EntrySet();
            Console.WriteLine();

            Console.WriteLine(treeMap.FirstKey());
            Console.WriteLine(treeMap.LastKey());
            Console.WriteLine(treeMap.ContainsKey(12));
            Console.WriteLine(treeMap.ContainsKey(11));
            Console.WriteLine(treeMap.ContainsKey(256));
            Console.WriteLine(treeMap.CeilingEntry(62).ToString());
            Console.WriteLine(treeMap.CeilingKey(62));
        }
    }
}
