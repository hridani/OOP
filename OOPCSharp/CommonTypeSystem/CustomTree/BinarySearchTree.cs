

namespace CustomTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IEnumerable<T>, ICloneable
        where T : IComparable<T>
    {
        protected class TreeNode<T> :
            IComparable<TreeNode<T>>
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

            public static bool operator ==(TreeNode<T> node1,
                                       TreeNode<T> node2)
            {
                return TreeNode<T>.Equals(node1, node2);
            }

            public static bool operator !=(TreeNode<T> node1,
                                       TreeNode<T> node2)
            {
                return !TreeNode<T>.Equals(node1, node2);
            }
        }

        private TreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        protected TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public void PrintTree()
        {
            PrintInorder(this.Root, 0);
        }

        private void PrintInorder(TreeNode<T> node, int depth)
        {
            if (node == null)
            {
                for (int i = 0; i < depth; i++)
                {
                    Console.Write("\t");
                }

                Console.WriteLine("~");
            }
            else
            {
                PrintInorder(node.RightChild, depth + 1);
                for (int i = 0; i < depth; i++)
                {
                    Console.Write("\t");
                }
                Console.WriteLine(node.Value.ToString());
                PrintInorder(node.LeftChild, depth + 1);
            }
        }

        private TreeNode<T> Insert(T value, TreeNode<T> parentNode, TreeNode<T> node)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node.LeftChild = Insert(value, node, node.LeftChild);
                }
                else
                {
                    node.RightChild = Insert(value, node, node.rightChild);
                }
            }

            return node;
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
            TreeNode<T> node = this.root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.RightChild;
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
            if (nodeToDelete == null)
            {
                return;
            }
            Remove(nodeToDelete);
        }

        private void Remove(TreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                TreeNode<T> replacement = node.RightChild;
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }
                node.Value = replacement.Value;
                node = replacement;
            }

            TreeNode<T> theChild = node.LeftChild != null ?
                node.LeftChild : node.RightChild;

            if (theChild != null)
            {
                theChild.Parent = node.Parent;
                if (node.Parent == null)
                {
                    root = theChild;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
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
                if (node.Parent == null)
                {
                    root = null;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
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

        private IEnumerable<TreeNode<T>> Traversal(TreeNode<T> node)
        {
            if (node.LeftChild != null)
            {
                foreach (TreeNode<T> leftNode in Traversal(node.LeftChild))
                {
                    yield return leftNode;
                }
            }
            yield return node;

            if (node.RightChild != null)
            {
                foreach (TreeNode<T> rightNode in Traversal(node.RightChild))
                {
                    yield return rightNode;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (TreeNode<T> currentNode in Traversal(this.Root))
            {
                yield return currentNode.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (TreeNode<T> currentNode in Traversal(this.Root))
            {
                yield return currentNode.Value;
            }
        }

        public object Clone()
        {
            if (this.root == null)
                return null;
            BinarySearchTree<T> cloneBinaryTree = new BinarySearchTree<T>();
            CloneInorder(cloneBinaryTree, this.Root);

            return cloneBinaryTree;
        }

        private void CloneInorder(BinarySearchTree<T> cloneTree, TreeNode<T> node)
        {
            if (node == null)
                return;
            cloneTree.Insert(node.Value);
            CloneInorder(cloneTree, node.LeftChild);
            CloneInorder(cloneTree, node.RightChild);
        }
    }
}
