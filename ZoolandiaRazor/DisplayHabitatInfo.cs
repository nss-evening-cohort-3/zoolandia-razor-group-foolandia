using System.Collections.Generic;

namespace ZoolandiaRazor
{
    public class DisplayHabitatInfo
    {
        public int HabitatId { get; set; }
        public string Name { get; set; }
        public string HabitatType { get; set; }
        public bool CurrentlyOpen { get; set; }
        public int NumberOfAnimalsInHabitat { get; set; }
        public List<string> CurrentAnimals { get; set; }
        public List<string> CurrentAssignedEmployees { get; set; }
    }
}