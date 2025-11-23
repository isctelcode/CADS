using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 13, -3, 43, 5, 1, 0, 0, 23, 4, 6, 32, 53, 28, 84, 64 };
            Stack<int> intStack = new Stack<int>();
            for (int i = 0; i < array1.Length; ++i)
            {
                intStack.Push(array1[i]);
            }
            intStack.Push(42);
            intStack.Push(5);
            intStack.Push(-6);
            intStack.Push(10);
            intStack.Pop();
            intStack.Pop();
            while (!intStack.Empty())
            {
                Console.WriteLine(intStack.Pop());
            }

            string[] array2 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            Stack<string> stringStack = new Stack<string>();
            stringStack.Push(array2[0]);
            stringStack.Push(array2[1]);
            stringStack.Pop();
            stringStack.Push(array2[2]);
            stringStack.Pop();
            stringStack.Push(array2[3]);
            stringStack.Push(array2[4]);
            while (!stringStack.Empty())
            {
                Console.WriteLine(stringStack.Pop());
            }
        }
    }
}
