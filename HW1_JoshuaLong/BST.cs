using System;
using System.Collections.Generic;
using System.Text;

namespace HW1_JoshuaLong
{
    //I include class Node into the BST class because they are related and Node is only used in BST
    class Node
    {
        //store int as data
        public int data;
        //store left node
        public Node left;
        //store right node
        public Node right;
        //constructor for Node
        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    //class for Binary search tree
    class BST
    {
        //the root node for BST
        public Node root;

        //constructor for BST
        public BST()
        {
            root = null;
        }

        //Add an element to the BST by not violating the BST properties.
        public void insert(int data)
        {
            root = insert(root, data);
        }
        //this will be called recursively 
        public Node insert(Node root, int data)
        {


            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            else
            {
                //insert to left if data is smaller than root
                if (data < root.data)
                {
                    root.left = insert(root.left, data);
                }
                //insert to right if data is bigger than rott
                else if (data > root.data)
                {
                    root.right = insert(root.right, data);
                }
                //pass if equal because BSS have no duplicate
                else
                {
                    
                }
            }
            return root;


        }

        //Display the numbers in sorted order (smallest first, largest last). 
        public void inorder()
        {
            inorder(root);
        }

        ////this will be called recursively 
        public void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.WriteLine(root.data);
                inorder(root.right);
            }
        }
        //Number of items
        public void print_num_of_nodes()
        {
            Console.WriteLine("Number of nodes: " + num_of_nodes(root));
        }
        //this will be called recursively 
        public int num_of_nodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + num_of_nodes(root.left) + num_of_nodes(root.right);
            }
        }

        //number of levels in tree
        public void print_num_of_levels()
        {
            Console.WriteLine("Number of levels: " + num_of_levels(root));
        }
        ////this will be called recursively 
        public int num_of_levels(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int left = num_of_levels(root.left);
                int right = num_of_levels(root.right);

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
        public void print_min_num_of_levels()
        {
            Console.WriteLine("Minimum number of levels: " + min_num_of_levels(root));
        }
        ////this will be called recursively 
        public int min_num_of_levels(Node root)
        {
            int n = num_of_nodes(root);
            int min = (int)Math.Log(n + 1, 2);
            return min;
        }

        //leaves not levels
        //this is not requied for HW1 but I add this for practice
        //Number of leaves in the tree
        public void print_num_of_leaves()
        {
            Console.WriteLine("Number of leaves: " + num_of_leaves(root));
        }
        ////this will be called recursively 
        public int num_of_leaves(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.left == null && root.right == null)
            {
                return 1;
            }
            else
            {
                return num_of_leaves(root.left) + num_of_leaves(root.right);
            }
        }

        //this is not requied for HW1 but I add this for practice
        //display number of full nodes
        public void print_num_of_full_nodes()
        {
            Console.WriteLine("Number of full nodes: " + num_of_full_nodes(root));
        }
        ////this will be called recursively 
        public int num_of_full_nodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.left != null && root.right != null)
            {
                return 1 + num_of_full_nodes(root.left) + num_of_full_nodes(root.right);
            }
            else
            {
                return num_of_full_nodes(root.left) + num_of_full_nodes(root.right);
            }
        }

    }
}
