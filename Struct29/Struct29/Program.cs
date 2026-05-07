using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyArrayDeque<int> deque = new MyArrayDeque<int>(8);
            deque.Add(1);
            deque.Add(2);
            deque.Add(3);
            deque.Add(4);
            deque.Add(5);
            Console.WriteLine(String.Join(" ", deque.ToArray()));
            deque.AddAll(2, new int[] {34, 35, 36, 67, 67, 67, 67, 67, 67, 67, 67});
            Console.WriteLine(String.Join(" ", deque.ToArray()));
        }
    }
}
