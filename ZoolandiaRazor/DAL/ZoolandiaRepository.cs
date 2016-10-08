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
    }
}