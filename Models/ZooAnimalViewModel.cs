using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CA3MVC.Models
{
    public class ZooAnimalViewModel
    {
        public List<ZooAnimal>? ZooAnimals { get; set; }
        public SelectList? Zoos { get; set; }
        public string? ZooAnimalZoo { get; set; }
        public string? SearchString { get; set; }
    }
}
