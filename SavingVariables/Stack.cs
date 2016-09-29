using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.DAL;
using SavingVariables.Models;

namespace SavingVariables
{
    class Stack
    {
        //properties
        public string LastCommand { get; set; }

        public void AddConstant(string enteredConstant, int enteredInteger)
        {
            ApplicationRepository repo = new ApplicationRepository();
        
            repo.AddConstant(new Constants()
            {
                ConstantName = enteredConstant, Varible = enteredInteger
            });
        }

        public int FindConstant(string enteredConstant)
        {
            ApplicationRepository repo = new ApplicationRepository();

            Constants myConstant =  repo.FindConstantByConstantEntered(enteredConstant);

            return myConstant.Varible; 
        }

        public string RemoveConstant(string enteredString)
        {
            ApplicationRepository repo = new ApplicationRepository();
            
            Constants removedConstant = repo.RemoveConstants(enteredString);

            return removedConstant.ConstantName;
        }

        public string ShowConstants(string enteredString)
        {
            ApplicationRepository repo = new ApplicationRepository();

            List<Constants> allconstants = repo.GetConstant();

            if (allconstants.Count != 0)

            {

                return allconstants.ConstantListToString();
            }
            else
            {
                return "= Database empty! Nothing to show.";
            }

        }

        public string DeleteConstants(string enteredString)
        {
            ApplicationRepository repo = new ApplicationRepository();

            repo.Context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Constants");

            return "= deleted all items from database!";
        }

        public string ReturnHelp()
        {
            return "show all: prints out all variables (with their values) in tabular form saved within the database\r\nlastq: prints the last entered command or expression** even if it was unsuccessful**.\r\nquit | exit: exits the program";

        }

    }
}


