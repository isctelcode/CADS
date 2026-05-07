using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct24
{
    class MyTreeMapNode<T>
    {
        private Tuple<int, T> value;
        private MyTreeMapNode<T> left;
        private MyTreeMapNode<T> right;
        private MyTreeMapNode<T> parent;
        private bool isRed;

        public MyTreeMapNode(int value1, T value2)
        {
            value = new Tuple<int, T>(value1, value2);
            left = null;
            right = null;
            parent = null;
            isRed = true;
        }

        public Tuple<int, T> Value { get { return value; } set { this.value = value; } }
        public MyTreeMapNode<T> Left { get { return left; } set { left = value; } }
        public MyTreeMapNode<T> Right { get { return right; } set { right = value; } }
        public MyTreeMapNode<T> Parent { get { return parent; } set { parent = value; } }
        public bool IsRed { get { return isRed; } set { isRed = value; } }

        public MyTreeMapNode<T> Uncle()
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

        public MyTreeMapNode<T> Sibling()
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

        public void MoveDown(MyTreeMapNode<T> newParent)
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
