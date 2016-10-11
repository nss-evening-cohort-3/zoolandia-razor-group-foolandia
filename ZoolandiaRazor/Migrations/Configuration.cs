namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using ZoolandiaRazor.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.ZoolandiaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.ZoolandiaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Animals.AddOrUpdate(
              
            /// ANIMALS ///
                new Animal
                {
                    AnimalId = 1,
                    Name = "Ralph",
                    CommonName = "Red Panda",
                    ScientificName = "Ailurus Fulgens",
                    Age = 3
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Ash",
                    CommonName = "Spider Monkey",
                    ScientificName = "Ateles",
                    Age = 5
                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Tommy",
                    CommonName = "Jaguar",
                    ScientificName = "Panthera Onca",
                    Age = 4
                },
                new Animal
                {
                    AnimalId = 4,
                    Name = "Gina",
                    CommonName = "Seal",
                    ScientificName = "Phocidae",
                    Age = 2
                },
                new Animal
                {
                    AnimalId = 5,
                    Name = "Hal",
                    CommonName = "Polar Bear",
                    ScientificName = "Ursus maritimus",
                    Age = 3
                },
                new Animal
                {
                    AnimalId = 6,
                    Name = "Suzy",
                    CommonName = "Lemur",
                    ScientificName = "Lemuroidea",
                    Age = 2
                }
              );

            context.Employees.AddOrUpdate(

                /// EMPLOYEES
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Craig Mifton",
                    Age = 40
                },
                new Employee
                {
                    EmployeeId = 2,
                    Name = "Travis Holmes",
                    Age = 30
                },
                new Employee
                {
                    EmployeeId = 3,
                    Name = "Angie Stongly",
                    Age = 26
                },
                new Employee
                {
                    EmployeeId = 4,
                    Name = "Jim Bakster",
                    Age = 29,
                },
                new Employee
                {
                    EmployeeId = 5,
                    Name = "Felicia Kennedy",
                    Age = 33
                },
                new Employee
                {
                    EmployeeId = 6,
                    Name = "Andrew Wilson",
                    Age = 49
                }
            );

            context.SaveChanges();

            context.Habitats.AddOrUpdate(

                /// HABITATS
                new Habitat
                {
                    HabitatId = 1,
                    Name = "Forest",
                    HabitatType = "Rain Forest",
                    CurrentlyOpen = true,
                    CurrentInhabitants = new List<Animal> {
                        context.Animals.FirstOrDefault(a => a.AnimalId == 1),
                        context.Animals.FirstOrDefault(a => a.AnimalId == 2),
                        context.Animals.FirstOrDefault(a => a.AnimalId == 3),
                        context.Animals.FirstOrDefault(a => a.AnimalId == 6)
                    },
                    CurrentlyAssignedEmployees = new List<Employee> {
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 1),
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 3),
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 4)
                    }
                },

                new Habitat
                {
                    HabitatId = 2,
                    Name = "Arctic",
                    CurrentlyOpen = true,
                    CurrentInhabitants = new List<Animal> {
                        context.Animals.FirstOrDefault(a => a.AnimalId == 4),
                        context.Animals.FirstOrDefault(a => a.AnimalId == 5)
                    },
                    CurrentlyAssignedEmployees = new List<Employee> {
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 2),
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 5),
                        context.Employees.FirstOrDefault(e => e.EmployeeId == 6)
                    }
                }
            );

            context.SaveChanges();

        }
    }
}
