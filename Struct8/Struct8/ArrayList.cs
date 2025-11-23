using Struct8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct8
{
    class ArrayListComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class ArrayList<T>
    {
        private T[] elementData = new T[1];
        private int size = 0;
        private int capacity = 1;
        private ArrayListComparer<T> comparer = new ArrayListComparer<T>();

        public ArrayList()
        {
            size = 0;
            capacity = 1;
            elementData = new T[capacity];
        }

        public ArrayList(T[] array)
        {
            size = array.Length;
            capacity = size;
            elementData = new T[capacity];
            for (int i = 0; i < size; ++i)
            {
                elementData[i] = array[i];
            }
        }

        public ArrayList(int capacity)
        {
            size = 0;
            this.capacity = capacity;
            elementData = new T[capacity];
        }

        public void Add(T element)
        {
            if (size == capacity)
            {
                try
                {
                    capacity = Convert.ToInt32(capacity * 1.5) + 1;
                    T[] newElementData = new T[capacity];
                    for (int i = 0; i < size; ++i)
                    {
                        newElementData[i] = elementData[i];
                    }
                    elementData = newElementData;
                }
                catch (OutOfMemoryArrayListException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            elementData[size] = element;
            ++size;
        }

        public void AddAll(T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Add(array[i]);
            }
        }

        public void Clear()
        {
            size = 0;
            capacity = 1;
            elementData = new T[capacity];
        }

        public bool Contains(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            for (int i = 0; i < size; ++i)
            {
                if (comparer.Compare(elementData[i], element) == 0)
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
                throw new NullArrayListException();
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

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Remove(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            for (int i = 0; i < size; ++i)
            {
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    for (int j = i; j < size - 1; ++j)
                    {
                        elementData[j] = elementData[j + 1];
                    }
                    --size;
                    return;
                }
            }
        }

        public void RemoveAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
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
                throw new NullArrayListException();
            }
            int wrongElementsCount = 0;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < elements.Length; ++j)
                {
                    if (comparer.Compare(elementData[i], elements[j]) != 0)
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
                    if (comparer.Compare(elementData[i], elements[j]) != 0)
                    {
                        wrongElements[wrongElementsCount] = elementData[i];
                        ++wrongElementsCount;
                    }
                }
            }
            RemoveAll(wrongElements);
        }

        public T[] ToArray()
        {
            T[] arrayListToArray = new T[size];
            for (int i = 0; i < size; ++i)
            {
                arrayListToArray[i] = elementData[i];
            }
            return arrayListToArray;
        }

        public void Add(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            if (size == capacity)
            {
                try
                {
                    capacity = Convert.ToInt32(capacity * 1.5) + 1;
                    T[] newElementData = new T[capacity];
                    for (int i = 0; i < size; ++i)
                    {
                        newElementData[i] = elementData[i];
                    }
                    elementData = newElementData;
                }
                catch (OutOfMemoryArrayListException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }

            for (int i = size; i > index; --i)
            {
                elementData[i] = elementData[i - 1];
            }
            elementData[index] = element;
            ++size;
        }

        public void AddAll(int index, T[] array)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            for (int i = 0; i < array.Length; ++i)
            {
                Add(index + i, array[i]);
            }
        }

        public T Get(int index)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            return elementData[index];
        }

        public int IndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            for (int i = 0; i < size; ++i)
            {
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int LastIndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            for (int i = size - 1; i >= 0; --i)
            {
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public T RemoveReturn(int index)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            T removed = elementData[index];
            for (int i = index; i < size - 1; ++i)
            {
                elementData[i] = elementData[i + 1];
            }
            --size;
            return removed;
        }

        public void Set(int index, T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            elementData[index] = element;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if (IsEmpty())
            {
                throw new NullArrayListException();
            }
            if (fromIndex > toIndex)
            {
                throw new InvalidIntervalArgumentException();
            }
            if (fromIndex < 0 || fromIndex >= size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            if (toIndex < 0 || toIndex > size)
            {
                throw new IndexOutOfRangeArrayListException();
            }
            T[] subList = new T[toIndex - fromIndex];
            for (int i = fromIndex; i < toIndex; ++i)
            {
                subList[i] = elementData[i];
            }
            return subList;
        }
    }
}