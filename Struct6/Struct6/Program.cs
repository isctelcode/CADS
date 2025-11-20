using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 13, -3, 43, 5, 1, 0, 0, 23, 4, 6, 32, 53, 28, 84, 64 };
            PriorityQueue<int> intPriorityQueue = new PriorityQueue<int>(array1);
            Console.WriteLine(intPriorityQueue.Peek());
            intPriorityQueue.Add(13);
            intPriorityQueue.Add(3);
            intPriorityQueue.Add(4);
            intPriorityQueue.Offer(148);
            intPriorityQueue.Remove(6);
            intPriorityQueue.RemoveAll(new int[] {12, 4, 23, 654, 6});
            Console.WriteLine(intPriorityQueue.Peek());

            string[] array2 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            string[] array3 = new string[] { "aboba" };
            PriorityQueue<string> stringPriorityQueue = new PriorityQueue<string>(16);
            stringPriorityQueue.Add(array3[0]);
            stringPriorityQueue.AddAll(array2);
            Console.WriteLine(stringPriorityQueue.Peek());
            stringPriorityQueue.Add("despiteeverything");
            Console.WriteLine(stringPriorityQueue.Peek());
        }
    }
}
