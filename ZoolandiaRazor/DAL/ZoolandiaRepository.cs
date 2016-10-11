using System.Collections.Generic;
using System.Linq;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepository
    {
        public ZoolandiaContext Context { get; set; }

        public ZoolandiaRepository()
        {
            Context = new ZoolandiaContext();
        }

        public ZoolandiaRepository(ZoolandiaContext _context)
        {
            Context = _context;
        }

        // Gets the Animals table, pulls the required fields, adds them to the Animal "object" and adds each "object" to a List<>
        public List<DisplayAnimalInfo> GetAllAnimals()
        {
            var animalTable = Context.Animals;

            List<DisplayAnimalInfo> ListOfAnimals = new List<DisplayAnimalInfo>();

            foreach (var animalRow in animalTable)
            {
                DisplayAnimalInfo currentAnimalFromDatabase = new DisplayAnimalInfo();
                currentAnimalFromDatabase.AnimalId = animalRow.AnimalId;
                currentAnimalFromDatabase.Name = animalRow.Name;
                currentAnimalFromDatabase.CurrentHabitat = animalRow.CurrentHabitat.Name;
                ListOfAnimals.Add(currentAnimalFromDatabase);
            }
            return ListOfAnimals;
        }

        // Gets the Employees table, pulls the required fields, adds them to the Employees "object" and adds each "object" to a List<>
        public List<DisplayEmployeeInfo> GetAllEmployees()
        {
            var employeeTable = Context.Employees;

            List<DisplayEmployeeInfo> ListOfEmployees = new List<DisplayEmployeeInfo>();

            foreach (var employeeRow in employeeTable)
            {
                DisplayEmployeeInfo currentEmployeeFromDatabase = new DisplayEmployeeInfo();
                currentEmployeeFromDatabase.EmployeeId = employeeRow.EmployeeId;
                currentEmployeeFromDatabase.Name = employeeRow.Name;

                ListOfEmployees.Add(currentEmployeeFromDatabase);
            }
            return ListOfEmployees;
        }

        // Gets the Habitats table, pulls the required fields, adds them to the Habitats "object" and adds each "object" to a List<>
        public List<DisplayHabitatInfo> GetAllHabitats()
        {
            var habitatTable = Context.Habitats;

            List<DisplayHabitatInfo> ListOfHabitats = new List<DisplayHabitatInfo>();

            foreach (var habitatRow in habitatTable)
            {
                DisplayHabitatInfo currentHabitatFromDatabase = new DisplayHabitatInfo();
                currentHabitatFromDatabase.HabitatId = habitatRow.HabitatId;
                currentHabitatFromDatabase.Name = habitatRow.Name;

                ListOfHabitats.Add(currentHabitatFromDatabase);
            }
            return ListOfHabitats;
        }

        public DisplayAnimalInfo GetOneSpecificAnimal(int requestedAnimalByItsId)
        {
            var singleAnimalReturned = Context.Animals.Where(a => a.AnimalId == requestedAnimalByItsId).FirstOrDefault(); // Returns 'null' if no entries are found instead of throwing an exception.

            if (singleAnimalReturned == null)
            {
                DisplayAnimalInfo singleAnimalToBeDisplayed = new DisplayAnimalInfo
                {
                    AnimalId = requestedAnimalByItsId,
                    Name = "Animal not found"
                };
                return singleAnimalToBeDisplayed;
            }
            else
            {
                DisplayAnimalInfo singleAnimalToBeDisplayed = new DisplayAnimalInfo
                {
                    AnimalId = singleAnimalReturned.AnimalId,
                    Name = singleAnimalReturned.Name,
                    CommonName = singleAnimalReturned.CommonName,
                    ScientificName = singleAnimalReturned.ScientificName,
                    CurrentHabitat = singleAnimalReturned.CurrentHabitat.Name,
                    Age = singleAnimalReturned.Age
                };
                return singleAnimalToBeDisplayed;
            }
        }

        public DisplayHabitatInfo GetOneSpecificHabitat(int requestedHabitatByItsId)
        {
            var singleHabitatReturned = Context.Habitats.Where(a => a.HabitatId == requestedHabitatByItsId).FirstOrDefault(); // Returns 'null' if no entries are found instead of throwing an exception.

            if (singleHabitatReturned == null)
            {
                DisplayHabitatInfo singleHabitatToBeDisplayed = new DisplayHabitatInfo
                {
                    HabitatId = requestedHabitatByItsId,
                    Name = "Habitat not found"
                };
                return singleHabitatToBeDisplayed;
            }
            else
            {
                List<string> AnimalNames = new List<string>();
                List<string> EmployeeNames = new List<string>();

                // Looks through the Animals for the selected Habitat By Id, Selects the name of those animals and makes it a list
                foreach (var inhabitant in singleHabitatReturned.CurrentInhabitants)
                {
                    AnimalNames.Add(inhabitant.Name);
                };
                // The intent is to take the employee table, find the ones where CurrentlyAssignedHabitats contains the requestedHabitatId and makes a list of the employee names
                foreach (var employee in singleHabitatReturned.CurrentlyAssignedEmployees)
                {
                    EmployeeNames.Add(employee.Name);
                };

                DisplayHabitatInfo singleHabitatToBeDisplayed = new DisplayHabitatInfo
                {
                    HabitatId = singleHabitatReturned.HabitatId,
                    Name = singleHabitatReturned.Name,
                    HabitatType = singleHabitatReturned.HabitatType,
                    NumberOfAnimalsInHabitat = AnimalNames.Count,
                    CurrentAnimals = AnimalNames,
                    CurrentAssignedEmployees = EmployeeNames
            };
                return singleHabitatToBeDisplayed;
            }
        }

        public DisplayEmployeeInfo GetOneSpecificEmployee(int requestedEmployeeById)
        {
            var singleEmployeeReturned = Context.Employees.Where(a => a.EmployeeId == requestedEmployeeById).FirstOrDefault(); // Returns 'null' if no entries are found instead of throwing an exception.

            if (singleEmployeeReturned == null)
            {
                DisplayEmployeeInfo singleEmployeeToBeDisplayed = new DisplayEmployeeInfo
                {
                    EmployeeId = requestedEmployeeById,
                    Name = "Employee not found"
                };
                return singleEmployeeToBeDisplayed;
            }
            else
            {
                List<string> buildHabitatList = new List<string>();

                foreach (var item in singleEmployeeReturned.CurrentlyAssignedHabitats)
                {
                    buildHabitatList.Add(Context.Habitats.Where(h => h.HabitatId == item.HabitatId).First().Name);
                }

                DisplayEmployeeInfo singleEmployeeToBeDisplayed = new DisplayEmployeeInfo
                {
                    EmployeeId = singleEmployeeReturned.EmployeeId,
                    Name = singleEmployeeReturned.Name,
                    Age = singleEmployeeReturned.Age,
                    CurrentAssignedHabitats = buildHabitatList
                };
                return singleEmployeeToBeDisplayed;
            }
        }
    }
}
