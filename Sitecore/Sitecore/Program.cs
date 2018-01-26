using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consecutive Integers task");

            Tasks.ConsecutiveIntegers();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Palindrome task ignoring whitespace");

            Tasks.CheckIfPalindromeIgnoreWhitespace();
            
            Console.Write("Press any key to end the program....");
            Console.ReadKey();
        }
    }
}
