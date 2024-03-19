using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZooWebsite.Models;
using System;
using System.Linq;
using CA3MVC.Models;
using CA3MVC.Data;

namespace ZooWebsite.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CA3MVCContext(
                serviceProvider.GetRequiredService<DbContextOptions<CA3MVCContext>>()))
            {
                // Looks for any zoos.
                if (context.Zoo.Any())
                {
                    return;   // DB has been seeded
                }
                if (context.ZooAnimal.Any())
                {
                    return;   // DB has been seeded
                }

                context.Zoo.AddRange(
                    new Zoo
                    {
                        Name = "Central Park Zoo",
                        Location = "New York, USA",
                        ContactInformation = "123-456-7890, info@centralparkzoo.com",
                        OperatingHours = "9:00 AM - 5:00 PM",
                        TicketPrice = 15.99M,
                        Description = "The Central Park Zoo is a 6.5-acre zoo located in Central Park in New York City."
                    },
                    new Zoo
                    {
                        Name = "London Zoo",
                        Location = "London, UK",
                        ContactInformation = "https://www.zsl.org/about-zsl/contact-zsl",
                        OperatingHours = "10:00 AM - 5:00 PM",
                        TicketPrice = 30.00M,
                        Description = "The London Zoo contains the worlds oldest scientific zoo."
                    },
                    new Zoo
                    {
                        Name = "San Diego Zoo",
                        Location = "San Diego, USA",
                        ContactInformation = "987-654-3210, info@sandiegozoo.com",
                        OperatingHours = "8:00 AM - 6:00 PM",
                        TicketPrice = 25.99M,
                        Description = "The San Diego Zoo is a zoo in Balboa Park, San Diego, California, housing over 12,000 animals."
                    }, new Zoo
                    {
                        Name = "Singapore Zoo",
                        Location = "Singapore",
                        ContactInformation = "https://www.mandai.com/en/singapore-zoo.html",
                        OperatingHours = "9:00 AM - 5:00 PM",
                        TicketPrice = 39.00M,
                        Description = "The Singapore Zoo is one of the best rainforest zoos in the world."
                    }
                );


                context.ZooAnimal.AddRange(
                   new ZooAnimal
                   {
                       ZooId=1,
                       Species = "Bird",
                       Name = "Eagle",
                       Description = "American Eagle",
                       ImageUrl = "https://cdn.britannica.com/92/152292-050-EAF28A45/Bald-eagle.jpg",
                       HabitatInformation = "Nesting",
                       Diet="Worms, Fish",
                       SpecialCareRequirements="Nesting Freedom from Disturbance",
                       ConservationStatus="Non-Endangered"

                      
                   }, new ZooAnimal
                   {
                       ZooId = 1,
                       Species = "Bear",
                       Name = "Grizzly Bear",
                       Description = "Brown Grizzly Bear",
                       ImageUrl = "https://snowbrains.com/wp-content/uploads/2014/08/img_grizzlybear_mh_large.jpg",
                       HabitatInformation = "Caves, Forests and Tundra's",
                       Diet = "Fish, Deers",
                       SpecialCareRequirements = "Space, Solitude",
                       ConservationStatus = "Non-Endangered"

                   },new ZooAnimal
                   {
                       ZooId = 2,
                       Species = "Giraffe",
                       Name = "Reticulated Giraffe",
                       Description = "Distinctive coat pattern and long neck",
                       ImageUrl = "https://animals.sandiegozoo.org/sites/default/files/2016-11/animals_hero_giraffe_1_0.jpg",
                       HabitatInformation = "Grasslands",
                       Diet = "Leaves, Vegetation",
                       SpecialCareRequirements = "Tail feeding stations ",
                       ConservationStatus = "Vulnerable"

                   }, new ZooAnimal
                   {
                       ZooId = 1,
                       Species = "Elephant",
                       Name = "African Elephant",
                       Description = "Largest Land Animal",
                       ImageUrl = "https://www.treehugger.com/thmb/dql5wlVKsSU_H3O2A5dTTCECa7E=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/front-view-of-a-bull-elephant-in-the-grasslands-of-amboseli-national-park--1219745751-08f3add138514ad091e82e29a11546cc.jpg",
                       HabitatInformation = "Forests",
                       Diet = "Vegetation",
                       SpecialCareRequirements = "Water for Bathing",
                       ConservationStatus = "Vulnerable"

                   }, new ZooAnimal
                   {
                       ZooId = 1,
                       Species = "Penguin",
                       Name = "Emperor Penguin",
                       Description = "Furry ",
                       ImageUrl = "https://ca-times.brightspotcdn.com/dims4/default/344945d/2147483647/strip/true/crop/4240x2832+0+0/resize/768x513!/format/webp/quality/75/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2F16%2F53%2F08338b1941659e3a5d4d1875252a%2F23-swc-emperorpenguin-12.jpg",
                       HabitatInformation = "Antarctic Ice",
                       Diet = "Fish, Squid",
                       SpecialCareRequirements = "Cool Climate Enclosure",
                       ConservationStatus = "Near Threatened"

                   } 

               );
                context.SaveChanges();

            }
        }
    }
}
