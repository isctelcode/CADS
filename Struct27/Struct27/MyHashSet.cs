using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct27
{
    class HashSetComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class MyHashSet<T>
    {
        private MyLinkedList<T[]>[] table = new MyLinkedList<T[]>[0];
        private int size = 0;
        private float loadFactor = 0.75f;
        private HashSetComparer<String> comparer = new HashSetComparer<String>();

        public long Hash(object e)
        {
            string key = e.ToString();
            long hash = 0, pow = 1;
            for (int i = 0; i < key.Length; ++i)
            {
                hash += key[i] * pow;
                pow *= 31;
            }
            return Math.Abs(hash) % table.Length;
        }

        public MyHashSet()
        {
            table = new MyLinkedList<T[]>[16];
            for (int i = 0; i < 16; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            loadFactor = 0.75f;
        }

        public MyHashSet(T[] elements)
        {
            table = new MyLinkedList<T[]>[elements.Length * 2];
            for (int i = 0; i < elements.Length * 2; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            loadFactor = 0.75f;
            for (int i = 0; i < elements.Length; ++i)
            {
                Add(elements[i]);
            }
        }

        public MyHashSet(int initialCapacity)
        {
            table = new MyLinkedList<T[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            this.loadFactor = 0.75f;
        }

        public MyHashSet(int initialCapacity, float loadFactor)
        {
            table = new MyLinkedList<T[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            this.loadFactor = loadFactor;
        }

        public void Add(object element)
        {
            try
            {
                long hashElement = Hash(element);
                T[][] hashElements = table[hashElement].ToArray();
                foreach (T[] node in hashElements)
                {
                    if (comparer.Compare(node[0].ToString(), element.ToString()) == 0)
                    {
                        return;
                    }
                }
                T[] newNode = new T[] { (T)element, default(T) };
                table[Hash(element)].AddLast(newNode);
                ++size;
                if (size / table.Length > loadFactor)
                {
                    MyLinkedList<T[]>[] newTable = new MyLinkedList<T[]>[table.Length * 2];
                    for (int i = 0; i < table.Length * 2; ++i)
                    {
                        newTable[i] = new MyLinkedList<T[]>();
                    }
                    for (int i = 0; i < table.Length; ++i)
                    {
                        T[][] hashNodes = table[i].ToArray();
                        foreach (T[] node in hashNodes)
                        {
                            newNode = new T[] { node[0], node[1] };
                            newTable[Hash(node[0])].AddLast(newNode);
                        }
                    }
                    table = newTable;
                }
            }
            catch (OutOfMemoryHashSetException exception)
            {
                Console.WriteLine(exception);
                return;
            }
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
            table = new MyLinkedList<T[]>[table.Length];
            size = 0;
        }

        public bool Contains(object element)
        {
            string searchElement = element.ToString();
            long hashElement = Hash(searchElement);
            if (table[hashElement].Size() != 0)
            {
                T[][] hashElements = table[hashElement].ToArray();
                foreach (T[] node in hashElements)
                {
                    if (comparer.Compare(node[0].ToString(), searchElement) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsAll(T[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                if (!Contains(elements[i]))
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

        public void Remove(object element)
        {
            string searchElement = element.ToString();
            long elementKey = Hash(searchElement);
            if (table[elementKey].Size() != 0)
            {
                T[][] elementKeys = table[elementKey].ToArray();
                int removeIndex = 0;
                foreach (T[] node in elementKeys)
                {
                    if (comparer.Compare(node[0].ToString(), searchElement) == 0)
                    {
                        table[elementKey].Remove(removeIndex);
                        --size;
                        return;
                    }
                    ++removeIndex;
                }
            }
        }

        public void RemoveAll(T[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                Remove(elements[i]);
            }
        }

        public void RetainAll(T[] elements)
        {
            for (int i = 0; i < table.Length; ++i)
            {
                T[][] hashNodes = table[i].ToArray();
                foreach (T[] node in hashNodes)
                {
                    bool deleteFlag = true;
                    for (int j = 0; j < elements.Length; ++j)
                    {
                        if (comparer.Compare(node[0].ToString(), elements[j].ToString()) == 0)
                        {
                            deleteFlag = false;
                            break;
                        }
                    }
                    if (deleteFlag)
                    {
                        table[i].Remove(node);
                        --size;
                        break;
                    }
                }
            }
        }

        public long Size()
        {
            return size;
        }

        public T[] ToArray()
        {
            T[] elements = new T[size];
            int counter = 0;
            for (int i = 0; i < table.Length; ++i)
            {
                T[][] hashNodes = table[i].ToArray();
                foreach (T[] node in hashNodes)
                {
                    elements[counter] = node[0];
                    ++counter;
                }
            }
            return elements;
        }
    }
}
