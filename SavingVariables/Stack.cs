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
            public string lastCommand { get; set; }
            //public string lastAnswer { get; set; }

            //public Dictionary<string, int> constantDictionary = new Dictionary<string, int>();
            // set to private
            //add public method to


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
            return allconstants.ConstantListToString();
        }

        public string DeleteConstants(string enteredString)
        {
            ApplicationRepository repo = new ApplicationRepository();

            //repo.Context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Constants");
            return "Deleted all items from database!";
        }


    }
}


