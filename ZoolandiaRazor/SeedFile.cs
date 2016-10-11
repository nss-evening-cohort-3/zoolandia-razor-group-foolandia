using ZoolandiaRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoolandiaRazor.Models
{
    public List<Animal> TestSeedingAnimal()
    {
        /// ANIMALS ///
        Animal Animal1 = new Animal
        {
            AnimalId = 1,
            Name = "Ralph",
            CommonName = "Red Panda",
            ScientificName = "Ailurus Fulgens",
            Age = 3
        };
        Animal Animal2 = new Animal
        {
            AnimalId = 2,
            Name = "Ash",
            CommonName = "Spider Monkey",
            ScientificName = "Ateles",
            Age = 5
        };
        Animal Animal3 = new Animal
        {
            AnimalId = 3,
            Name = "Tommy",
            CommonName = "Jaguar",
            ScientificName = "Panthera Onca",
            Age = 4
        };
        Animal Animal4 = new Animal
        {
            AnimalId = 4,
            Name = "Gina",
            CommonName = "Seal",
            ScientificName = "Phocidae",
            Age = 2
        };
        Animal Animal5 = new Animal
        {
            AnimalId = 5,
            Name = "Hal",
            CommonName = "Polar Bear",
            ScientificName = "Ursus maritimus",
            Age = 3
        };
        Animal Animal6 = new Animal
        {
            AnimalId = 4,
            Name = "Suzy",
            CommonName = "Lemur",
            ScientificName = "Lemuroidea",
            Age = 2
        };
        return new List<Animal> { Animal1, Animal2, Animal3, Animal4, Animal5, Animal6 };
    }

    public List<Animal> TestSeedingEmployee()
    {
        /// EMPLOYEES
        Employee Employee1 = new Employee
        {
            EmployeeId = 1,
            Name = "Craig Mifton",
            Age = 40
        };
        Employee Employee2 = new Employee
        {
            EmployeeId = 2,
            Name = "Travis Holmes",
            Age = 30
        };
        Employee Employee3 = new Employee
        {
            EmployeeId = 3,
            Name = "Angie Stone",
            Age = 26
        };
        Employee Employee4 = new Employee
        {
            EmployeeId = 4,
            Name = "Jim Bakster",
            Age = 29
        };
        Employee Employee5 = new Employee
        {
            EmployeeId = 5,
            Name = "Felicia Kennedy",
            Age = 33
        };
        Employee Employee6 = new Employee
        {
            EmployeeId = 6,
            Name = "Andrew Wilson",
            Age = 49
        };
        return new List<Employee>{ Employee1, Employee2, Employee3, Employee4, Employee5, Employee6 };
    }

    public List<Habitat> TestSeedingHabitat()
    {
        /// HABITATS
        Habitat Habitat1 = new Habitat
        {
            HabitatId = 1,
            Name = "Forest",
            HabitatType = "Rain Forest",
            CurrentlyOpen = true,
            CurrentInhabitants = new List<Animal> { Animal1, Animal2, Animal3, Animal6 },
            CurrentlyAssignedEmployees = new List<Employee> { Employee1, Employee3, Employee4 }
        };
        Habitat Habitat2 = new Habitat
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