using System;

namespace ConditionalBinaryTreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the depth of the tree: ");
            string inputString = Console.ReadLine();
            int inputDepth;
            if (Int32.TryParse(inputString, out inputDepth) == false)
            {
                Console.WriteLine("Please enter a valid number");
            }
            else if (inputDepth < 0 && inputDepth > 20)
            {
                Console.WriteLine("Please enter the depth between 0 and 20");
            }
            else { 

                Traverse traverse = new Traverse(inputDepth);
                traverse.Start_Traversing();
            }
            Console.ReadLine();
        }
    }
}
