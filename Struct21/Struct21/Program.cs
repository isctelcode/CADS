using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashMap<int> hashMap = new HashMap<int>(32);
            hashMap.Put(120, 20);
            hashMap.Put(23, 8);
            hashMap.Put(16789, 456);
            hashMap.Put(968, 76);
            hashMap.Put(67, 987);
            hashMap.Put(876, 789);
            hashMap.Put(76, 22345);
            hashMap.Put(534, 245);
            hashMap.Put(645, 4094);
            hashMap.Put(1, 18);
            hashMap.Put(1, 8123);
            hashMap.EntrySet();
            Console.WriteLine(hashMap.Get(16789));

            HashMap<string> stringHashMap = new HashMap<string>(64);
            stringHashMap.Put("a moon", "shaped pool");
            stringHashMap.Put("fake", "plastic trees");
            stringHashMap.Put("black", "star");
            stringHashMap.Put("OK", "COMPUTER");

            stringHashMap.EntrySet();
            stringHashMap.KeySet();
            Console.WriteLine(stringHashMap.Get("OK"));
            Console.WriteLine(stringHashMap.Get("fake"));
            Console.WriteLine(stringHashMap.Get("a moon"));
        }
    }
}
