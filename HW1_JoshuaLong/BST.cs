using System;
using System.Collections.Generic;
using System.Text;

namespace HW1_JoshuaLong
{
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }


    class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public void insert(int data)
        {
            root = insert(root, data);
        }

        public Node insert(Node root, int data)
        {


            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            else
            {
                if (data < root.data)
                {
                    root.left = insert(root.left, data);
                }
                else if (data > root.data)
                {
                    root.right = insert(root.right, data);
                }
                //else
                //{

                //}
            }
            return root;


        }


        public void inorder()
        {
            inorder(root);
        }

        public void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.WriteLine(root.data);
                inorder(root.right);
            }
        }

        public void print_num_of_nodes()
        {
            Console.WriteLine("Number of nodes: " + num_of_nodes(root));
        }

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

        public void print_num_of_leaves()
        {
            Console.WriteLine("Number of leaves: " + num_of_leaves(root));
        }

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


        public void print_num_of_full_nodes()
        {
            Console.WriteLine("Number of full nodes: " + num_of_full_nodes(root));
        }

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

        public void print_num_of_levels()
        {
            Console.WriteLine("Number of levels: " + num_of_levels(root));
        }

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

        public void print_min_num_of_levels()
        {
            Console.WriteLine("Minimum number of levels: " + min_num_of_levels(root));
        }

        public int min_num_of_levels(Node root)
        {
            int n = num_of_nodes(root);
            int min = (int)Math.Log(n + 1, 2);
            return min;
        }

    }
}
