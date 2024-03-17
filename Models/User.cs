using System.ComponentModel.DataAnnotations;

namespace CA3MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Contact Information")]
        public string ContactInformation { get; set; }
    }
}
