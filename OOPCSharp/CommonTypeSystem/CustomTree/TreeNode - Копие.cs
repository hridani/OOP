using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    private class TreeNode<T>:IComparable<TreeNode<T>>
        where T:IComparable<T>
    {
        internal T value;
        internal TreeNode<T> parent;
        internal TreeNode<T> leftChild;
        internal TreeNode<T> rightChild;

        private bool hasParent;

        //public TreeNode(T value, TreeNode<T> leftChild, TreeNode<T> rightChild)
        //{
        //    this.Value = value;
        //    this.LeftChild = leftChild;
        //    this.RightChild = rightChild;
        //}
        public TreeNode(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }

        //public TreeNode(T value):
        //    this(value,null,null)
        //{
        //}
        
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException
                            ("Cannot insert null value");
                }
                this.value = value;
            }
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                if (value == null)
                {
                    return;
                }
               // if (value.hasParent)
               // {
               //     throw new ArgumentException
               //             ("The node already has a parent");
               // }
               //value.hasParent = true;
               this.leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                if (value == null)
                {
                    return;
                }
                //if (value.hasParent)
                //{
                //    throw new ArgumentException
                //            ("The node already has a parent");
                //}
                //value.hasParent = true;
                this.rightChild = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                if (value == null)
                {
                    return;
                }
                //if (value.hasParent)
                //{
                //    throw new ArgumentException
                //            ("The node already has a parent");
                //}
                //value.hasParent = true;
                this.parent = value;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> other = (TreeNode<T>)obj;
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
