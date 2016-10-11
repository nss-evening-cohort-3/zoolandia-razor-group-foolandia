using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        public string Name { get; set; }
        public string HabitatType { get; set; }
        public bool CurrentlyOpen { get; set; }
        public virtual List<Employee> CurrentlyAssignedEmployees { get; set; }
        public virtual List<Animal> CurrentInhabitants { get; set; }
    }
}
