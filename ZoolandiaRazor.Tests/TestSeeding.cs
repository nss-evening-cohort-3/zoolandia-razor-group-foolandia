using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Tests
{
    public class TestSeeding
    {
        //ANIMALS
        public Animal Animal1 {get; set;}
        public Animal Animal2 { get; set; }
        public Animal Animal3 { get; set; }
        public Animal Animal4 { get; set; }
        public Animal Animal5 { get; set; }
        public Animal Animal6 { get; set; }

        //EMPLOYEES
        public Employee Employee1 { get; set; }
        public Employee Employee2 { get; set; }
        public Employee Employee3 { get; set; }
        public Employee Employee4 { get; set; }
        public Employee Employee5 { get; set; }
        public Employee Employee6 { get; set; }

        /// HABITATS
        public Habitat Habitat1 { get; set; }
        public Habitat Habitat2 { get; set; }



        public void TestSeedingAnimal()
        {
            /// ANIMALS ///
            Animal1 = new Animal
            {
                AnimalId = 1,
                Name = "Ralph",
                CommonName = "Red Panda",
                ScientificName = "Ailurus Fulgens",
                Age = 3
            };

            Animal2 = new Animal
            {
                AnimalId = 2,
                Name = "Ash",
                CommonName = "Spider Monkey",
                ScientificName = "Ateles",
                Age = 5
            };

            Animal3 = new Animal
            {
                AnimalId = 3,
                Name = "Tommy",
                CommonName = "Jaguar",
                ScientificName = "Panthera Onca",
                Age = 4
            };

            Animal4 = new Animal
            {
                AnimalId = 4,
                Name = "Gina",
                CommonName = "Seal",
                ScientificName = "Phocidae",
                Age = 2
            };

            Animal5 = new Animal
            {
                AnimalId = 5,
                Name = "Hal",
                CommonName = "Polar Bear",
                ScientificName = "Ursus maritimus",
                Age = 3
            };

            Animal6 = new Animal
            {
                AnimalId = 4,
                Name = "Suzy",
                CommonName = "Lemur",
                ScientificName = "Lemuroidea",
                Age = 2
            };
        }

        public void TestSeedingEmployee()
        {
            /// EMPLOYEES
            Employee1 = new Employee
            {
                EmployeeId = 1,
                Name = "Craig Mifton",
                Age = 40
            };

            Employee2 = new Employee
            {
                EmployeeId = 2,
                Name = "Travis Holmes",
                Age = 30
            };

            Employee3 = new Employee
            {
                EmployeeId = 3,
                Name = "Angie Stongly",
                Age = 26
            };

            Employee4 = new Employee
            {
                EmployeeId = 4,
                Name = "Jim Bakster",
                Age = 29
            };

            Employee5 = new Employee
            {
                EmployeeId = 5,
                Name = "Felicia Kennedy",
                Age = 33
            };
            Employee6 = new Employee
            {
                EmployeeId = 6,
                Name = "Andrew Wilson",
                Age = 49
            };
        }

        public List<Habitat> TestSeedingHabitat()
        {
            TestSeedingAnimal();
            TestSeedingEmployee();

            /// HABITATS
            Habitat1 = new Habitat
            {
                HabitatId = 1,
                Name = "Forest",
                HabitatType = "Rain Forest",
                CurrentlyOpen = true,
                CurrentInhabitants = new List<Animal> { Animal1, Animal2, Animal3, Animal6 },
                CurrentlyAssignedEmployees = new List<Employee> { Employee1, Employee3, Employee4 }
            };
            Habitat2 = new Habitat
            {
                HabitatId = 2,
                Name = "Arctic",
                CurrentlyOpen = true,
                CurrentInhabitants = new List<Animal> { Animal4, Animal5 },
                CurrentlyAssignedEmployees = new List<Employee> { Employee2, Employee5, Employee6 }
            };

            return new List<Habitat> { Habitat1, Habitat2 };

        }
    }
}
}
