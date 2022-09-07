using System;
using static HW1_JoshuaLong.BST;

namespace HW1_JoshuaLong
{

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
                tree.print_num_of_levels();
                tree.print_min_num_of_levels();
                //tree.print_num_of_leaves();
                //tree.print_num_of_full_nodes();
               
                Console.WriteLine("Enter 1 to continue or 0 to exit: ");
                option = Convert.ToInt32(Console.ReadLine());
            }
            
        }
    }
}
