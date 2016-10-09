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

            DisplayAnimalInfo currentAnimalFromDatabase = new DisplayAnimalInfo();
            List<DisplayAnimalInfo> ListOfAnimals = new List<DisplayAnimalInfo>();

            foreach (var animalRow in animalTable)
            {
                currentAnimalFromDatabase.AnimalId = animalRow.AnimalId;
                currentAnimalFromDatabase.Name = animalRow.Name;
                currentAnimalFromDatabase.CurrentHabitat = animalRow.CurrentHabitat.ToString();

                ListOfAnimals.Add(currentAnimalFromDatabase);
            }
            return ListOfAnimals; 
        }

        // Gets the Employees table, pulls the required fields, adds them to the Employees "object" and adds each "object" to a List<>
        public List<DisplayEmployeeInfo> GetAllEmployees()
        {
            var employeeTable = Context.Employees;

            DisplayEmployeeInfo currentEmployeeFromDatabase = new DisplayEmployeeInfo();
            List<DisplayEmployeeInfo> ListOfEmployees = new List<DisplayEmployeeInfo>();

            foreach (var employeeRow in employeeTable)
            {
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

            DisplayHabitatInfo currentHabitatFromDatabase = new DisplayHabitatInfo();
            List<DisplayHabitatInfo> ListOfHabitats = new List<DisplayHabitatInfo>();

            foreach (var habitatRow in habitatTable)
            {
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
                var test = Context.Employees.Where(emp => Context.Habitats.Where() )

                DisplayHabitatInfo singleHabitatToBeDisplayed = new DisplayHabitatInfo
                {
                    HabitatId = singleHabitatReturned.HabitatId,
                    Name = singleHabitatReturned.Name,
                    HabitatType = singleHabitatReturned.HabitatType,
                    // Looks through the Animals for the selected Habitat By Id, Selects the name of those animals and makes it a list
                    CurrentAnimals = Context.Animals.Where(a => a.CurrentHabitat.HabitatId == requestedHabitatByItsId).Select(a => a.Name).ToList(),
                    //CurrentAssignedEmployees = // Needs fixing 
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