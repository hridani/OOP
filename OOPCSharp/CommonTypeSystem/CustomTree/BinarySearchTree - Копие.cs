using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {

        //private TreeNode<T> root;
        //static int count;

        private class TreeNode<T> : IComparable<TreeNode<T>>
        where T : IComparable<T>
        {
            internal T value;
            internal TreeNode<T> parent;
            internal TreeNode<T> leftChild;
            internal TreeNode<T> rightChild;

            public TreeNode(T value)
            {
                this.Value = value;
                this.Parent = null;
                this.LeftChild = null;
                this.RightChild = null;
            }

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
        private TreeNode<T> root;


        //public BinarySearchTree(T value, BinarySearchTree<T> leftChild, 
        //            BinarySearchTree<T> rightChild)
        //{
        //    if (value == null)
        //    {
        //        throw new ArgumentException
        //                   ("The node already has a parent");
        //    }

        //    TreeNode<T> leftChildNode = 
        //        leftChild != null ? leftChild.root : null;
        //    TreeNode<T> rightChildNode =
        //        rightChild != null ? rightChild.root : null;
        //    this.root = new TreeNode<T>(
        //            value, leftChildNode, rightChildNode);
        //}

        //public BinarySearchTree(T value)
        //        :this(value, null, null)
        //{
        //}

        public BinarySearchTree()
        {
            this.root = null;
        }
        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

        private void PrintInorder(TreeNode<T> root)
        {
            if(root==null)
            {
                return;
            }
            PrintInorder(root.LeftChild);
            Console.WriteLine(root.Value+ " ");
            PrintInorder(root.RightChild);
        }

        public void PrintInorder()
        {
 	        PrintInorder(this.Root);
            Console.WriteLine();
        }
         private TreeNode<T> Insert(T value, 
                   TreeNode<T> parentNode,
                   TreeNode<T> node)
        {
            if (node == null) 
            {
                node = new TreeNode<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);
                if(compareTo<0)
                {
                    node.LeftChild = Insert(value, node, node.LeftChild);
                }
                else
                {
                    node.RightChild = Insert(value, node, node.rightChild);
                }
                return node;
            }
        }
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException
                        ("Cannot insert null value");
            }
            this.root = Insert(value, null, root);
        }

        private TreeNode<T> Find(T value)
        {
            TreeNode<T> node = this.Root;
            while(node!=null)
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node=node.LeftChild;
                }
                else if(compareTo > 0)
                {
                    node=node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
       }
        public void Remove(T value)
        {
            TreeNode<T> nodeToDelete = Find(value);
            if(nodeToDelete==null)
            {
                return;
            }
            Remove(nodeToDelete);
        }

        private void Remove(TreeNode<T> node)
        {
            if(node.LeftChild!=null && node.RightChild!=null)
            {
                TreeNode<T> replacement = node.RightChild;
                while(replacement.LeftChild!=null)
                {
                    replacement = replacement.LeftChild;
                }
                node.Value=replacement.Value;
                node = replacement;
            }

            TreeNode<T> theChild = node.LeftChild != null ?
                node.LeftChild : node.RightChild;

            if(theChild!=null)
            {
                theChild.Parent = node.Parent;
                if(node.Parent==null)
                {
                    root = theChild;
                }
                else
                { 
                    if(node.Parent.LeftChild==node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                if(node.Parent==null)
                {
                    root = null;
                }
                else
                {
                    if(node.Parent.LeftChild==node)
                    {
                        node.Parent.LeftChild = null;
                    }
                    else
                    {
                        node.Parent.RightChild = null;
                    }
                }
            }
        }


    }
}
