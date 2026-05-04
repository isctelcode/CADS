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

    class HashSet<Entry>
    {
        private LinkedList<Entry[]>[] table = new LinkedList<Entry[]>[0];
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

        public HashSet()
        {
            table = new LinkedList<Entry[]>[16];
            for (int i = 0; i < 16; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            loadFactor = 0.75f;
        }

        public HashSet(Entry[] elements)
        {
            table = new LinkedList<Entry[]>[elements.Length * 2];
            for (int i = 0; i < elements.Length * 2; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            loadFactor = 0.75f;
            for (int i = 0; i < elements.Length; ++i)
            {
                Add(elements[i]);
            }
        }

        public HashSet(int initialCapacity)
        {
            table = new LinkedList<Entry[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            this.loadFactor = 0.75f;
        }

        public HashSet(int initialCapacity, float loadFactor)
        {
            table = new LinkedList<Entry[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            this.loadFactor = loadFactor;
        }

        public void Add(object element)
        {
            try
            {
                long hashElement = Hash(element);
                foreach (Entry[] node in table[hashElement])
                {
                    if (comparer.Compare(node[0].ToString(), element.ToString()) == 0)
                    {
                        return;
                    }
                }
                Entry[] newNode = new Entry[] { (Entry)element, default(Entry) };
                table[Hash(element)].AddLast(newNode);
                ++size;
                if (size / table.Length > loadFactor)
                {
                    LinkedList<Entry[]>[] newTable = new LinkedList<Entry[]>[table.Length * 2];
                    for (int i = 0; i < table.Length * 2; ++i)
                    {
                        newTable[i] = new LinkedList<Entry[]>();
                    }
                    for (int i = 0; i < table.Length; ++i)
                    {
                        foreach (Entry[] node in table[i])
                        {
                            newNode = new Entry[] { node[0], node[1] };
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

        public void AddAll(Entry[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                Add(elements[i]);
            }
        }

        public void Clear()
        {
            table = new LinkedList<Entry[]>[table.Length];
            size = 0;
        }

        public bool Contains(object element)
        {
            string searchElement = element.ToString();
            long hashElement = Hash(searchElement);
            if (table[hashElement].First != null)
            {
                foreach (Entry[] node in table[hashElement])
                {
                    if (comparer.Compare(node[0].ToString(), searchElement) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsAll(Entry[] elements)
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
            if (table[elementKey].First != null)
            {
                foreach (Entry[] node in table[elementKey])
                {
                    if (comparer.Compare(node[0].ToString(), searchElement) == 0)
                    {
                        table[elementKey].Remove(node);
                        --size;
                        return;
                    }
                }
            }
        }

        public void RemoveAll(Entry[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                Remove(elements[i]);
            }
        }

        public void RetainAll(Entry[] elements)
        {
            for (int i = 0; i < table.Length; ++i)
            {
                foreach (Entry[] node in table[i])
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

        public Entry[] ToArray()
        {
            Entry[] elements = new Entry[size];
            int counter = 0;
            for (int i = 0; i < table.Length; ++i)
            {
                foreach (Entry[] node in table[i])
                {
                    elements[counter] = node[0];
                    ++counter;
                }
            }
            return elements;
        }
    }
}
