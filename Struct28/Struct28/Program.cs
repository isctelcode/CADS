using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyPriorityQueue<int> queue = new MyPriorityQueue<int>();
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);
            queue.Add(4);
            queue.Add(5);
            queue.Add(6);
            queue.Add(7);
            queue.Add(8);
            queue.Add(9);
            queue.Add(10);
            queue.Add(11);
            MyPriorityQueue<int>.MyItr<int> queueIter = queue.Iterator();
            Console.Write("Очередь: ");
            while (queueIter.HasNext())
            {
                Console.Write(queueIter.Next() + " ");
            }
            queueIter.Reset();
            queue.Add(16);
            queue.Add(17);
            queue.Add(18);
            queue.Add(19);
            queue.Add(20);
            queueIter = queue.Iterator();
            Console.WriteLine();
            while (queueIter.HasNext())
            {
                Console.Write(queueIter.Next() + " ");
            }
            Console.WriteLine();
            MyHashSet<int> set = new MyHashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            MyHashSet<int>.MyItr<int> setIter = set.Iterator();
            Console.Write("Хеш-множество: ");
            while (setIter.HasNext())
            {
                Console.Write(setIter.Next() + " ");
            }
            Console.WriteLine();
            MyTreeSet<int> treeSet = new MyTreeSet<int>();
            treeSet.Add(12);
            treeSet.Add(22);
            treeSet.Add(32);
            treeSet.Add(42);
            treeSet.Add(52);
            MyTreeSet<int>.MyItr<int> treeSetIter = treeSet.Iterator();
            Console.Write("Дерево-множество: ");
            while (treeSetIter.HasNext())
            {
                Console.Write(treeSetIter.Next() + " ");
            }
            Console.WriteLine();

            MyArrayList<int> arrayList = new MyArrayList<int>();
            arrayList.Add(12);
            arrayList.Add(22);
            arrayList.Add(32);
            arrayList.Add(42);
            arrayList.Add(52);
            MyArrayList<int>.MyItr<int> arrayListIter = arrayList.ListIterator();
            Console.Write("Массив-список: ");
            while (arrayListIter.HasNext())
            {
                Console.Write(arrayListIter.Next() + " ");
            }
            while (arrayListIter.HasPrevious())
            {
                Console.Write(arrayListIter.Previous() + " ");
            }
            Console.WriteLine();
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.Add(12);
            linkedList.Add(22);
            linkedList.Add(32);
            linkedList.Add(42);
            linkedList.Add(52);
            MyLinkedList<int>.MyItr<int> linkedListIter = linkedList.ListIterator(1);
            Console.Write("Связный список (с 1-го): ");
            while (linkedListIter.HasNext())
            {
                Console.Write(linkedListIter.Next() + " ");
            }
            while (linkedListIter.HasPrevious())
            {
                Console.Write(linkedListIter.Previous() + " ");
            }
            Console.WriteLine();
            MyVector<int> vector = new MyVector<int>();
            vector.Add(12);
            vector.Add(22);
            vector.Add(32);
            vector.Add(42);
            vector.Add(52);
            MyVector<int>.MyItr<int> vectorIter = vector.ListIterator(3);
            Console.Write("Вектор (с 3-го): ");
            while (vectorIter.HasNext())
            {
                Console.Write(vectorIter.Next() + " ");
            }
            while (vectorIter.HasPrevious())
            {
                Console.Write(vectorIter.Previous() + " ");
            }
        }
    }
}
