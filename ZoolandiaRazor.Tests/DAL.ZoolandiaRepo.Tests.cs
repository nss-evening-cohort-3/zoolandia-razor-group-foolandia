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

        TestSeeding test_seed = new TestSeeding();
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
            test_seed.TestSeedingHabitat();
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
            //Seed method is called in initialize.
            test_seed.Animal1.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal2.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal3.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal4.CurrentHabitat = test_seed.Habitat2;
            test_seed.Animal5.CurrentHabitat = test_seed.Habitat2;
            test_seed.Animal6.CurrentHabitat = test_seed.Habitat1;

            animals_list.Add(test_seed.Animal1);
            animals_list.Add(test_seed.Animal2);
            animals_list.Add(test_seed.Animal3);
            animals_list.Add(test_seed.Animal4);
            animals_list.Add(test_seed.Animal5);
            animals_list.Add(test_seed.Animal6);
        


            //Act
            List<DisplayAnimalInfo> actual_animals =  repo.GetAllAnimals();
            List<DisplayAnimalInfo> expected_animals = new List<DisplayAnimalInfo> {
                new DisplayAnimalInfo { AnimalId = 1,  Name = "Ralph", CommonName = "Red Panda", ScientificName = "Ailurus Fulgens", CurrentHabitat= "Forest", Age = 3},
                new DisplayAnimalInfo { AnimalId = 2,  Name = "Ash", CommonName = "Spider Monkey", ScientificName = "Ateles", CurrentHabitat= "Forest", Age = 5},
                new DisplayAnimalInfo { AnimalId = 3,  Name = "Tommy", CommonName = "Jaguar", ScientificName = "Panthera Onca", CurrentHabitat= "Forest", Age = 4},
                new DisplayAnimalInfo { AnimalId = 4,  Name = "Gina", CommonName = "Seal", ScientificName = "Phocidae", CurrentHabitat= "Arctic", Age = 2},
                new DisplayAnimalInfo { AnimalId = 5,  Name = "Hal", CommonName = "Polar Bear", ScientificName = "Ursus maritimus", CurrentHabitat= "Arctic", Age = 3},
                new DisplayAnimalInfo { AnimalId = 6,  Name = "Suzy", CommonName = "Lemur", ScientificName = "Lemuroidea", CurrentHabitat= "Forest", Age = 2}
            };
            //Assert
            Assert.AreEqual(actual_animals.Count, expected_animals.Count);

        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificAnimalToDisplay()
        {
            //Arrange
            //Seed method is called in initialize.
            test_seed.Animal1.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal2.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal3.CurrentHabitat = test_seed.Habitat1;
            test_seed.Animal4.CurrentHabitat = test_seed.Habitat2;
            test_seed.Animal5.CurrentHabitat = test_seed.Habitat2;
            test_seed.Animal6.CurrentHabitat = test_seed.Habitat1;

            animals_list.Add(test_seed.Animal1);
            animals_list.Add(test_seed.Animal2);
            animals_list.Add(test_seed.Animal3);
            animals_list.Add(test_seed.Animal4);
            animals_list.Add(test_seed.Animal5);
            animals_list.Add(test_seed.Animal6);

            //Act
            DisplayAnimalInfo actual_animal = repo.GetOneSpecificAnimal(1);
            DisplayAnimalInfo expected_animal = new DisplayAnimalInfo { AnimalId = 1, Name = "Ralph", CommonName = "Red Panda", ScientificName = "Ailurus Fulgens", CurrentHabitat = "Forest", Age = 3 };
            //Assert
            Assert.AreEqual(actual_animal.AnimalId, expected_animal.AnimalId);
            Assert.AreEqual(actual_animal.Name, expected_animal.Name);
            Assert.AreEqual(actual_animal.CommonName, expected_animal.CommonName);
            Assert.AreEqual(actual_animal.ScientificName, expected_animal.ScientificName);
            Assert.AreEqual(actual_animal.CurrentHabitat, expected_animal.CurrentHabitat);
            Assert.AreEqual(actual_animal.Age, expected_animal.Age);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnAListOfAllEmployees()
        {
            //Arrange
            test_seed.Employee1.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee2.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };
            test_seed.Employee3.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee4.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee5.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };
            test_seed.Employee6.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };

            employee_list.Add(test_seed.Employee1);
            employee_list.Add(test_seed.Employee2);
            employee_list.Add(test_seed.Employee3);
            employee_list.Add(test_seed.Employee4);
            employee_list.Add(test_seed.Employee5);
            employee_list.Add(test_seed.Employee6);
            //Act
            List<DisplayEmployeeInfo> actual_employees = repo.GetAllEmployees();
            List<DisplayEmployeeInfo> expected_employees = new List<DisplayEmployeeInfo> {
                new DisplayEmployeeInfo { EmployeeId = 1,  Name = "Craig Mifton", Age = 40, CurrentAssignedHabitats = new List<string> { "Forest" } },
                new DisplayEmployeeInfo { EmployeeId = 2,  Name = "Travis Holmes", Age = 30, CurrentAssignedHabitats = new List<string> { "Arctic" } },
                new DisplayEmployeeInfo { EmployeeId = 3,  Name = "Angie Stongly", Age = 26,  CurrentAssignedHabitats = new List<string> { "Forest" } },
                new DisplayEmployeeInfo { EmployeeId = 4,  Name = "Jim Bakster", Age = 29,  CurrentAssignedHabitats = new List<string> { "Forest" } },
                new DisplayEmployeeInfo { EmployeeId = 5,  Name = "Felicia Kennedy", Age = 33,  CurrentAssignedHabitats = new List<string> { "Arctic" } },
                new DisplayEmployeeInfo { EmployeeId = 6,  Name = "Andrew Wilson", Age = 49,  CurrentAssignedHabitats = new List<string> { "Arctic" } },
            };
            //Assert
            Assert.AreEqual(actual_employees.Count, expected_employees.Count);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificEmployeeToDisplay()
        {
            //Arrange
            test_seed.Employee1.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee2.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };
            test_seed.Employee3.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee4.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat1 };
            test_seed.Employee5.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };
            test_seed.Employee6.CurrentlyAssignedHabitats = new List<Habitat> { test_seed.Habitat2 };

            employee_list.Add(test_seed.Employee1);
            employee_list.Add(test_seed.Employee2);
            employee_list.Add(test_seed.Employee3);
            employee_list.Add(test_seed.Employee4);
            employee_list.Add(test_seed.Employee5);
            employee_list.Add(test_seed.Employee6);
            //Act
            DisplayEmployeeInfo actual_employee = repo.GetOneSpecificEmployee(3);
            DisplayEmployeeInfo expected_employee = new DisplayEmployeeInfo { EmployeeId = 3, Name = "Angie Stongly", Age = 26, CurrentAssignedHabitats = new List<string> { "Forest" } };
            
            //Assert
            Assert.AreEqual(actual_employee.EmployeeId, expected_employee.EmployeeId);
            Assert.AreEqual(actual_employee.Name, expected_employee.Name);
            Assert.AreEqual(actual_employee.Age, expected_employee.Age);
            Assert.AreEqual(actual_employee.CurrentAssignedHabitats[0], expected_employee.CurrentAssignedHabitats[0]);

        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnAListOfAllHabitats()
        {
            //Arrange
            test_seed.Habitat1.CurrentInhabitants = new List<Animal> { test_seed.Animal1, test_seed.Animal2, test_seed.Animal3, test_seed.Animal6 };
            test_seed.Habitat1.CurrentlyAssignedEmployees = new List<Employee> { test_seed.Employee1, test_seed.Employee3, test_seed.Employee4 };

            test_seed.Habitat2.CurrentInhabitants = new List<Animal> { test_seed.Animal4, test_seed.Animal5 };
            test_seed.Habitat2.CurrentlyAssignedEmployees = new List<Employee> { test_seed.Employee2, test_seed.Employee5, test_seed.Employee6 };

            habitat_list.Add(test_seed.Habitat1);
            habitat_list.Add(test_seed.Habitat2);

            //Act
            List<DisplayHabitatInfo> actual_habitats = repo.GetAllHabitats();
            List<DisplayHabitatInfo> expected_habitats = new List<DisplayHabitatInfo> {
                new DisplayHabitatInfo { HabitatId = 1, Name = "Forest", HabitatType = "Rain Forest", CurrentlyOpen = true,  NumberOfAnimalsInHabitat = 4, CurrentAnimals = new List<string> { "Ralph", "Ash", "Tommy",  "Suzy"}, CurrentAssignedEmployees = new List<string> { "Craig Mifton", "Angie Stongly", "Jim Bakster" } },
                new DisplayHabitatInfo { HabitatId = 2, Name = "Arctic", HabitatType = null, CurrentlyOpen = true,  NumberOfAnimalsInHabitat = 4, CurrentAnimals = new List<string> { "Gina", "Hal"}, CurrentAssignedEmployees = new List<string> { "Travis Holmes", "Felicia Kennedy", "Andrew Wilson" } },
            };

            //Assert
            Assert.AreEqual(actual_habitats.Count, expected_habitats.Count);
        }

        [TestMethod]
        public void ZoolandiaRepoWillReturnASpecificHabitatToDisplay()
        {
            //Arrange
            //Arrange
            test_seed.Habitat1.CurrentInhabitants = new List<Animal> { test_seed.Animal1, test_seed.Animal2, test_seed.Animal3, test_seed.Animal6 };
            test_seed.Habitat1.CurrentlyAssignedEmployees = new List<Employee> { test_seed.Employee1, test_seed.Employee3, test_seed.Employee4 };

            test_seed.Habitat2.CurrentInhabitants = new List<Animal> { test_seed.Animal4, test_seed.Animal5 };
            test_seed.Habitat2.CurrentlyAssignedEmployees = new List<Employee> { test_seed.Employee2, test_seed.Employee5, test_seed.Employee6 };

            habitat_list.Add(test_seed.Habitat1);
            habitat_list.Add(test_seed.Habitat2);
            //Act
            DisplayHabitatInfo actual_habitat = repo.GetOneSpecificHabitat(1);
            DisplayHabitatInfo expected_habitat = new DisplayHabitatInfo { HabitatId = 1, Name = "Forest", HabitatType = "Rain Forest", CurrentlyOpen = true, NumberOfAnimalsInHabitat = 4, CurrentAnimals = new List<string> { "Ralph", "Ash", "Tommy", "Suzy" }, CurrentAssignedEmployees = new List<string> { "Craig Mifton", "Angie Stongly", "Jim Bakster" } };
            
            //Assert 
            Assert.AreEqual(actual_habitat.HabitatId, expected_habitat.HabitatId);
            Assert.AreEqual(actual_habitat.Name, expected_habitat.Name);
            Assert.AreEqual(actual_habitat.HabitatType, expected_habitat.HabitatType);
            //Assert.AreEqual(actual_habitat.CurrentlyOpen, expected_habitat.CurrentlyOpen);
            //Assert.AreEqual(actual_habitat.NumberOfAnimalsInHabitat, expected_habitat.NumberOfAnimalsInHabitat);
            Assert.AreEqual(actual_habitat.CurrentAnimals.Count, expected_habitat.CurrentAnimals.Count);
            Assert.AreEqual(actual_habitat.CurrentAssignedEmployees.Count, expected_habitat.CurrentAssignedEmployees.Count);


        }
    }
}
