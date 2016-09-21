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
            mock_constants_table.As<IQueryable<Constants>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_constants_table.As<IQueryable<Constants>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            //Constants property will return fake database table
            mock_context.Setup(c => c.Constants).Returns(mock_constants_table.Object);

            //Constants property will return fake database table
            mock_constants_table.Setup(t => t.Add(It.IsAny<Constants>())).Callback((Constants c) => constants_list.Add(c));
            mock_constants_table.Setup(t => t.Remove(It.IsAny<Constants>())).Callback((Constants c) => constants_list.Remove(c));

        }

        [TestInitialize]
        
        public void Initialize()
        {
            //creating instaces to be used in tests
            mock_context = new Mock<ApplicationContext>();
            mock_constants_table = new Mock<DbSet<Constants>>();
            constants_list = new List<Constants>();  //fake database
            repo = new ApplicationRepository(mock_context.Object);

            ConnectMocksToDatastore();

        }

        [TestCleanup] //runs after every test
        public void TearDown()
        {
            repo = null;  // 
        }
        

        [TestMethod]  //test for repo class
        public void EnsureCanCreateRepoInstance()
        {
            ApplicationRepository repo = new ApplicationRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod] //teet for context class
        public void EnsureRepoHasContext()
        {
            //ApplicationRepository repo = new ApplicationRepository();

            ApplicationContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ApplicationContext));
        }
        
        [TestMethod]
        public void EnsureCanAddConstantsToDatabase()
        {

            //this is my first test that will require fakeing the database
            //Arrange
            //ConnectMocksToDatastore();
            //ApplicationRepository repo = new ApplicationRepository(mock_context.Object);
            


            Constants my_constant  = new Constants { ConstantName = 'a', Varible = 1};

            //Act
            repo.AddConstant(my_constant);
            int actual_constant_count = repo.GetConstant().Count;
            int expected_constant_count = 1;

            //Assert
            Assert.AreEqual(expected_constant_count, actual_constant_count);
        }

        [TestMethod]
        public void EnsureCanRemoveFromRepoInstance()
        {

        }

       


    }

}

