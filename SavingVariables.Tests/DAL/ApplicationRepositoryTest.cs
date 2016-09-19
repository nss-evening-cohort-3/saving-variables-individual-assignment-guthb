using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavingVariables.DAL;
using System.Collections.Generic;
using SavingVariables.Models;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace SavingVariables.Tests.DAL
{
    [TestClass]
    public class ApplicationRepositoryTest
    {

        //create Mock ApplicationContext
        Mock<ApplicationContext> mock_context { get; set; }
        Mock<DbSet<Constants>> mock_constants_table { get; set; }
        List<Constants> constants_list { get; set; } //this is my fake database
        




    }
}

