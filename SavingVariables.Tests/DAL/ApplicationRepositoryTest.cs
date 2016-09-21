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
        ApplicationRepository repo { get; set; }

        //create method for Mock Datastore
        public void ConnectMocksToDatastore()
        {
            var queryable_list = constants_list.AsQueryable();

            //These lines trick LINQ, impersonates a Database table
            mock_constants_table.As<IQueryable<Constants>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_constants_table.As<IQueryable<Constants>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_constants_table.As<IQueryable<Constants>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            //Constants property will return fake database table
            mock_context.Setup(c => c.Constants).Returns(mock_constants_table.Object);

            //Constants property will retrun fake database table
            mock_constants_table.Setup(t => t.Add(It.IsAny<Constants>())).Callback((Constants c) => constants_list.Add(c));
            mock_constants_table.Setup(t => t.Remove(It.IsAny<Constants>())).Callback((Constants c) => constants_list.Remove(c));

        }



        [TestMethod]
        public void EnsureCanCreateRepoInstance()
        {
            ApplicationRepository repo = new ApplicationRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureRepoHasContext()
        {
            ApplicationRepository repo = new ApplicationRepository();

            ApplicationContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ApplicationContext));
        }


        [TestMethod]
        public void EnsureCanAddConstantsToDatabase()
        {
            
            //this is my first test that will require faking the databaser
            //Arrange
            ApplicationRepository repo = new ApplicationRepository();
            ConnectMocksToDatastore();


            Constants my_contstant  = new Constants { ConstantName = 'a', Varible = 1};

            //Act
           

            //Assert
    
        }

        [TestMethod]
        public void EnsureCanRemoveFromRepoInstance()
        {

        }

       


    }

}

