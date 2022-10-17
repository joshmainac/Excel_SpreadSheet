using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //make menu
            // Menu (current expression = "")
            // 1= Enter a new expression
            // 2 = Set a variable value
            // 3 = Evaluate tre
            // 4 = Quit
            Console.WriteLine("Welcome to the Expression Evaluator");
            Console.WriteLine("====================================");
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set a variable value");
            Console.WriteLine("3 = Evaluate tree");
            Console.WriteLine("4 = Quit");
            Console.WriteLine("====================================");
            Console.WriteLine("Please enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Please enter your expression: ");
                string expression = Console.ReadLine();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Please enter the variable name: ");
                string variable = Console.ReadLine();
                Console.WriteLine("Please enter the variable value: ");
                string value = Console.ReadLine();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Please enter the variable name: ");
                string variable = Console.ReadLine();
                Console.WriteLine("Please enter the variable value: ");
                string value = Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Expression Evaluator");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid choice");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
