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

        ZoolandiaRepository repo { get; set; }

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

//TODO: Adjust Sandy's Seeding method to adapt to testing environment

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
            //Habitat
            mock_habitat_table = new Mock<DbSet<Habitat>>();
            habitat_list = new List<Habitat>();

            repo = new ZoolandiaRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void CleanUp()
        {
            repo = null;
        }

        [TestMethod]
        public void ZoolandiaRepoIsCreatedInInitializeMethod()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnAListOfAllAnimals()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            List<DisplayAnimalInfo> actual_animals =  repo.GetAllAnimals();
 //TODO: Fill in with Sandy's seeding results
            List<DisplayAnimalInfo> expected_animals = new List<DisplayAnimalInfo> { };
            //Assert
            Assert.AreEqual(actual_animals, expected_animals);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificAnimalToDisplay()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            DisplayAnimalInfo actual_animal = repo.GetOneAnimalDetailsById(1);
//TODO: Fill in with Sandy's seeding results
            DisplayAnimalInfo expected_animal = new DisplayAnimalInfo { };
            //Assert
            Assert.AreEqual(actual_animal, expected_animal);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnAListOfAllEmployees()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            List<DisplayEmployeeInfo> actual_employees = repo.GetAllEmployees();
//TODO: Fill in with Sandy's seeding results
            List<DisplayEmployeeInfo> expected_employees = new List<DisplayEmployeeInfo> { };
            //Assert
            Assert.AreEqual(actual_employees, expected_employees);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificEmployeeToDisplay()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            DisplayEmployeeInfo actual_employee = repo.GetOneEmployeeDetailsById(1);
//TODO: Fill in with Sandy's seeding results
            DisplayEmployeeInfo expected_employee = new DisplayEmployeeInfo { };
            //Assert
            Assert.AreEqual(actual_employee, expected_employee);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnAListOfAllHabitats()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            List<DisplayHabitatInfo> actual_habitats = repo.GetAllHabitats();
//TODO: Fill in with Sandy's seeding results
            List<DisplayHabitatInfo> expected_habitats = new List<DisplayHabitatInfo> { };
            //Assert
            Assert.AreEqual(actual_habitats, expected_habitats);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificHabitatToDisplay()
        {
            //Arrange
//TODO: Call Sandy's Seeding method
            //Act
            DisplayHabitatInfo actual_habitat = repo.GetOneHabitatDetailsById(1);
//TODO: Fill in with Sandy's seeding results
            DisplayHabitatInfo expected_habitat = new DisplayHabitatInfo { };
            //Assert
            Assert.AreEqual(actual_habitat, expected_habitat);
        }
    }
}
