using System;
using lib;

namespace op1sh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("task 1? y/n\n");
            string a = Console.ReadLine();
            if (a == "y")
            {
                Console.WriteLine("Enter the number:\t");
                int num0 = Convert.ToInt32(Console.ReadLine());
                Mylib.Dim(num0);
            }
            else
            {
                Console.WriteLine("Enter two numbers:\n");
                int num0 = Convert.ToInt32(Console.ReadLine()); 
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Mylib.Compare(num0, num1));
            }
        }
    }
}
