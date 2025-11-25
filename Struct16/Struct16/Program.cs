using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 13, -3, 43, 5, 1, 0, 0, 23, 4, 6, 32, 53, 28, 84, 64 };
            LinkedList<int> intLinkedList = new LinkedList<int>(array1);
            Console.WriteLine(String.Join(" ", intLinkedList.ToArray()));
            Console.WriteLine(intLinkedList.Size());
            intLinkedList.Add(15, 42);
            intLinkedList.Add(5);
            intLinkedList.Add(3);
            intLinkedList.Add(3, 10);
            intLinkedList.Remove(4);
            intLinkedList.Remove(1);
            Console.WriteLine(intLinkedList.LastIndexOf(0));
            intLinkedList.RemoveLastOccurrence(0);
            intLinkedList.Set(0, 113);
            Console.WriteLine(String.Join(" ", intLinkedList.ToArray()));

            string[] array2 = new string[] { "abas", "lol", "xd", "aeiou", "isctel" };
            string[] array3 = new string[] { "aboba" };
            LinkedList<string> stringLinkedList = new LinkedList<string>();
            stringLinkedList.Add(array3[0]);
            stringLinkedList.AddAll(array2);
            Console.WriteLine(stringLinkedList.PollLast());
            stringLinkedList.Add(4, "despiteeverything");
            Console.WriteLine(stringLinkedList.PollFirst());
            Console.WriteLine(String.Join(" ", stringLinkedList.ToArray()));
        }
    }
}
