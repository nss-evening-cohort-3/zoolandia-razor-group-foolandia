using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public int Age { get; set; }
        public virtual Habitat CurrentHabitat { get; set; }
    }
}
