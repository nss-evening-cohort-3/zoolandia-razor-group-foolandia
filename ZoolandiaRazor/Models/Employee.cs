using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ZoolandiaRazor.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual List<Habitat> CurrentlyAssignedHabitats { get; set; }
    }
}
