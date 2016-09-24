using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SavingVariables
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Expression myExpression = new Expression();
            Stack my_Stack = new Stack();

            //repeats until user stops
            bool running = true;
            while (running)
            {
                Console.Write(">>");
                var userEntered = Console.ReadLine();

                if (userEntered.ToLower() != "lastq")
                {
                    my_Stack.lastCommand = userEntered;
                }

                switch (userEntered)
                {
                    case "quit":
                    case "exit":
                        {
                            Console.WriteLine("Bye!!!");
                            Thread.Sleep(500);
                            Environment.Exit(0);
                            break;
                            
                        }
                    case "lastq":
                        {
                            Console.WriteLine(my_Stack.lastCommand);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(myExpression.parseStringEntered(userEntered));                      
                        }
                        Console.WriteLine();
                        break;
                }

            }
            Console.ReadKey();
        }
    }
}
