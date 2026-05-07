using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct19
{
    public class TreeSetComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }
    public class MyTreeSet<T>
    {
        private MyTreeSetNode<T> root = null;
        private int size = 0;
        private TreeSetComparer<T> comparer = new TreeSetComparer<T>();
        private T[] set = new T[0];
        private int index = 0;

        private void LeftRotate(MyTreeSetNode<T> x)
        {
            MyTreeSetNode<T> newParent = x.Right;

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

        private void RightRotate(MyTreeSetNode<T> x)
        {
            MyTreeSetNode<T> newParent = x.Left;

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

        private void SwapColors(MyTreeSetNode<T> x1, MyTreeSetNode<T> x2)
        {
            bool tmp = x1.IsRed;
            x1.IsRed = x2.IsRed;
            x2.IsRed = tmp;
        }

        private void SwapValues(MyTreeSetNode<T> x1, MyTreeSetNode<T> x2)
        {
            Tuple<T, bool> tmp = x1.Value;
            x1.Value = x2.Value;
            x2.Value = tmp;
        }

        private void FixRedRed(MyTreeSetNode<T> x)
        {
            if (x == root)
            {
                x.IsRed = false;
                return;
            }

            MyTreeSetNode<T> parent = x.Parent, grandparent = parent.Parent, uncle = x.Uncle();

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

        private MyTreeSetNode<T> Successor(MyTreeSetNode<T> x)
        {
            MyTreeSetNode<T> tmp = x;
            while (tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        private MyTreeSetNode<T> Replace(MyTreeSetNode<T> x)
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

        private void DeleteNode(MyTreeSetNode<T> v)
        {
            MyTreeSetNode<T> u = Replace(v);

            bool uvBlack = ((u == null || !u.IsRed) && !v.IsRed);
            MyTreeSetNode<T> parent = v.Parent;

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

        private void FixDoubleBlack(MyTreeSetNode<T> x)
        {
            if (x == root)
            {
                return;
            }

            MyTreeSetNode<T> sibling = x.Sibling(), parent = x.Parent;

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

        private MyTreeSetNode<T> Search(T key)
        {
            MyTreeSetNode<T> tmp = root;
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

        public void Add(T value)
        {
            try
            {
                MyTreeSetNode<T> newNode = new MyTreeSetNode<T>(value);
                if (root == null)
                {
                    newNode.IsRed = false;
                    root = newNode;
                }
                else
                {
                    MyTreeSetNode<T> tmp = Search(value);

                    if (comparer.Compare(tmp.Value.Item1, value) == 0)
                    {
                        return;
                    }
                    ++size;

                    newNode.Parent = tmp;

                    if (comparer.Compare(value, tmp.Value.Item1) < 0)
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
            catch (OutOfMemoryTreeSetException exception)
            {
                Console.WriteLine(exception);
                return;
            }
        }

        public void AddAll(T[] values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                Add(values[i]);
            }
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        public int Size()
        {
            return size;
        }

        private void Inorder(MyTreeSetNode<T> x)
        {
            if (x == null)
            {
                return;
            }
            Inorder(x.Left);
            set[index] = x.Value.Item1;
            ++index;
            Inorder(x.Right);
        }

        public void Inorder()
        {
            Inorder(root);
        }

        public T[] ToArray()
        {
            set = new T[size + 1];
            index = 0;
            Inorder();
            return set;
        }

        public bool Contains(T value)
        {
            MyTreeSetNode<T> tmp = root;
            while (tmp != null)
            {
                if (comparer.Compare(value, tmp.Value.Item1) < 0)
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
                else if (comparer.Compare(value, tmp.Value.Item1) == 0)
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

        public bool ContainsAll(T[] values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                if (!Contains(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Remove(T value)
        {
            if (root == null)
            {
                return;
            }

            MyTreeSetNode<T> v = Search(value);

            if (comparer.Compare(v.Value.Item1, value) != 0)
            {
                return;
            }

            DeleteNode(v);
            --size;
        }

        public void RemoveAll(T[] values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                Remove(values[i]);
            }
        }

        public void RetainAll(T[] values)
        {
            T[] setValues = ToArray();
            for (int i = 0; i < setValues.Length; ++i)
            {
                bool flag = false;
                for (int j = 0; j < values.Length; ++j)
                {
                    if (comparer.Compare(setValues[i], values[j]) == 0)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Remove(setValues[i]);
                }
            }
        }

        private T First(MyTreeSetNode<T> x)
        {
            if (x.Left == null)
            {
                return x.Value.Item1;
            }
            return First(x.Left);
        }

        public T First()
        {
            return First(root);
        }

        private T Last(MyTreeSetNode<T> x)
        {
            if (x.Right == null)
            {
                return x.Value.Item1;
            }
            return Last(x.Right);
        }

        public T Last()
        {
            return Last(root);
        }

        MyLinkedList<T> subSet;

        private void SubSetSearch(MyTreeSetNode<T> x, T fromElement, T toElement)
        {
            if (x == null)
            {
                return;
            }
            SubSetSearch(x.Left, fromElement, toElement);
            if (comparer.Compare(x.Value.Item1, fromElement) > 0 && comparer.Compare(x.Value.Item1, toElement) < 0)
            {
                subSet.AddLast(x.Value.Item1);
            }
            SubSetSearch(x.Right, fromElement, toElement);
        }

        public MyLinkedList<T> SubSet(T fromElement, T toElement)
        {
            subSet = new MyLinkedList<T>();
            SubSetSearch(root, fromElement, toElement);
            return subSet;
        }

        MyLinkedList<T> headSet;

        private void HeadSetSearch(MyTreeSetNode<T> x, T toElement)
        {
            if (x == null)
            {
                return;
            }
            HeadSetSearch(x.Left, toElement);
            if (comparer.Compare(x.Value.Item1, toElement) < 0)
            {
                headSet.AddLast(x.Value.Item1);
            }
            HeadSetSearch(x.Right, toElement);
        }

        public MyLinkedList<T> HeadSet(T toElement)
        {
            headSet = new MyLinkedList<T>();
            HeadSetSearch(root, toElement);
            return headSet;
        }

        MyLinkedList<T> tailSet;

        private void TailSetSearch(MyTreeSetNode<T> x, T fromElement)
        {
            if (x == null)
            {
                return;
            }
            TailSetSearch(x.Left, fromElement);
            if (comparer.Compare(x.Value.Item1, fromElement) > 0)
            {
                tailSet.AddLast(x.Value.Item1);
            }
            TailSetSearch(x.Right, fromElement);
        }

        public MyLinkedList<T> TailSet(T fromElement)
        {
            tailSet = new MyLinkedList<T>();
            TailSetSearch(root, fromElement);
            return tailSet;
        }

        public T Ceiling(T value)
        {
            MyTreeSetNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, value) >= 0)
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
        public T Floor(T value)
        {
            MyTreeSetNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, value) <= 0)
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

        public T Higher(T value)
        {
            MyTreeSetNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, value) > 0)
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

        public T Lower(T value)
        {
            MyTreeSetNode<T> current = root, successor = null;
            while (current != null)
            {
                if (comparer.Compare(current.Value.Item1, value) < 0)
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

        private void SubSetSearch(MyTreeSetNode<T> x, T lowerBound, bool lowIncl, T upperBound, bool highIncl)
        {
            if (x == null)
            {
                return;
            }
            SubSetSearch(x.Left, lowerBound, lowIncl, upperBound, highIncl);
            if ((comparer.Compare(x.Value.Item1, lowerBound) > 0 || lowIncl && comparer.Compare(x.Value.Item1, lowerBound) == 0) && (comparer.Compare(x.Value.Item1, upperBound) < 0 || highIncl && comparer.Compare(x.Value.Item1, upperBound) == 0))
            {
                subSet.AddLast(x.Value.Item1);
            }
            SubSetSearch(x.Right, lowerBound, lowIncl, upperBound, highIncl);
        }

        public MyLinkedList<T> SubSet(T lowerBound, bool lowIncl, T upperBound, bool highIncl)
        {
            subSet = new MyLinkedList<T>();
            SubSetSearch(root, lowerBound, lowIncl, upperBound, highIncl);
            return subSet;
        }

        private void HeadSetSearch(MyTreeSetNode<T> x, T upperBound, bool highIncl)
        {
            if (x == null)
            {
                return;
            }
            HeadSetSearch(x.Left, upperBound, highIncl);
            if (comparer.Compare(x.Value.Item1, upperBound) < 0 || highIncl && comparer.Compare(x.Value.Item1, upperBound) == 0)
            {
                headSet.AddLast(x.Value.Item1);
            }
            HeadSetSearch(x.Right, upperBound, highIncl);
        }

        public MyLinkedList<T> HeadSet(T upperBound, bool highIncl)
        {
            headSet = new MyLinkedList<T>();
            HeadSetSearch(root, upperBound, highIncl);
            return headSet;
        }

        private void TailSetSearch(MyTreeSetNode<T> x, T lowerBound, bool lowIncl)
        {
            if (x == null)
            {
                return;
            }
            TailSetSearch(x.Left, lowerBound, lowIncl);
            if (comparer.Compare(x.Value.Item1, lowerBound) > 0 || lowIncl && comparer.Compare(x.Value.Item1, lowerBound) == 0)
            {
                tailSet.AddLast(x.Value.Item1);
            }
            TailSetSearch(x.Right, lowerBound, lowIncl);
        }

        public MyLinkedList<T> TailSet(T lowerBound, bool lowIncl)
        {
            tailSet = new MyLinkedList<T>();
            TailSetSearch(root, lowerBound, lowIncl);
            return tailSet;
        }

        private T PollFirst(MyTreeSetNode<T> x)
        {
            if (x.Left == null)
            {
                T first = x.Value.Item1;
                DeleteNode(x);
                return first;
            }
            return PollFirst(x.Left);
        }

        public T PollFirst()
        {
            return PollFirst(root);
        }

        private T PollLast(MyTreeSetNode<T> x)
        {
            if (x.Right == null)
            {
                T first = x.Value.Item1;
                DeleteNode(x);
                return first;
            }
            return PollLast(x.Right);
        }

        public T PollLast()
        {
            return PollLast(root);
        }

        public IEnumerable<T> DescendingIterator()
        {
            T[] set = ToArray();
            for (int i = set.Length - 1; i >= 0; --i)
            {
                yield return set[i];
            }
        }

        public void DescendingSet()
        {
            T[] set = ToArray();
            for (int i = set.Length - 1; i >= 0; --i)
            {
                Console.WriteLine(set[i] + " ");
            }
        }

        public MyTreeSet()
        {
            root = null;
            size = 0;
            comparer = new TreeSetComparer<T>();
        }

        public MyTreeSet(TreeSetComparer<T> comparer)
        {
            root = null;
            size = 0;
            this.comparer = comparer;
        }
    }
}
