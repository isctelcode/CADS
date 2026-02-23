using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct19
{
    class Node<T>
    {
        private Tuple<T, bool> value;
        private Node<T> left;
        private Node<T> right;
        private Node<T> parent;
        private bool isRed;

        public Node(T value)
        {
            this.value = new Tuple<T, bool>(value, true);
            left = null;
            right = null;
            parent = null;
            isRed = true;
        }

        public Tuple<T, bool> Value { get { return value; } set { this.value = value; } }
        public Node<T> Left { get { return left; } set { left = value; } }
        public Node<T> Right { get { return right; } set { right = value; } }
        public Node<T> Parent { get { return parent; } set { parent = value; } }
        public bool IsRed { get { return isRed; } set { isRed = value; } }

        public Node<T> Uncle()
        {
            if (parent == null || parent.parent == null)
            {
                return null;
            }

            if (parent.IsOnLeft())
            {
                return parent.parent.right;
            }
            else
            {
                return parent.parent.left;
            }
        }

        public bool IsOnLeft()
        {
            return this == parent.left;
        }

        public Node<T> Sibling()
        {
            if (parent == null)
            {
                return null;
            }

            if (IsOnLeft())
            {
                return parent.right;
            }
            else
            {
                return parent.left;
            }
        }

        public void MoveDown(Node<T> newParent)
        {
            if (parent != null)
            {
                if (IsOnLeft())
                {
                    parent.left = newParent;
                }
                else
                {
                    parent.right = newParent;
                }
            }
            newParent.parent = parent;
            parent = newParent;
        }

        public bool HasRedChild()
        {
            return (left != null && left.isRed) || (right != null && right.isRed);
        }
    }
}
