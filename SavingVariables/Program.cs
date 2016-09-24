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
            Stack my_Stack = new Stack();


            //repeats until user stops
            bool running = true;
            while (running)
            {
                Console.Write(">>");
                var userEntered = Console.ReadLine();

                //check input for

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
                            
                            //clear varible
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
