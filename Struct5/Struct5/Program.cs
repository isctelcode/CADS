using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 54, 2, 4, 13, 64, 1, 3, 89, 6, 3 };
            MyHeap<int> intHeap = new MyHeap<int>(array1);
            intHeap.InsertValue(12);
            Console.WriteLine(intHeap.ReturnMax());
            intHeap.ChangeValue(3, 999);
            Console.WriteLine(intHeap.RemoveMax());
            Console.WriteLine(intHeap.ReturnMax());

            int[] array2 = new int[] { };
            MyHeap<int> anotherIntHeap = new MyHeap<int>(array2);
            anotherIntHeap.InsertValue(12);
            Console.WriteLine(anotherIntHeap.ReturnMax());
            anotherIntHeap.InsertValue(35);
            Console.WriteLine(anotherIntHeap.ReturnMax());

            intHeap.Merge(anotherIntHeap);

            string[] array3 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            MyHeap<string> stringHeap = new MyHeap<string>(array3);
            Console.WriteLine(stringHeap.ReturnMax());
            stringHeap.InsertValue("despiteeverything");
        }
    }
}
