using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 13, -3, 43, 5, 1, 0, 0, 23, 4, 6, 32, 53, 28, 84, 64 };
            Vector<int> intArrayList = new Vector<int>(array1);
            Console.WriteLine(String.Join(" ", intArrayList.ToArray()));
            intArrayList.Add(42);
            intArrayList.Add(5);
            intArrayList.Add(-6);
            intArrayList.Add(3, 10);
            intArrayList.Remove(4);
            intArrayList.Remove(1);
            Console.WriteLine(intArrayList.LastIndexOf(0));
            intArrayList.Set(0, 113);
            Console.WriteLine(String.Join(" ", intArrayList.ToArray()));

            string[] array2 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            string[] array3 = new string[] { "aboba" };
            Vector<string> stringArrayList = new Vector<string>(2, 2);
            stringArrayList.Add(array3[0]);
            stringArrayList.AddAll(array2);
            Console.WriteLine(stringArrayList.RemoveReturn(2));
            stringArrayList.Add(4, "despiteeverything");
            Console.WriteLine(stringArrayList.RemoveReturn(2));
            Console.WriteLine(String.Join(" ", stringArrayList.ToArray()));
        }
    }
}
