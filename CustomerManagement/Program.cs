using System;
using System.Collections.Generic;
using TurboCollections;

namespace CustomerManagement 
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new TurboList<int>();
            bool switchstatement = true;
            do
            {
                Console.WriteLine("Choose one option:\n(1) Add a Customer\n" +
                                  "(2) Remove a Customer by name\n" +
                                  "(3) Remove a Customer by index\n" +
                                  "(4) Display all Customers\n" +
                                  "(5) Exit");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("What is the Customer's name?");
                        break;
                    case 2:
                        Console.WriteLine("What is the Customer's name?");
                        break;
                    case 3:
                        Console.WriteLine("What index?");
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Good Bye");
                        switchstatement = false;
                        break;
                    default:
                        Console.WriteLine("Please Select One of the Above.");
                        break;
                }
            } while (switchstatement);
        }
    }
}
