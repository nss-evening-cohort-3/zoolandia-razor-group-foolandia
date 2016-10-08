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

            // Each time Linq tries to query our "table", redirect the query to point at our queirable list INSTEAD of the real database
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            // This is now our table the is representative of the REAL DATABASE.
            mock_context.Setup(c => c.Variables).Returns(mock_variable_table.Object);

            // Add | Remove  stuff to our representatve table
            mock_variable_table.Setup(t => t.Add(It.IsAny<Variable>())).Callback((Variable v) => variable_list.Add(v));
            mock_variable_table.Setup(t => t.Remove(It.IsAny<Variable>())).Callback((Variable a) => variable_list.Remove(a));
            //mock_variable_table.Setup(t => t.Find(It.IsAny<string>())).Callback((string a) => variable_list.Find( x => x.VarSym == a));
            //mock_variable_table.Setup(t => t.Find(It.IsAny<string[]>())).Returns((string a) => variable_list.Find(x => x.VarSym == a));

        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
