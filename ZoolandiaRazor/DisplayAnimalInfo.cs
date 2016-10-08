namespace ZoolandiaRazor
{
    public class DisplayAnimalInfo
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string CurrentHabitat { get; set; } // Just the habitat name will be inserted
        public int Age { get; set; }
    }
}