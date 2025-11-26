using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct3
{
    class Node<T>
    {
        private T value;
        private Node<T> next;
        private Node<T> prev;

        public Node(T value)
        {
            this.value = value;
            next = null;
            prev = null;
        }

        public T Value { get { return value; } set { this.value = value; } }
        public Node<T> Next { get { return next; } set { next = value; } }
        public Node<T> Prev { get { return prev; } set { prev = value; } }
    }
}
