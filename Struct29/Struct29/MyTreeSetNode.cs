using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public class MyTreeSetNode<T>
    {
        private Tuple<T, bool> value;
        private MyTreeSetNode<T> left;
        private MyTreeSetNode<T> right;
        private MyTreeSetNode<T> parent;
        private bool isRed;

        public MyTreeSetNode(T value)
        {
            this.value = new Tuple<T, bool>(value, true);
            left = null;
            right = null;
            parent = null;
            isRed = true;
        }

        public Tuple<T, bool> Value { get { return value; } set { this.value = value; } }
        public MyTreeSetNode<T> Left { get { return left; } set { left = value; } }
        public MyTreeSetNode<T> Right { get { return right; } set { right = value; } }
        public MyTreeSetNode<T> Parent { get { return parent; } set { parent = value; } }
        public bool IsRed { get { return isRed; } set { isRed = value; } }

        public MyTreeSetNode<T> Uncle()
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

        public MyTreeSetNode<T> Sibling()
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

        public void MoveDown(MyTreeSetNode<T> newParent)
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
