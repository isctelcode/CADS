using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public class ArrayDequeComparer<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer<T>.Default.Compare(a, b);
        }
    }

    public class MyArrayDeque<T> : MyList<T>, MyDeque<T>
    {
        private T[] elementData = new T[0];
        private int size = 0;
        private int capacity = 0;
        private int head = 0;
        private int tail = 0;
        private ArrayDequeComparer<T> comparer = new ArrayDequeComparer<T>();

        public class MyItr<T> : Collections1.MyIterator<T>
        {
            T[] arrayDeque;

            int cursor = -1;

            public MyItr(T[] elements)
            {
                arrayDeque = elements;
            }

            public bool HasNext()
            {
                try
                {
                    T next = arrayDeque[cursor + 1];
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public T Next()
            {
                try
                {
                    ++cursor;
                    return arrayDeque[cursor];
                }
                catch
                {
                    throw new InvalidOperationException();
                }
            }

            public void Reset()
            {
                cursor = -1;
            }
        }

        public MyItr<T> Iterator()
        {
            return new MyItr<T>(ToArray());
        }

        public MyArrayDeque()
        {
            size = 0;
            capacity = 16;
            elementData = new T[capacity];
            head = 8;
            tail = 8;
        }

        public MyArrayDeque(T[] array)
        {
            size = array.Length;
            capacity = size;
            elementData = new T[capacity];
            for (int i = 0; i < size; ++i)
            {
                elementData[i] = array[i];
            }
        }

        public MyArrayDeque(int initialCapacity)
        {
            size = 0;
            capacity = initialCapacity;
            elementData = new T[capacity];
            head = initialCapacity / 2;
            tail = initialCapacity / 2;
        }

        public void Add(T element)
        {
            if (size == capacity)
            {
                try
                {
                    int newCapacity = capacity * 2;
                    T[] newElementData = new T[newCapacity];
                    int newHead = head;
                    int newTail = head + size;
                    newElementData[newHead] = elementData[head];
                    for (int i = head + 1, j = newHead + 1; i != tail; i = (i + 1) % capacity, ++j)
                    {
                        newElementData[j] = elementData[i];
                    }
                    capacity = newCapacity;
                    head = newHead;
                    tail = newTail;
                    elementData = newElementData;
                }
                catch (OutOfMemoryArrayDequeException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            elementData[tail] = element;
            tail = (tail + 1) % capacity;
            ++size;
        }

        public void AddAll(T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Add(array[i]);
            }
        }

        public void Add(int index, T element)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeArrayDequeException();
            }
            if (size == capacity)
            {
                try
                {
                    int newCapacity = capacity * 2;
                    T[] newElementData = new T[newCapacity];
                    int newHead = head;
                    int newTail = head + size;
                    newElementData[newHead] = elementData[head];
                    for (int i = head + 1, j = newHead + 1; i != tail; i = (i + 1) % capacity, ++j)
                    {
                        newElementData[j] = elementData[i];
                    }
                    capacity = newCapacity;
                    head = newHead;
                    tail = newTail;
                    elementData = newElementData;
                }
                catch (OutOfMemoryArrayDequeException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            T tmp = elementData[(head + index) % capacity];
            elementData[(head + index) % capacity] = element;
            for (int i = (head + index + 1) % capacity; i != tail; i = (i + 1) % capacity)
            {
                (tmp, elementData[i]) = (elementData[i], tmp);
            }
            elementData[tail] = tmp;
            tail = (tail + 1) % capacity;
            ++size;
        }

        public void AddAll(int index, T[] elements)
        {
            for (int i = 0; i < elements.Length; ++i)
            {
                Add(index + i, elements[i]);
            }
        }

        public void Clear()
        {
            size = 0;
            capacity = 16;
            elementData = new T[capacity];
            head = 8;
            tail = 8;
        }

        public bool Contains(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head; i != tail || isFull; i = (i + 1) % capacity)
            {
                isFull = false;
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
                throw new NullArrayDequeException();
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
                throw new NullArrayDequeException();
            }
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head; i != tail || isFull; i = (i + 1) % capacity)
            {
                isFull = false;
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    for (int j = i; j != tail - 1; j = (j + 1) % capacity)
                    {
                        elementData[j] = elementData[(j + 1) % capacity];
                    }
                    if (tail == 0)
                    {
                        tail = capacity - 1;
                    }
                    else
                    {
                        --tail;
                    }
                    ++size;
                    return;
                }
            }
        }

        public void RemoveElementAt(int index)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head, k = 0; i != tail || isFull; i = (i + 1) % capacity, ++k)
            {
                isFull = false;
                if (index == k)
                {
                    for (int j = i; j != tail - 1; j = (j + 1) % capacity)
                    {
                        elementData[j] = elementData[(j + 1) % capacity];
                    }
                    if (tail == 0)
                    {
                        tail = capacity - 1;
                    }
                    else
                    {
                        --tail;
                    }
                    ++size;
                    return;
                }
            }
        }

        public int IndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            for (int i = head, j = 0; i != tail; i = (i + 1) % capacity, ++j)
            {
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    return j;
                }
            }
            return -1;
        }

        public int LastIndexOf(T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            int lastIndex = -1;
            for (int i = head, j = 0; i != tail; i = (i + 1) % capacity, ++j)
            {
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    lastIndex = j;
                }
            }
            return lastIndex;
        }

        public void RemoveAll(T[] elements)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
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
                throw new NullArrayDequeException();
            }
            int wrongElementsCount = 0;
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head; i != tail || isFull; i = (i + 1) % capacity)
            {
                isFull = false;
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
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head; i != tail || isFull; i = (i + 1) % capacity)
            {
                isFull = false;
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
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            T[] arrayListToArray = new T[size];
            for (int i = head, j = 0; i != tail || isFull; i = (i + 1) % capacity, ++j)
            {
                isFull = false;
                arrayListToArray[j] = elementData[i];
            }
            return arrayListToArray;
        }

        public T Element()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            return elementData[head];
        }

        public bool Offer(T element)
        {
            if (size == capacity)
            {
                return false;
            }
            else
            {
                Add(element);
                return true;
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            return elementData[head];
        }

        public T Poll()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            T headData = elementData[head];
            head = (head + 1) % capacity;
            --size;
            return headData;
        }

        public void AddFirst(T element)
        {
            if (size == capacity)
            {
                try
                {
                    int newCapacity = capacity * 2;
                    T[] newElementData = new T[newCapacity];
                    int newHead = head;
                    int newTail = head + size;
                    for (int i = head, j = newHead; i != tail; i = (i + 1) % capacity, ++j)
                    {
                        newElementData[j] = elementData[i];
                        Console.WriteLine(elementData[i]);
                    }
                    capacity = newCapacity;
                    head = newHead;
                    tail = newTail;
                    elementData = newElementData;
                }
                catch (OutOfMemoryArrayDequeException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
            }
            if (head == 0)
            {
                head = capacity - 1;
            }
            else
            {
                --head;
            }
            elementData[head] = element;
            ++size;
        }

        public void AddLast(T element)
        {
            Add(element);
        }

        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            return elementData[head];
        }

        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            if (tail == 0)
            {
                return elementData[capacity - 1];
            }
            return elementData[tail - 1];
        }

        public T Get(int index)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            return elementData[(head + index) % capacity];
        }

        public void Set(int index, T element)
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            elementData[(head + index) % capacity] = element;
        }

        public bool OfferFirst(T element)
        {
            if (size == capacity)
            {
                return false;
            }
            else
            {
                AddFirst(element);
                return true;
            }
        }

        public bool OfferLast(T element)
        {
            if (size == capacity)
            {
                return false;
            }
            else
            {
                AddLast(element);
                return true;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            T headData = elementData[head];
            head = (head + 1) % capacity;
            --size;
            return headData;
        }

        public void Push(T element)
        {
            AddFirst(element);
        }

        public T PeekFirst()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            return elementData[head];
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            if (tail == 0)
            {
                return elementData[capacity - 1];
            }
            return elementData[tail - 1];
        }

        public T PollFirst()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            T headData = elementData[head];
            head = (head + 1) % capacity;
            return headData;
        }

        public T PollLast()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            T tailData;
            if (tail == 0)
            {
                tailData = elementData[capacity - 1];
                tail = capacity - 1;
            }
            else
            {
                tailData = elementData[tail - 1];
                --tail;
            }
            return tailData;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            T headData = elementData[head];
            head = (head + 1) % capacity;
            return headData;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new NullArrayDequeException();
            }
            T tailData;
            if (tail == 0)
            {
                tailData = elementData[capacity - 1];
                tail = capacity - 1;
            }
            else
            {
                tailData = elementData[tail - 1];
                --tail;
            }
            return tailData;
        }

        public bool RemoveFirstOccurrence(T element)
        {
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = head; i != tail || isFull; i = (i + 1) % capacity)
            {
                isFull = false;
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    for (int j = i; j != tail - 1; j = (j + 1) % capacity)
                    {
                        elementData[j] = elementData[(j + 1) % capacity];
                    }
                    if (tail == 0)
                    {
                        tail = capacity - 1;
                    }
                    else
                    {
                        --tail;
                    }
                    ++size;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveLastOccurrence(T element)
        {
            bool isFull = false;
            if (size == capacity)
            {
                isFull = true;
            }
            for (int i = tail; i != head || isFull; --i)
            {
                isFull = false;
                if (comparer.Compare(elementData[i], element) == 0)
                {
                    for (int j = i; j != tail - 1; j = (j + 1) % capacity)
                    {
                        elementData[j] = elementData[(j + 1) % capacity];
                    }
                    if (tail == 0)
                    {
                        tail = capacity - 1;
                    }
                    else
                    {
                        --tail;
                    }
                    ++size;
                    return true;
                }
                if (i == 0)
                {
                    i = capacity;
                }
            }
            return false;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            T[] subList = new T[toIndex - fromIndex + 1];
            int index = 0;
            for (int i = (head + fromIndex) % capacity; i != toIndex; i = (i + 1) % capacity)
            {
                subList[index] = elementData[i];
            }
            return subList;
        }
    }
}
