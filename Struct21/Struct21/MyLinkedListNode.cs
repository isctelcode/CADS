using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct21
{
    public class MyLinkedListNode<T>
    {
        private T value;
        private MyLinkedListNode<T> next;
        private MyLinkedListNode<T> prev;

        public MyLinkedListNode(T value)
        {
            this.value = value;
            next = null;
            prev = null;
        }

        public T Value { get { return value; } set { this.value = value; } }
        public MyLinkedListNode<T> Next { get { return next; } set { next = value; } }
        public MyLinkedListNode<T> Prev { get { return prev; } set { prev = value; } }
    }
}
