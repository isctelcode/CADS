using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct6
{
    class PriorityQueueComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class PriorityQueue<T>
    {
        private T[] priorityQueue = new T[11];
        private int size = 0;
        private int capacity = 11;
        private PriorityQueueComparer<T> comparer = new PriorityQueueComparer<T>();

        public T[] Queue { get { return priorityQueue; } }
        public int Size { get { return size; } }
        public int Capacity { get { return capacity; } }
        public PriorityQueueComparer<T> Comparer { get { return  comparer; } }

        public PriorityQueue()
        {
            size = 0;
            capacity = 11;
            T[] priorityQueue = new T[capacity];
            comparer = new PriorityQueueComparer<T>();
        }

        public PriorityQueue(T[] array)
        {
            size = array.Length;
            capacity = 11;
            while (capacity < size)
            {
                if (capacity < 64)
                {
                    capacity *= 2;
                }
                else
                {
                    capacity += capacity / 2;
                }
            }
            priorityQueue = new T[capacity];
            for (int i = 0; i < size; ++i)
            {
                priorityQueue[i] = array[i];
            }

            comparer = new PriorityQueueComparer<T>();
            int startIndex = size / 2 - 1;
            for (int i = startIndex; i >= 0; --i)
            {
                int index = i;
                while (index * 2 + 1 < size)
                {
                    int leftChildIndex = 2 * index + 1, rightChildIndex = 2 * index + 2;
                    int maxChildIndex = leftChildIndex;

                    if (rightChildIndex < size && comparer.Compare(priorityQueue[rightChildIndex], priorityQueue[leftChildIndex]) > 0)
                    {
                        maxChildIndex = rightChildIndex;
                    }

                    if (comparer.Compare(priorityQueue[maxChildIndex], priorityQueue[index]) > 0)
                    {
                        (priorityQueue[index], priorityQueue[maxChildIndex]) = (priorityQueue[maxChildIndex], priorityQueue[index]);
                        index = maxChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public PriorityQueue(int initialCapacity)
        {
            size = 0;
            capacity = initialCapacity;
            T[] priorityQueue = new T[capacity];
            comparer = new PriorityQueueComparer<T>();
        }

        public PriorityQueue(int initialCapacity, PriorityQueueComparer<T> comparer)
        {
            size = 0;
            capacity = initialCapacity;
            T[] priorityQueue = new T[capacity];
            this.comparer = comparer;
        }

        public PriorityQueue(PriorityQueue<T> anotherPriorityQueue)
        {
            size = anotherPriorityQueue.Size;
            capacity = anotherPriorityQueue.Capacity;
            T[] priorityQueue = anotherPriorityQueue.Queue;
            comparer = anotherPriorityQueue.Comparer;
        }

        public void SiftUpMax(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (comparer.Compare(priorityQueue[index], priorityQueue[parentIndex]) > 0)
                {
                    (priorityQueue[parentIndex], priorityQueue[index]) = (priorityQueue[index], priorityQueue[parentIndex]);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public void SiftDownMax(int index)
        {
            while (index * 2 + 1 < size)
            {
                int leftChildIndex = 2 * index + 1, rightChildIndex = 2 * index + 2;
                int maxChildIndex = leftChildIndex;

                if (rightChildIndex < size && comparer.Compare(priorityQueue[rightChildIndex], priorityQueue[leftChildIndex]) > 0)
                {
                    maxChildIndex = rightChildIndex;
                }

                if (comparer.Compare(priorityQueue[maxChildIndex], priorityQueue[index]) > 0)
                {
                    (priorityQueue[index], priorityQueue[maxChildIndex]) = (priorityQueue[maxChildIndex], priorityQueue[index]);
                    index = maxChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public void Add(T element)
        {
            if (size == capacity)
            {
                try
                {
                    if (capacity < 64)
                    {
                        capacity *= 2;
                    }
                    else
                    {
                        capacity += capacity / 2;
                    }
                    T[] newProrityQueue = new T[capacity];
                    for (int i = 0; i < size; ++i)
                    {
                        newProrityQueue[i] = priorityQueue[i];
                    }
                    priorityQueue = newProrityQueue;
                }
                catch (OutOfMemoryPriorityQueueException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            priorityQueue[size] = element;
            SiftUpMax(size);
            ++size;
        }

        public void AddAll(T[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                Add(elements[i]);
            }
        }

        public void Clear()
        {
            size = 0;
            T[] priorityQueue = new T[capacity];
        }

        public bool Contains(object element)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            for (int i = 0; i < size; ++i)
            {
                if (comparer.Compare(priorityQueue[i], (T) element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            bool[] contains = new bool[elements.Length];
            for (int i = 0; i < contains.Length; ++i)
            {
                contains[i] = Contains(elements[i]);
            }
            for (int i = 0; i < contains.Length; ++i)
            {
                if (contains[i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Remove(T element)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            for (int i = 0; i < size; ++i)
            {
                if (comparer.Compare(priorityQueue[i], element) == 0)
                {
                    priorityQueue[i] = priorityQueue[size - 1];
                    --size;
                    SiftUpMax(i);
                    SiftDownMax(i);
                    return;
                }
            }
        }

        public void RemoveAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            for (int i = 0; i < elements.Length; ++i)
            {
                Remove(elements[i]);
            }
        }

        public void RetainAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            int wrongElementsCount = 0;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < elements.Length; ++j)
                {
                    if (comparer.Compare(priorityQueue[i], elements[j]) != 0)
                    {
                        ++wrongElementsCount;
                    }
                }
            }
            T[] wrongElements = new T[wrongElementsCount];
            wrongElementsCount = 0;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < elements.Length; ++j)
                {
                    if (comparer.Compare(priorityQueue[i], elements[j]) != 0)
                    {
                        wrongElements[wrongElementsCount] = priorityQueue[i];
                        ++wrongElementsCount;
                    }
                }
            }
            RemoveAll(wrongElements);
        }

        public T[] ToArray()
        {
            T[] priorityQueueToArray = new T[size];
            for (int i = 0; i < size; ++i)
            {
                priorityQueueToArray[i] = priorityQueue[i];
            }
            return priorityQueueToArray;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            return priorityQueue[0];
        }

        public T Poll()
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            T priorityQueueHead = Peek();
            priorityQueue[0] = priorityQueue[size - 1];
            --size;
            SiftDownMax(0);
            return priorityQueueHead;
        }

        public bool Offer(T element)
        {
            if (IsEmpty())
            {
                throw new NullPriorityQueueException();
            }
            if (size == capacity)
            {
                return false;
            }

            Add(element);
            return true;
        }
    }
}
