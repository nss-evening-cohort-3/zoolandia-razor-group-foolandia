using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
