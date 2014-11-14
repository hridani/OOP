namespace CustomTree
{
    using System;
  
    class CustomTreeTest
    {
        static void Main()
        {
            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>();
            binaryTree.Insert(19);
            binaryTree.Insert(11);
            binaryTree.Insert(35);
            binaryTree.Insert(16);
            binaryTree.Insert(23);
            binaryTree.Insert(7);
            binaryTree.Insert(13);
            binaryTree.Insert(17);
            
            binaryTree.PrintTree();

            foreach (var item in binaryTree)
            {
                Console.WriteLine(item.ToString());
            }
            
            binaryTree.Remove(11);
           
            BinarySearchTree<int> clonebinaryTree = (BinarySearchTree<int>)binaryTree.Clone();
            binaryTree.PrintTree();
            
            clonebinaryTree.Remove(11);
            Console.WriteLine("New tree");
            clonebinaryTree.PrintTree();
        }
    }
}
