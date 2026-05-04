using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Struct21
{
    class HashMapComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class HashMap<Entry>
    {
        private LinkedList<Entry[]>[] table = new LinkedList<Entry[]>[0];
        private int size = 0;
        private float loadFactor = 0.75f;
        private HashMapComparer<String> comparer = new HashMapComparer<String>();

        public long Hash(object e)
        {
            string key = e.ToString();
            long hash = 0, pow = 1;
            for (int i = 0; i < key.Length; ++i)
            {
                hash += key[i] * pow;
                pow *= 31;
            }
            return hash % table.Length;
        }

        public HashMap()
        {
            table = new LinkedList<Entry[]>[16];
            for (int i = 0; i < 16; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            loadFactor = 0.75f;
        }

        public HashMap(int initialCapacity)
        {
            table = new LinkedList<Entry[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            this.loadFactor = 0.75f;
        }

        public HashMap(int initialCapacity, float loadFactor)
        {
            table = new LinkedList<Entry[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new LinkedList<Entry[]>();
            }
            size = 0;
            this.loadFactor = loadFactor;
        }

        public void Clear()
        {
            table = new LinkedList<Entry[]>[table.Length];
            size = 0;
        }

        public bool ContainsKey(object key)
        {
            string searchKey = key.ToString();
            long hashKey = Hash(searchKey);
            if (table[hashKey].First != null)
            {
                foreach (Entry[] node in table[hashKey])
                {
                    if (comparer.Compare(node[0].ToString(), searchKey) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsValue(object value)
        {
            for (int i = 0; i < table.Length; ++i)
            {
                foreach (Entry[] node in table[i])
                {
                    if (comparer.Compare(node[1].ToString(), value.ToString()) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void EntrySet()
        {
            for (int i = 0; i < table.Length; ++i)
            {
                foreach (Entry[] node in table[i])
                {
                    Console.Write($"<{node[0]}, {node[1]}> ");
                }
            }
            Console.WriteLine();
        }

        public Entry Get(object key)
        {
            string searchKey = key.ToString();
            long hashKey = Hash(searchKey);
            if (table[hashKey].First != null)
            {
                foreach (Entry[] node in table[hashKey])
                {
                    if (comparer.Compare(node[0].ToString(), searchKey) == 0)
                    {
                        return node[1];
                    }
                }
            }
            return default(Entry);
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void KeySet()
        {
            for (int i = 0; i < table.Length; ++i)
            {
                foreach (Entry[] node in table[i])
                {
                    Console.Write($"{node[0]} ");
                }
            }
            Console.WriteLine();
        }

        public void Put(object key, object value)
        {
            try
            {
                long hashKey = Hash(key);
                foreach (Entry[] node in table[hashKey])
                {
                    if (comparer.Compare(node[0].ToString(), key.ToString()) == 0)
                    {
                        node[1] = (Entry)value;
                        return;
                    }
                }
                Entry[] newNode = new Entry[] { (Entry)key, (Entry)value };
                table[Hash(key)].AddLast(newNode);
                ++size;
                if (size / table.Length > loadFactor)
                {
                    LinkedList<Entry[]>[] newTable = new LinkedList<Entry[]>[table.Length * 2];
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
            catch (OutOfMemoryHashMapException exception)
            {
                Console.WriteLine(exception);
                return;
            }
        }

        public void Remove(object key)
        {
            string searchKey = key.ToString();
            long hashKey = Hash(searchKey);
            if (table[hashKey].First != null)
            {
                foreach (Entry[] node in table[hashKey])
                {
                    if (comparer.Compare(node[0].ToString(), searchKey) == 0)
                    {
                        table[hashKey].Remove(node);
                        --size;
                        return;
                    }
                }
            }
        }

        public long Size()
        {
            return size;
        }
    }
}
