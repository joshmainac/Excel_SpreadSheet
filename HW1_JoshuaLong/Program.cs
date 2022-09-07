using System;

namespace HW1_JoshuaLong
{
    //make binary search tree in C#
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

        //public void delete(int data)
        //{
        //    root = delete(root, data);
        //}

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



        //public void preorder()
        //{
        //    preorder(root);
        //}

        //public void postorder()
        //{
        //    postorder(root);
        //}

    }
    //test
    //55 22 77 88 11 22 44 77 55 99 22
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int option = 1;
            BST tree = new BST();
            while (option == 1)
            {
                Console.WriteLine("Enter a number to insert into the tree(No spaces at end): ");
                


                string str = Console.ReadLine();
                Console.WriteLine("");
                var result = str.Split(' ');
                foreach(var s in result)
                {
                    tree.insert(Convert.ToInt32(s));
                }
                
                tree.inorder();
                tree.print_num_of_nodes();
                tree.print_num_of_leaves();
                tree.print_num_of_full_nodes();
                tree.print_num_of_levels();
                tree.print_min_num_of_levels();
                Console.WriteLine("Enter 1 to continue or 0 to exit: ");
                option = Convert.ToInt32(Console.ReadLine());
            }
            
            //BST obj1 = new BST();
            //obj1.insert(55);
            //obj1.insert(22);
            //obj1.insert(77);
            //obj1.insert(88);
            //obj1.insert(11);
            //obj1.insert(22);
            //obj1.insert(44);
            //obj1.insert(77);
            //obj1.insert(55);
            //obj1.insert(99);
            //obj1.insert(22);
            //obj1.inorder();
            //obj1.print_num_of_nodes();
            //obj1.print_num_of_leaves();
            //obj1.print_num_of_full_nodes();
            //obj1.print_num_of_levels();
            //obj1.print_min_num_of_levels();
        }
    }
}
