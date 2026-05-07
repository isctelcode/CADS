using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct29
{
    public class TreeMapComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }
    public class MyTreeMap<T> : MyNavigableMap<T>  
    {
        private MyTreeMapNode<T> root = null;
        private int size = 0;
        private TreeMapComparer<T> comparer = new TreeMapComparer<T>();

        private void LeftRotate(MyTreeMapNode<T> x)
        {
            MyTreeMapNode<T> newParent = x.Right;

            if (x == root)
            {
                root = newParent;
            }

            x.MoveDown(newParent);

            x.Right = newParent.Left;

            if (newParent.Left != null)
            {
                newParent.Left.Parent = x;
            }

            newParent.Left = x;
        }

        private void RightRotate(MyTreeMapNode<T> x)
        {
            MyTreeMapNode<T> newParent = x.Left;

            if (x == root)
            {
                root = newParent;
            }

            x.MoveDown(newParent);

            x.Left = newParent.Right;

            if (newParent.Right != null)
            {
                newParent.Right.Parent = x;
            }

            newParent.Right = x;
        }

        private void SwapColors(MyTreeMapNode<T> x1, MyTreeMapNode<T> x2)
        {
            bool tmp = x1.IsRed;
            x1.IsRed = x2.IsRed;
            x2.IsRed = tmp;
        }

        private void SwapValues(MyTreeMapNode<T> x1, MyTreeMapNode<T> x2)
        {
            Tuple<T, T> tmp = x1.Value;
            x1.Value = x2.Value;
            x2.Value = tmp;
        }

        private void FixRedRed (MyTreeMapNode<T> x)
        {
            if (x == root)
            {
                x.IsRed = false;
                return;
            }

            MyTreeMapNode<T> parent = x.Parent, grandparent = parent.Parent, uncle = x.Uncle();

            if (parent.IsRed)
            {
                if (uncle != null && uncle.IsRed)
                {
                    parent.IsRed = false;
                    uncle.IsRed = false;
                    grandparent.IsRed = false;
                    FixRedRed(grandparent);
                }
                else
                {
                    if (parent.IsOnLeft())
                    {
                        if (x.IsOnLeft())
                        {
                            SwapColors(parent, grandparent);
                        }
                        else
                        {
                            LeftRotate(parent);
                            SwapColors(x, grandparent);
                        }
                        RightRotate(grandparent);
                    }
                    else
                    {
                        if (x.IsOnLeft())
                        {
                            RightRotate(parent);
                            SwapColors(x, grandparent);
                        }
                        else
                        {
                            SwapColors(parent, grandparent);
                        }

                        LeftRotate(grandparent);
                    }
                }
            }
        }

        private MyTreeMapNode<T> Successor(MyTreeMapNode<T> x)
        {
            MyTreeMapNode<T> tmp = x;
            while (tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        private MyTreeMapNode<T> Replace(MyTreeMapNode<T> x)
        {
            if (x.Left != null && x.Right != null)
            {
                return Successor(x.Right);
            }

            if (x.Left == null && x.Right == null)
            {
                return null;
            }

            if (x.Left != null)
            {
                return x.Left;
            }
            return x.Right;
        }

        private void DeleteNode(MyTreeMapNode<T> v)
        {
            MyTreeMapNode<T> u = Replace(v);

            bool uvBlack = ((u == null || !u.IsRed) && !v.IsRed);
            MyTreeMapNode<T> parent = v.Parent;

            if (u == null)
            {
                if (v == root)
                {
                    root = null;
                }
                else
                {
                    if (uvBlack)
                    {
                        FixDoubleBlack(v);
                    }
                    else
                    {
                        if (v.Sibling() != null)
                        {
                            v.Sibling().IsRed = true;
                        }
                    }

                    if (v.IsOnLeft())
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                return;
            }

            if (v.Left == null || v.Right == null)
            {
                if (v == root)
                {
                    v.Value = u.Value;
                    v.Left = null;
                    v.Right = null;
                    DeleteNode(u);
                }
                else
                {
                    if (v.IsOnLeft())
                    {
                        parent.Left = u;
                    }
                    else
                    {
                        parent.Right = u;
                    }
                    u.Parent = parent;

                    if (uvBlack)
                    {
                        FixDoubleBlack(u);
                    }
                    else
                    {
                        u.IsRed = false;
                    }
                }
                return;
            }
            SwapValues(u, v);
            DeleteNode(u);
        }

        private void FixDoubleBlack(MyTreeMapNode<T> x)
        {
            if (x == root)
            {
                return;
            }

            MyTreeMapNode<T> sibling = x.Sibling(), parent = x.Parent;

            if (sibling == null)
            {
                FixDoubleBlack(parent);
            }
            else
            {
                if (sibling.IsRed)
                {
                    parent.IsRed = true;
                    sibling.IsRed = false;
                    if (sibling.IsOnLeft())
                    {
                        RightRotate(parent);
                    }
                    else
                    {
                        LeftRotate(parent);
                    }
                    FixDoubleBlack(x);
                }
                else
                {
                    if (sibling.HasRedChild())
                    {
                        if (sibling.Left != null && sibling.Left.IsRed)
                        {
                            if (sibling.IsOnLeft())
                            {
                                sibling.Left.IsRed = sibling.IsRed;
                                sibling.IsRed = parent.IsRed;
                                RightRotate(parent);
                            }
                            else
                            {
                                sibling.Left.IsRed = parent.IsRed;
                                RightRotate(sibling);
                                LeftRotate(parent);
                            }
                        }
                        else
                        {
                            if (sibling.IsOnLeft())
                            {
                                sibling.Right.IsRed = sibling.IsRed;
                                sibling.IsRed = parent.IsRed;
                                LeftRotate(parent);
                            }
                        }
                        parent.IsRed = false;
                    }
                    else
                    {
                        sibling.IsRed = true;
                        if (!parent.IsRed)
                        {
                            FixDoubleBlack(parent);
                        }
                        else
                        {
                            parent.IsRed = false;
                        }
                    }
                }
            }
        }

        private MyTreeMapNode<T> Search(T key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (comparer.Compare(key, tmp.Value.Item1) < 0)
                {
                    if (tmp.Left == null)
                    {
                        break;
                    }
                    else
                    {
                        tmp = tmp.Left;
                    }
                }
                else if (comparer.Compare(key, tmp.Value.Item1) == 0)
                {
                    break;
                }
                else
                {
                    if (tmp.Right == null)
                    {
                        break;
                    }
                    else
                    {
                        tmp = tmp.Right;
                    }
                }
            }
            return tmp;
        }

        public bool ContainsKey(T key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (comparer.Compare(key, tmp.Value.Item1) < 0)
                {
                    if (tmp.Left == null)
                    {
                        return false;
                    }
                    else
                    {
                        tmp = tmp.Left;
                    }
                }
                else if (comparer.Compare(key, tmp.Value.Item1) == 0)
                {
                    return true;
                }
                else
                {
                    if (tmp.Right == null)
                    {
                        return false;
                    }
                    else
                    {
                        tmp = tmp.Right;
                    }    
                }
            }
            return false;
        }

        public T Get(T key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (comparer.Compare(key, tmp.Value.Item1) < 0)
                {
                    if (tmp.Left == null)
                    {
                        return default(T);
                    }
                    else
                    {
                        tmp = tmp.Left;
                    }
                }
                else if (comparer.Compare(key, tmp.Value.Item1) == 0)
                {
                    return tmp.Value.Item2;
                }
                else
                {
                    if (tmp.Right == null)
                    {
                        return default(T);
                    }
                    else
                    {
                        tmp = tmp.Right;
                    }
                }
            }
            return default(T);
        }

        private bool ContainsValue(MyTreeMapNode<T> x, T value)
        {
            if (x == null)
            {
                return false;
            }
            return ContainsValue(x.Left, value) || comparer.Compare(x.Value.Item2, value) == 0 || ContainsValue(x.Right, value);
        }

        public bool ContainsValue(T value)
        {
            return ContainsValue(root, value);
        }

        public MyLinkedList<T[]> entrySet;

        private void EntrySetSearch(MyTreeMapNode<T> x)
        {
            if (x == null)
            {
                return;
            }
            EntrySetSearch(x.Left);
            entrySet.AddLast(new T[] { x.Value.Item1, x.Value.Item2 });
            EntrySetSearch(x.Right);
        }

        public MyLinkedList<T[]> EntrySet()
        {
            entrySet = new MyLinkedList<T[]>();
            EntrySetSearch(root);
            return entrySet;
        }

        public MyLinkedList<T> keySet;

        private void KeySetSearch(MyTreeMapNode<T> x)
        {
            if (x == null)
            {
                return;
            }
            KeySetSearch(x.Left);
            keySet.AddLast(x.Value.Item1);
            KeySetSearch(x.Right);
        }

        public MyLinkedList<T> KeySet()
        {
            keySet = new MyLinkedList<T>();
            KeySetSearch(root);
            return keySet;
        }

        public void Put(T key, T value)
        {
            try
            {
                MyTreeMapNode<T> newNode = new MyTreeMapNode<T>(key, value);
                if (root == null)
                {
                    newNode.IsRed = false;
                    root = newNode;
                }
                else
                {
                    MyTreeMapNode<T> tmp = Search(key);

                    if (comparer.Compare(key, tmp.Value.Item1) == 0)
                    {
                        return;
                    }
                    ++size;

                    newNode.Parent = tmp;

                    if (comparer.Compare(key, tmp.Value.Item1) < 0)
                    {
                        tmp.Left = newNode;
                    }
                    else
                    {
                        tmp.Right = newNode;
                    }

                    FixRedRed(newNode);
                }
            }
            catch (OutOfMemoryTreeMapException exception)
            {
                Console.WriteLine(exception);
                return;
            }
        }

        public void PutAll(MyMap<T> map)
        {
            MyLinkedList<T[]> entry = map.EntrySet();
            T[][] entryArray = entry.ToArray();
            foreach (T[] node in entryArray)
            {
                Put(node[0], node[1]);
            }
        }

        public MyLinkedList<T> Values()
        {
            MyLinkedList<T[]> entry = EntrySet();
            MyLinkedList<T> values = new MyLinkedList<T>();
            T[][] entryArray = entry.ToArray();
            foreach (T[] node in entryArray)
            {
                values.AddLast(node[1]);
            }
            return values;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Remove(T key)
        {
            if (root == null)
            {
                return;
            }

            MyTreeMapNode<T> v = Search(key);

            if (comparer.Compare(key, v.Value.Item1) != 0)
            {
                return;
            }

            DeleteNode(v);
            --size;
        }

        public int Size()
        {
            return size;
        }

        private T FirstKey(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                return x.Value.Item1;
            }
            return FirstKey(x.Left);
        }

        public T FirstKey()
        {
            return FirstKey(root);
        }

        private T LastKey(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                return x.Value.Item1;
            }
            return LastKey(x.Right);
        }

        public T LastKey()
        {
            return LastKey(root);
        }

        MyLinkedList<T[]> headMap;

        private void HeadMapSeacrh(MyTreeMapNode<T> x, T end)
        {
            if (x == null)
            {
                return;
            }
            HeadMapSeacrh(x.Left, end);
            if (comparer.Compare(x.Value.Item1, end) < 0)
            {
                headMap.AddLast(new T[] { x.Value.Item1, x.Value.Item2 });
            }
            HeadMapSeacrh(x.Right, end);
        }

        public MyLinkedList<T[]> HeadMap(T end)
        {
            headMap = new MyLinkedList<T[]>();
            HeadMapSeacrh(root, end);
            return headMap;
        }

        MyLinkedList<T[]> subMap;

        private void SubMapSearch(MyTreeMapNode<T> x, T begin, T end)
        {
            if (x == null)
            {
                return;
            }
            SubMapSearch(x.Left, begin, end);
            if (comparer.Compare(x.Value.Item1, begin) > 0 && comparer.Compare(x.Value.Item1, end) < 0)
            {
                subMap.AddLast(new T[] { x.Value.Item1, x.Value.Item2 });
            }
            SubMapSearch(x.Right, begin, end);
        }

        public MyLinkedList<T[]> SubMap(T begin, T end)
        {
            subMap = new MyLinkedList<T[]>();
            SubMapSearch(root, begin, end);
            return subMap;
        }

        MyLinkedList<T[]> tailMap;

        private void TailMapSearch(MyTreeMapNode<T> x, T begin)
        {
            if (x == null)
            {
                return;
            }
            TailMapSearch(x.Left, begin);
            if (comparer.Compare(x.Value.Item1, begin) > 0)
            {
                tailMap.AddLast(new T[] { x.Value.Item1, x.Value.Item2 });
            }
            TailMapSearch(x.Right, begin);
        }

        public MyLinkedList<T[]> TailMap(T begin)
        {
            tailMap = new MyLinkedList<T[]>();
            TailMapSearch(root, begin);
            return tailMap;
        }
        
        public T[] LowerEntry(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) < 0)
                {
                    successor = current;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (successor != null)
            {
                return new T[] { successor.Value.Item1, successor.Value.Item2 };
            }
            return new T[] { default(T), default(T) };
        }

        public T[] FloorEntry(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) <= 0)
                {
                    successor = current;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (successor != null)
            {
                return new T[] { successor.Value.Item1, successor.Value.Item2 };
            }
            return new T[] { default(T), default(T) };
        }

        public T[] HigherEntry(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) > 0)
                {
                    successor = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (successor != null)
            {
                return new T[] { successor.Value.Item1, successor.Value.Item2 };
            }
            return new T[] { default(T), default(T) };
        }

        public T[] CeilingEntry(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) >= 0)
                {
                    successor = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (successor != null)
            {
                return new T[] { successor.Value.Item1, successor.Value.Item2 };
            }
            return new T[] { default(T), default(T) };
        }

        public T LowerKey(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) < 0)
                {
                    successor = current;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (successor != null)
            {
                return successor.Value.Item1;
            }
            return default(T);
        }

        public T FloorKey(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) <= 0)
                {
                    successor = current;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (successor != null)
            {
                return successor.Value.Item1;
            }
            return default(T);
        }

        public T HigherKey(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) > 0)
                {
                    successor = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (successor != null)
            {
                return successor.Value.Item1;
            }

            return default(T);
        }

        public T CeilingKey(T key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, key) >= 0)
                {
                    successor = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (successor != null)
            {
                return successor.Value.Item1;
            }

            return default(T);
        }

        private T[] PollFirstEntry(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                T[] first = new T[] { x.Value.Item1, x.Value.Item2 }; ;
                DeleteNode(x);
                return first;
            }
            return PollFirstEntry(x.Left);
        }

        public T[] PollFirstEntry()
        {
            return PollFirstEntry(root);
        }

        private T[] PollLastEntry(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                T[] first = new T[] { x.Value.Item1, x.Value.Item2 }; ;
                DeleteNode(x);
                return first;
            }
            return PollLastEntry(x.Right);
        }

        public T[] PollLastEntry()
        {
            return new T[] { root.Value.Item1, root.Value.Item2 };
        }

        private T[] FirstEntry(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                T[] first = new T[] { x.Value.Item1, x.Value.Item2 };
                return first;
            }
            return FirstEntry(x.Left);
        }

        public T[] FirstEntry()
        {
            return FirstEntry(root);
        }

        private T[] LastEntry(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                T[] first = new T[] { x.Value.Item1, x.Value.Item2 };
                return first;
            }
            return LastEntry(x.Right);
        }

        public T[] LastEntry()
        {
            return LastEntry(root);
        }

        public MyTreeMap()
        {
            root = null;
            size = 0;
            comparer = new TreeMapComparer<T>();
        }

        public MyTreeMap(TreeMapComparer<T> comparer)
        {
            root = null;
            size = 0;
            this.comparer = comparer;
        }

        public MyTreeMap(MyMap<T> map)
        {
            PutAll(map);
            comparer = new TreeMapComparer<T>();
        }

        public MyTreeMap(MySortedMap<T> map)
        {
            PutAll(map);
            comparer = new TreeMapComparer<T>();
        }
    }
}
