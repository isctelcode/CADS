using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 13, -3, 43, 5, 1, 0, 0, 23, 4, 6, 32, 53, 28, 84, 64 };
            ArrayDeque<int> intArrayDeque = new ArrayDeque<int>(array1);
            Console.WriteLine(String.Join(" ", intArrayDeque.ToArray()));
            intArrayDeque.Add(42);
            intArrayDeque.Add(5);
            intArrayDeque.Add(-6);
            intArrayDeque.Add(10);
            intArrayDeque.Remove(4);
            intArrayDeque.Remove(1);
            intArrayDeque.RemoveLastOccurrence(0);
            Console.WriteLine(String.Join(" ", intArrayDeque.ToArray()));

            string[] array2 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            string[] array3 = new string[] { "aboba" };
            ArrayDeque<string> stringArrayDeque = new ArrayDeque<string>();
            stringArrayDeque.Add(array3[0]);
            stringArrayDeque.AddAll(array2);
            Console.WriteLine(stringArrayDeque.PollFirst());
            stringArrayDeque.Add("despiteeverything");
            Console.WriteLine(stringArrayDeque.PollLast());
            Console.WriteLine(String.Join(" ", stringArrayDeque.ToArray()));
        }
    }
}
