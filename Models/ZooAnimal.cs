namespace CA3MVC.Models
{
    public class ZooAnimal
    {
        public int Id { get; set; }
        public int ZooId { get; set; } // Foreign key to Zoo
        public string Species { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string HabitatInformation { get; set; }
        public string Diet { get; set; }
        public string SpecialCareRequirements { get; set; }
        public string ConservationStatus { get; set; }
    }
}
