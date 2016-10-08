using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        public string Name { get; set; }
        public virtual string HabitatType { get; set; }
        public bool CurrentlyOpen { get; set; }
    }
}
