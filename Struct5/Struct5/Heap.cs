using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Struct5
{
    class Heap<T>
    {
        class Comparer : IComparer<T>
        {
            public int Compare(T a, T b)
            {
                return Comparer<T>.Default.Compare(a, b);
            }
        }
        Comparer comparer = new Comparer();

        private T[] heap;
        private int size;
        private int capacity;
        
        public int Size { get { return size; } }
        public int Capacity {  get { return capacity; } }

        public Heap(T[] array)
        {
            size = array.Length;
            capacity = 1;
            while (capacity < size)
            {
                capacity += capacity + 1;
            }
            heap = new T[capacity];
            for (int i = 0; i < size; ++i)
            {
                heap[i] = array[i];
            }

            int startIndex = size / 2 - 1;
            for (int i = startIndex; i >= 0; --i)
            {
                SiftDownMax(startIndex);
            }
        }

        public void SiftUpMax(int index)
        {
            while (index > 0)
            {
                int parentIndex = index / 2;
                if (comparer.Compare(heap[index], heap[parentIndex]) > 0)
                {
                    (heap[parentIndex], heap[index]) = (heap[index], heap[parentIndex]);
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

                if (rightChildIndex < size && comparer.Compare(heap[rightChildIndex], heap[leftChildIndex]) > 0)
                {
                    maxChildIndex = rightChildIndex;
                }

                if (comparer.Compare(heap[maxChildIndex], heap[index]) > 0)
                {
                    (heap[index], heap[maxChildIndex]) = (heap[maxChildIndex], heap[index]);
                    index = maxChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T ReturnMax()
        {
            if (size == 0)
            {
                throw new NullHeapException();
            }
            return heap[0];
        }

        public T RemoveMax()
        {
            if (size == 0)
            {
                throw new NullHeapException();
            }
            T heapMax = heap[0];
            heap[0] = heap[size - 1];
            --size;
            SiftDownMax(0);
            return heapMax;
        }

        public void ChangeValue(int index, T value)
        {
            if (size == 0)
            {
                throw new NullHeapException();
            }
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeHeapException();
            }
            heap[index] = value;
            SiftUpMax(index);
            SiftDownMax(index);
        }

        public void InsertValue(T value)
        {
            if (size == capacity)
            {
                capacity += capacity + 1;
                try
                {
                    T[] newHeap = new T[capacity];
                    for (int i = 0; i < size; ++i)
                    {
                        newHeap[i] = heap[i];
                    }
                    heap = newHeap;
                }
                catch (OutOfMemoryHeapException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            heap[size] = value;
            SiftUpMax(size);
            ++size;
        }

        public void Merge(Heap<T> newHeap)
        {
            while (newHeap.Size > 0)
            {
                InsertValue(newHeap.RemoveMax());
            }
        }
    }
}
