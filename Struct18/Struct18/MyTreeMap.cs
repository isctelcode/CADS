using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct18
{
    class TreeMapComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }
    class MyTreeMap<T>
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
            Tuple<int, T> tmp = x1.Value;
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

        private MyTreeMapNode<T> Search(int key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (key < tmp.Value.Item1)
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
                else if (key == tmp.Value.Item1)
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

        public bool ContainsKey(int key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (key < tmp.Value.Item1)
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
                else if (key == tmp.Value.Item1)
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

        public T Get(int key)
        {
            MyTreeMapNode<T> tmp = root;
            while (tmp != null)
            {
                if (key < tmp.Value.Item1)
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
                else if (key == tmp.Value.Item1)
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

        private void EntrySet(MyTreeMapNode<T> x)
        {
            if (x == null)
            {
                return;
            }
            EntrySet(x.Left);
            Console.WriteLine(x.Value.Item1 + " " + x.Value.Item2);
            EntrySet(x.Right);
        }

        public void EntrySet()
        {
            EntrySet(root);
        }

        private void KeySet(MyTreeMapNode<T> x)
        {
            if (x == null)
            {
                return;
            }
            KeySet(x.Left);
            Console.Write(x.Value.Item1 + " ");
            KeySet(x.Right);
        }

        public void KeySet()
        {
            KeySet(root);
        }

        public void Put(int key, T value)
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

                    if (tmp.Value.Item1 == key)
                    {
                        return;
                    }
                    ++size;

                    newNode.Parent = tmp;

                    if (key < tmp.Value.Item1)
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

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Remove(int key)
        {
            if (root == null)
            {
                return;
            }

            MyTreeMapNode<T> v = Search(key);

            if (v.Value.Item1 != key)
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

        private int FirstKey(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                return x.Value.Item1;
            }
            return FirstKey(x.Left);
        }

        public int FirstKey()
        {
            return FirstKey(root);
        }

        private int LastKey(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                return x.Value.Item1;
            }
            return LastKey(x.Right);
        }

        public int LastKey()
        {
            return LastKey(root);
        }

        private void HeadMap(MyTreeMapNode<T> x, int end)
        {
            if (x == null)
            {
                return;
            }
            HeadMap(x.Left, end);
            if (x.Value.Item1 < end)
            {
                Console.WriteLine(x.Value.Item1 + " " + x.Value.Item2);
            }
            HeadMap(x.Right, end);
        }

        public void HeadMap(int end)
        {
            HeadMap(root, end);
        }

        private void SubMap(MyTreeMapNode<T> x, int begin, int end)
        {
            if (x == null)
            {
                return;
            }
            SubMap(x.Left, begin, end);
            if (x.Value.Item1 > begin && x.Value.Item1 < end)
            {
                Console.WriteLine(x.Value.Item1 + " " + x.Value.Item2);
            }
            SubMap(x.Right, begin, end);
        }

        public void SubMap(int begin, int end)
        {
            SubMap(root, begin, end);
        }

        private void TailMap(MyTreeMapNode<T> x, int begin)
        {
            if (x == null)
            {
                return;
            }
            TailMap(x.Left, begin);
            if (x.Value.Item1 > begin)
            {
                Console.WriteLine(x.Value.Item1 + " " + x.Value.Item2);
            }
            TailMap(x.Right, begin);
        }

        public void TailMap(int begin)
        {
            TailMap(root, begin);
        }
        
        public Tuple<int, T> LowerEntry(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 < key)
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
                return successor.Value;
            }
            return new Tuple<int, T>(0, default(T));
        }

        public Tuple<int, T> FloorEntry(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 <= key)
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
                return successor.Value;
            }
            return new Tuple<int, T>(0, default(T));
        }

        public Tuple<int, T> HigherEntry(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 > key)
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
                return successor.Value;
            }
            return new Tuple<int, T>(0, default(T));
        }

        public Tuple<int, T> CeilingEntry(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 >= key)
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
                return successor.Value;
            }
            return new Tuple<int, T>(0, default(T));
        }

        public int LowerKey(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 < key)
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
            return 0;
        }

        public int FloorKey(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 <= key)
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
            return 0;
        }

        public int HigherKey(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 > key)
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

            return 0;
        }

        public int CeilingKey(int key)
        {
            MyTreeMapNode<T> current = root, successor = null;
            while (current != null)
            {
                if (current.Value.Item1 >= key)
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

            return 0;
        }

        private Tuple<int, T> PollFirstEntry(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                Tuple<int, T> first = x.Value;
                DeleteNode(x);
                return first;
            }
            return PollFirstEntry(x.Left);
        }

        public Tuple<int, T> PollFirstEntry()
        {
            return PollFirstEntry(root);
        }

        private Tuple<int, T> PollLastEntry(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                Tuple<int, T> first = x.Value;
                DeleteNode(x);
                return first;
            }
            return PollLastEntry(x.Right);
        }

        public Tuple<int, T> PollLastEntry()
        {
            return PollLastEntry(root);
        }

        private Tuple<int, T> FirstEntry(MyTreeMapNode<T> x)
        {
            if (x.Left == null)
            {
                Tuple<int, T> first = x.Value;
                return first;
            }
            return FirstEntry(x.Left);
        }

        public Tuple<int, T> FirstEntry()
        {
            return FirstEntry(root);
        }

        private Tuple<int, T> LastEntry(MyTreeMapNode<T> x)
        {
            if (x.Right == null)
            {
                Tuple<int, T> first = x.Value;
                return first;
            }
            return LastEntry(x.Right);
        }

        public Tuple<int, T> LastEntry()
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
    }
}
