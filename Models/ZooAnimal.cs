using System.ComponentModel.DataAnnotations;

namespace CA3MVC.Models
{
    public class ZooAnimal
    {
        public int Id { get; set; }
        public int ZooId { get; set; } // Foreign key to Zoo
        [Required(ErrorMessage="The Species is required")]
        public string Species { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is Required"),MaxLength(225)]
        public string Description { get; set; }
      
        [Required(ErrorMessage = "A URL is required"), MaxLength(225)]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "A Info is required"), MaxLength(225)]
        public string HabitatInformation { get; set; }
        
        [Required(ErrorMessage = "The Diet is required"), MaxLength(100)]
        public string Diet { get; set; }
       
        [Required(ErrorMessage = "The SpecialCareRequirements is required"), MaxLength(100)]
        public string SpecialCareRequirements { get; set; }
        
        [Required(ErrorMessage = "The SpecialCareRequirements is required"), MaxLength(222)]
        public string ConservationStatus { get; set; }
    }
}
