using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SavingVariables.Models;

namespace SavingVariables.DAL
{
    class ApplicationContext :DbContext
    {
        public virtual DbSet<Constants> Constants { get; set; }

    }
}
