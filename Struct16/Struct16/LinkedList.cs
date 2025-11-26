using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct16
{
    class LinkedListComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    class LinkedList<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        private int size = 0;
        private LinkedListComparer<T> comparer = new LinkedListComparer<T>();

        public LinkedList()
        {
            Node<T> head = null;
            Node<T> tail = null;
            int size = 0;
        }

        public LinkedList(T[] array)
        {
            size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Node<T> node = new Node<T>(array[i]);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                }
                tail = node;
            }
        }

        public void Add(T element)
        {
            try
            {
                Node<T> node = new Node<T>(element);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                }
                tail = node;
                ++size;
            }
            catch (OutOfMemoryLinkedListException exception)
            {
                Console.WriteLine(exception);
                return;
            }
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
            Node<T> head = null;
            Node<T> tail = null;
            int size = 0;
        }

        public bool Contains(T element)
        {
            Node<T> node = head;
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool ContainsAll(T[] elements)
        {
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

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Remove(T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            Node<T> node = head;
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    break;
                }
                node = node.Next;
            }

            if (node != null)
            {
                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    tail = node.Prev;
                }
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    head = node.Next;
                }
            }
            --size;
        }

        public void RemoveAll(T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Remove(array[i]);
            }
        }

        public void RetainAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            int wrongElementsCount = 0;

            Node<T> node = head;
            while (node != null)
            {
                for (int i = 0; i < elements.Length; ++i)
                {
                    if (comparer.Compare(node.Value, elements[i]) == 0)
                    {
                        ++wrongElementsCount;
                    }
                }
                node = node.Next;
            }
            T[] wrongElements = new T[wrongElementsCount];
            wrongElementsCount = 0;
            node = head;
            while (node != null)
            {
                for (int i = 0; i < elements.Length; ++i)
                {
                    if (comparer.Compare(node.Value, elements[i]) == 0)
                    {
                        wrongElements[wrongElementsCount] = node.Value;
                        ++wrongElementsCount;
                    }
                }
                node = node.Next;
            }
            RemoveAll(wrongElements);
        }

        public int Size()
        {
            return size;
        }

        public T[] ToArray()
        {
            T[] linkedListToArray = new T[size];
            Node<T> node = head;
            int index = 0;
            while (node != null)
            {
                linkedListToArray[index] = node.Value;
                ++index;
                node = node.Next;
            }
            return linkedListToArray;
        }

        public void Add(int index, T element)
        {
            try
            {
                if (index < 0 && index > size)
                {
                    throw new IndexOutOfRangeLinkedListException();
                }
                if (head == null)
                {
                    head.Value = element;
                    tail = head;
                    return;
                }
                Node<T> node = head;
                for (int i = 0; i < index; ++i)
                {
                    node = node.Next;
                }
                if (node == null)
                {
                    Node<T> newNode = new Node<T>(element);
                    newNode.Next = null;
                    newNode.Prev = tail;
                    tail.Next = newNode;
                    tail = newNode;
                }
                else
                {
                    Node<T> newNode = new Node<T>(element);
                    newNode.Next = node;
                    newNode.Prev = node.Prev;
                    if (node.Prev != null)
                    {
                        node.Prev.Next = newNode;
                    }
                    node.Prev = newNode;
                }
                ++size;
            }
            catch (OutOfMemoryLinkedListException exception)
            {
                Console.WriteLine(exception);
                return;
            }
        }

        public void AddAll(int index, T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Add(index, array[i]);
            }
        }

        public T Get(int index)
        {
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeLinkedListException();
            }
            Node<T> node = head;
            for (int i = 0; i < index; ++i)
            {
                node = node.Next;
            }
            return node.Value;
        }

        public int IndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            Node<T> node = head;
            int listIndex = 0;
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    return listIndex;
                }
                ++listIndex;
                node = node.Next;
            }
            return -1;
        }

        public int LastIndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            Node<T> node = tail;
            int listIndex = size - 1;
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    return listIndex;
                }
                --listIndex;
                node = node.Prev;
            }
            return -1;
        }

        public T Remove(int index)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeLinkedListException();
            }

            Node<T> node = head;
            for (int i = 0; i < index; ++i)
            {
                node = node.Next;
            }

            if (node == null)
            {
                return (T)default;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                tail = node.Prev;
            }
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }
            --size;
            return node.Value;
        }

        public void Set(int index, T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeLinkedListException();
            }

            Node<T> node = head;
            for (int i = 0; i < index; ++i)
            {
                node = node.Next;
            }
            node.Value = element;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            if (fromIndex > toIndex)
            {
                throw new InvalidIntervalArgumentException();
            }
            if (fromIndex < 0 || fromIndex >= size)
            {
                throw new IndexOutOfRangeLinkedListException();
            }
            if (toIndex < 0 || toIndex > size)
            {
                throw new IndexOutOfRangeLinkedListException();
            }

            Node<T> node = head;
            for (int i = 0; i < fromIndex; ++i)
            {
                node = node.Next;
            }

            T[] LinkedSubList = new T[toIndex - fromIndex];
            for (int i = fromIndex; i < toIndex; ++i)
            {
                LinkedSubList[i] = node.Value;
                node = node.Next;
            }

            return LinkedSubList;
        }

        public T Element()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            return head.Value;
        }

        public bool Offer(T element)
        {
            try
            {
                Add(element);
                return true;
            }
            catch (OutOfMemoryLinkedListException exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            return head.Value;
        }

        public T Poll()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            T headValue = head.Value;
            if (head.Next == null)
            {
                head = null;
                tail = null;
                --size;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            return headValue;
        }

        public void AddFirst(T element)
        {
            Node<T> node = new Node<T>(element);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                head.Prev = node;
                node.Next = head;
                head = node;
            }
            ++size;
        }

        public void AddLast(T element)
        {
            Node<T> node = new Node<T>(element);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            ++size;
        }

        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            return head.Value;
        }

        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            return tail.Value;
        }

        public bool OfferFirst(T element)
        {
            try
            {
                AddFirst(element);
                return true;
            }
            catch (OutOfMemoryLinkedListException exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public bool OfferLast(T element)
        {
            try
            {
                AddLast(element);
                return true;
            }
            catch (OutOfMemoryLinkedListException exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            T headValue = head.Value;
            RemoveFirst();
            return headValue;
        }

        public void Push(T element)
        {
            AddFirst(element);
        }

        public T PeekFirst()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            return GetFirst();
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            return GetLast();
        }

        public T PollFirst()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            T headValue = head.Value;
            RemoveFirst();
            return headValue;
        }

        public T PollLast()
        {
            if (IsEmpty())
            {
                return (T)default;
            }
            T tailValue = tail.Value;
            RemoveLast();
            return tailValue;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            if (head.Next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            --size;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }
            if (tail.Prev == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            --size;
        }

        public bool RemoveFirstOccurrence(T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }

            Node<T> node = head;
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    if (node.Next != null)
                    {
                        node.Next.Prev = node.Prev;
                    }
                    else
                    {
                        tail = node.Prev;
                    }
                    if (node.Prev != null)
                    {
                        node.Prev.Next = node.Next;
                    }
                    else
                    {
                        head = node.Next;
                    }
                    --size;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool RemoveLastOccurrence(T element)
        {
            if (IsEmpty())
            {
                throw new NullLinkedListException();
            }

            Node<T> node = tail;
            while (node != null)
            {
                if (comparer.Compare(node.Value, element) == 0)
                {
                    if (node.Next != null)
                    {
                        node.Next.Prev = node.Prev;
                    }
                    else
                    {
                        tail = node.Prev;
                    }
                    if (node.Prev != null)
                    {
                        node.Prev.Next = node.Next;
                    }
                    else
                    {
                        head = node.Next;
                    }
                    --size;
                    return true;
                }
                node = node.Prev;
            }
            return false;
        }
    }
}