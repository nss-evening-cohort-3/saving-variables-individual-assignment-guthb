using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SavingVariables.Models;

namespace SavingVariables.DAL
{
    //inheritance
    public class ApplicationContext : DbContext
    {
        //property
        public virtual DbSet<Constants> Constants { get; set; }

    }
}
