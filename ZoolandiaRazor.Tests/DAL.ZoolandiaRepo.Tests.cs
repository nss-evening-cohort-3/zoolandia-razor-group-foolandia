using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.DAL;
using Moq;
using ZoolandiaRazor.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ZoolandiaRazor.Tests
{
    [TestClass]
    public class DALZoolandiaRepoTests
    {
        Mock<ZoolandiaContext> mock_context { get; set; }
        
        //Animals Table and List
        Mock<DbSet<Animal>> mock_animal_table { get; set; }
        List<Animal> animals_list { get; set; }

        //Employees Table and List
        Mock<DbSet<Employee>> mock_employee_table { get; set; }
        List<Employee> employee_list { get; set; }

        //Habitats Table and List
        Mock<DbSet<Habitat>> mock_habitat_table { get; set; }
        List<Habitat> habitat_list { get; set; }

        ZoolandiaRepo repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var animal_queryable_list = animals_list.AsQueryable();
            var employee_queryable_list = employee_list.AsQueryable();
            var habitat_queryable_list = habitat_list.AsQueryable();

            /// ANIMAL ///
            // Each time Linq tries to query our "animal table", redirect the query to point at our queirable list INSTEAD of the real database
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(animal_queryable_list.Provider);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(animal_queryable_list.Expression);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(animal_queryable_list.ElementType);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(() => animal_queryable_list.GetEnumerator());

            /// EMPLOYEE ///
            // Each time Linq tries to query our "employee table", redirect the query to point at our queirable list INSTEAD of the real database
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(employee_queryable_list.Provider);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(employee_queryable_list.Expression);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(employee_queryable_list.ElementType);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(() => employee_queryable_list.GetEnumerator());

            /// HABITAT ///
            // Each time Linq tries to query our "animal table", redirect the query to point at our queirable list INSTEAD of the real database
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.Provider).Returns(habitat_queryable_list.Provider);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.Expression).Returns(habitat_queryable_list.Expression);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.ElementType).Returns(habitat_queryable_list.ElementType);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.GetEnumerator()).Returns(() => habitat_queryable_list.GetEnumerator());

            // These are now our tables the is representative of the REAL DATABASE.
            mock_context.Setup(c => c.Animals).Returns(mock_animal_table.Object);
            mock_context.Setup(c => c.Employees).Returns(mock_employee_table.Object);
            mock_context.Setup(c => c.Habitats).Returns(mock_habitat_table.Object);

            // Add stuff to our representatve tables
            mock_animal_table.Setup(t => t.Add(It.IsAny<Animal>())).Callback((Animal a) => animals_list.Add(a));
            mock_employee_table.Setup(t => t.Add(It.IsAny<Employee>())).Callback((Employee e) => employee_list.Add(e));
            mock_habitat_table.Setup(t => t.Add(It.IsAny<Habitat>())).Callback((Habitat h) => habitat_list.Add(h));
        }

        // RESET before each test
        [TestInitialize]
        public void Initialize()
        {
            // Populate mock context
            mock_context = new Mock<ZoolandiaContext>();
            //Animals
            mock_animal_table = new Mock<DbSet<Animal>>();
            animals_list = new List<Animal>();
            //Employees
            mock_employee_table = new Mock<DbSet<Employee>>();
            employee_list = new List<Employee>();
            repo = new VariablesRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
