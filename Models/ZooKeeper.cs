namespace CA3MVC.Models
{
    public class ZooKeeper
    {   
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public int ZooId { get; set; } // Foreign key to Zoo
        public bool IsAdmin { get; set; }
    }
}
