using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.Models;

namespace SavingVariables.DAL
{
    public class ApplicationRepository
    {
        //property
        public ApplicationContext Context { get; set; }

        //constructor
        public ApplicationRepository()
        {
            Context = new ApplicationContext();
        }

        //injection
        public ApplicationRepository(ApplicationContext _context)
        {
            Context = _context;
        }

        public void AddConstant(Constants my_constant)
        {
            if (FindConstantByConstantEntered(my_constant.ConstantName) == null)
            {
                Context.Constants.Add(my_constant);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Error! " + my_constant.ConstantName + " is already defined!");
            }
        }

        public List<Constants> GetConstant()
        {
            return Context.Constants.ToList();
        }

        public Constants RemoveConstants(string constants_entered)
        {
            Constants found_constant = FindConstantByConstantEntered(constants_entered);
            if (found_constant != null)
            {
                Context.Constants.Remove(found_constant);
                Context.SaveChanges();
                return found_constant;
            }
            else
            {
                throw new Exception("Error! constant doesn't exist");
            }
        }

        public Constants FindConstantByConstantEntered(string constants_entered)
        {
            Constants found_constant = Context.Constants.FirstOrDefault(rowinconstantstable => rowinconstantstable.ConstantName.ToString() == constants_entered.ToString
            ());
            return found_constant;
        }
    }
}
