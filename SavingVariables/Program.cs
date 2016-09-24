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
            // need to add the data stuff here now there is no stack
            Expression myExpression = new Expression( );
            Evaluate myEvaluate = new Evaluate();

            //repeats until user stops
            bool running = true;
            while (running)
            {
                Console.Write(">>");
                var userEntered = Console.ReadLine();

                //check input for
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
                    default:
                        {

                            Console.WriteLine(myExpression.parseStringEntered(userEntered));
                            
                           
                           //call class based on user entered to handle the 
                            //following operations
                            
                            
                            //delete varible
                        }
                        Console.WriteLine();
                        break;

                }

            }
            Console.ReadKey();

        }
    }
}
