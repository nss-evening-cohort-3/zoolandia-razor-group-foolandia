using System.Collections.Generic;

namespace ZoolandiaRazor
{
    public class DisplayEmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> CurrentAssignedHabitats { get; set; } // List of habitat names

    }
}