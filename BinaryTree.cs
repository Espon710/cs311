using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace BinarySearchTree
{

    public class BinarySearchTree
    {
        public static int N = 21;
        public static int size = 20;
        public static int n = 1;
        public static int loc = 1;
        public static int val = 0;
        public static int[] Array = new int[N];

        public class Node
        {
            public int key;
            public int Data;
            public Node Left;
            public Node Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
        }
        public Node root;
        public Node ReturnRoot()
        {
            return root;
        }
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }                   
                }
            }
        }

        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Data + " ");
                Inorder(Root.Right);
            }
        }

        public static void AddToList()
        {
            if (n == 20)
                Console.WriteLine("The array is full");
            if (loc < n)
                for (int i = n - 1; i <= loc; i--)
                    Array[i + 1] = Array[i];
            Array[loc] = val;
            n = n + 1;
        }

        void deleteNode(int key)
        {
            root = deleteNode(root, key);
        }

        Node deleteNode(Node root, int key)
        {
            if (root == null) return root;

            if (key < root.key)
            {
                root.Left = deleteNode(root.Left, key);
            }
            else if (key > root.key)
            {
                root.Right = deleteNode(root.Right, key);
            }

            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.key = minValue(root.Right);
                root.Right = deleteNode(root.Right, root.key);
            }
            return root;
        }

        int minValue(Node root)
        {
            int min = root.key;
            while (root.Left != null)
            {
                min = root.Left.key;
                root = root.Left;
            }
            return min;
        }


        static void Main()
        {
            int delete;
            int insert;
            BinarySearchTree tree = new BinarySearchTree();
            while (size != 0)
            {
                Console.WriteLine("Enter a number for the array");
                val = Convert.ToInt32(Console.ReadLine());
                AddToList();
                loc += 1;
                size--;
            }
            
            foreach(int value in Array)
            {
                tree.Insert(value);
            }

            tree.Inorder(tree.ReturnRoot());
            Console.WriteLine("\nEnter a Value to Delete");
            delete = Convert.ToInt32(Console.ReadLine());
            tree.deleteNode(delete);
            tree.Inorder(tree.ReturnRoot());
            Console.WriteLine("\nEnter a Value to Enter");
            insert = Convert.ToInt32(Console.ReadLine());
            tree.Insert(insert);
            tree.Inorder(tree.ReturnRoot());
        }
    }
}


//Nick Bredhold & Sam Lehmkuhler
//The hardest part of the assignment was figuring out the implementation of the binary tree, we had some struggles so we consulted the internet for help
//Nick 55% Sam 45%