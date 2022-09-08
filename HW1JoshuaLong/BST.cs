using System;
using System.Collections.Generic;
using System.Text;

namespace HW1JoshuaLong
{
    //I include class Node into the BST class because they are related and Node is only used in BST
    public class Node
    {
        //store int as data
        public int Data;
        //store left node
        public Node Left;
        //store right node
        public Node Right;
        //constructor for Node
        public Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }

    //class for Binary search tree
    public class BST
    {
        //the root node for BST
        public Node Root;

        //constructor for BST
        public BST()
        {
            Root = null;
        }

        //Add an element to the BST by not violating the BST properties.
        public void Insert(int data)
        {
            Root = Insert(Root, data);
        }
        //this will be called recursively 
        public Node Insert(Node root, int data)
        {


            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            else
            {
                //insert to left if data is smaller than root
                if (data < root.Data)
                {
                    root.Left = Insert(root.Left, data);
                }
                //insert to right if data is bigger than rott
                else if (data > root.Data)
                {
                    root.Right = Insert(root.Right, data);
                }
                //pass if equal because BSS have no duplicate
                else
                {
                    
                }
            }
            return root;


        }

        //Display the numbers in sorted order (smallest first, largest last). 
        public void Inorder()
        {
            Inorder(Root);
        }

        ////this will be called recursively 
        public void Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.Left);
                Console.WriteLine(root.Data);
                Inorder(root.Right);
            }
        }
        //Number of items
        public void PrintNumOfNodes()
        {
            Console.WriteLine("Number of nodes: " + NumOfNodes(Root));
        }
        //this will be called recursively 
        public int NumOfNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + NumOfNodes(root.Left) + NumOfNodes(root.Right);
            }
        }

        //number of levels in tree
        public void PrintNumOfLevels()
        {
            Console.WriteLine("Number of levels: " + NumOfLevels(Root));
        }
        ////this will be called recursively 
        public int NumOfLevels(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int left = NumOfLevels(root.Left);
                int right = NumOfLevels(root.Right);

                if (left > right)
                {
                    return left + 1;
                }
                else
                {
                    return right + 1;
                }
            }
        }
        //Theoretical minimum number of levels that the tree could have given the number of  nodes it contains
        public void PrintMinNumOfLevels()
        {
            Console.WriteLine("Minimum number of levels: " + MinNumOfLevels(Root));
        }
        ////this will be called recursively 
        public int MinNumOfLevels(Node root)
        {
            int n = NumOfNodes(root);
            int min = (int)Math.Log(n + 1, 2);
            return min;
        }

        //leaves not levels
        //this is not requied for HW1 but I add this for practice
        //Number of leaves in the tree
        public void PrintNumOfLeaves()
        {
            Console.WriteLine("Number of leaves: " + NumOfLeaves(Root));
        }
        ////this will be called recursively 
        public int NumOfLeaves(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.Left == null && root.Right == null)
            {
                return 1;
            }
            else
            {
                return NumOfLeaves(root.Left) + NumOfLeaves(root.Right);
            }
        }

        //this is not requied for HW1 but I add this for practice
        //display number of full nodes
        public void PrintNumOfFullNodes()
        {
            Console.WriteLine("Number of full nodes: " + NumOfFullNodes(Root));
        }
        ////this will be called recursively 
        public int NumOfFullNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.Left != null && root.Right != null)
            {
                return 1 + NumOfFullNodes(root.Left) + NumOfFullNodes(root.Right);
            }
            else
            {
                return NumOfFullNodes(root.Left) + NumOfFullNodes(root.Right);
            }
        }

    }
}
