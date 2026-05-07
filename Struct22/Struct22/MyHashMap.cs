using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Struct22
{
    class HashMapComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class MyHashMap<T>
    {
        private MyLinkedList<T[]>[] table = new MyLinkedList<T[]>[0];
        private int size = 0;
        private float loadFactor = 0.75f;
        private HashMapComparer<string> comparer = new HashMapComparer<string>();

        public long Hash(object e)
        {
            string key = e.ToString();
            long hash = 0, pow = 1;
            for (int i = 0; i < key.Length; ++i)
            {
                hash += key[i] * pow;
                pow *= 31;
            }
            return Abs(hash) % table.Length;
        }

        public MyHashMap()
        {
            table = new MyLinkedList<T[]>[16];
            for (int i = 0; i < 16; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            loadFactor = 0.75f;
        }

        public MyHashMap(int initialCapacity)
        {
            table = new MyLinkedList<T[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            this.loadFactor = 0.75f;
        }

        public MyHashMap(int initialCapacity, float loadFactor)
        {
            table = new MyLinkedList<T[]>[initialCapacity];
            for (int i = 0; i < initialCapacity; ++i)
            {
                table[i] = new MyLinkedList<T[]>();
            }
            size = 0;
            this.loadFactor = loadFactor;
        }

        public void Clear()
        {
            table = new MyLinkedList<T[]>[table.Length];
            size = 0;
        }

        public bool ContainsKey(object key)
        {
            string searchKey = key.ToString();
            long hashKey = Hash(searchKey);
            if (table[hashKey].Size() != 0)
            {
                T[][] hashKeys = table[hashKey].ToArray();
                foreach (T[] node in hashKeys)
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
                T[][] hashValues = table[i].ToArray();
                foreach (T[] node in hashValues)
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
                T[][] entrySet = table[i].ToArray();
                foreach (T[] node in entrySet)
                {
                    Console.Write($"<{node[0]}, {node[1]}> ");
                }
            }
            Console.WriteLine();
        }

        public T Get(object key)
        {
            string searchKey = key.ToString();
            long hashKey = Hash(searchKey);
            if (table[hashKey].Size() != 0)
            {
                T[][] hashKeys = table[hashKey].ToArray();
                foreach (T[] node in hashKeys)
                {
                    if (comparer.Compare(node[0].ToString(), searchKey) == 0)
                    {
                        return node[1];
                    }
                }
            }
            return default(T);
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void KeySet()
        {
            for (int i = 0; i < table.Length; ++i)
            {
                T[][] hashKeys = table[i].ToArray();
                foreach (T[] node in hashKeys)
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
                T[][] hashKeys = table[hashKey].ToArray();
                foreach (T[] node in hashKeys)
                {
                    if (comparer.Compare(node[0].ToString(), key.ToString()) == 0)
                    {
                        node[1] = (T)value;
                        return;
                    }
                }
                T[] newNode = new T[] { (T)key, (T)value };
                table[Hash(key)].AddLast(newNode);
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
            if (table[hashKey].Size() != 0)
            {
                T[][] hashKeys = table[hashKey].ToArray();
                int removeIndex = 0;
                foreach (T[] node in hashKeys)
                {
                    if (comparer.Compare(node[0].ToString(), searchKey) == 0)
                    {
                        table[hashKey].Remove(removeIndex);
                        --size;
                        return;
                    }
                    ++removeIndex;
                }
            }
        }

        public long Size()
        {
            return size;
        }
    }
}
