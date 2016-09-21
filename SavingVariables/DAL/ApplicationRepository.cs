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
        

        public ApplicationContext Context { get; set; }

        public ApplicationRepository()
        {
            Context = new ApplicationContext();
        }

        public ApplicationRepository(ApplicationContext _context)
        {
            Context = _context;
        }

        public void AddConstant(Constants my_constant)
        {
            Context.Constants.Add(my_constant);
            Context.SaveChanges();
        }

        public List<Constants> GetConstant()
        {
            return Context.Constants.ToList();
        }

        
    }
}
