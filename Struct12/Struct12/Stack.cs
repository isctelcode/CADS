using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct12
{
    class StackComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class Stack<T> : Vector<T>
    {
        public void Push(T item)
        {
            Add(item);
        }

        public T Peek()
        {
            if (Empty())
            {
                throw new NullVectorException();
            }
            return LastElement();
        }

        public T Pop()
        {
            if (Empty())
            {
                throw new NullVectorException();
            }
            T removed = Peek();
            RemoveElementAt(LastIndexOf(removed));
            return removed;
        }

        public bool Empty()
        {
            return IsEmpty();
        }

        public int Search(T item)
        {
            if (Empty())
            {
                throw new NullVectorException();
            }
            int lastIndexOf = LastIndexOf(item);
            if (lastIndexOf == -1)
            {
                return -1;
            }
            else
            {
                return Size() - lastIndexOf;
            }
        }
    }
}
