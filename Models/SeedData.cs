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
                // Look for any zoos.
                if (context.Zoo.Any())
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




            }
        }
    }
}
