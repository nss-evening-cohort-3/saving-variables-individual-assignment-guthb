using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SavingVariables.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SavingVariables.DAL.ApplicationContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SavingVariables.DAL.ApplicationContext context)
        {
           // base.Seed(context);
        }

    }
}
