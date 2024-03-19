using CA3MVC.Data;
using CA3MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using ZooWebsite.Models;

namespace CA3MVC.Controllers
{
    public class ZooController : Controller
    {
        private readonly CA3MVCContext _context;
        public ZooController(CA3MVCContext context)
        {
            _context = context;
        }

        // GET: Zoos
        public async Task<IActionResult> Index(string zooAnimalZoo, string searchString)
        {
            if (_context.Zoo == null)
            {
                return Problem("Entity set 'CA3MVCContext.Zoo' is null.");
            }

            // Use LINQ to get list of zoos.
            IQueryable<string> zooQuery = from z in _context.Zoo
            orderby z.Name
                                          select z.Name;
            var zooAnimals = from z in _context.ZooAnimal
                             select z;

            if (!string.IsNullOrEmpty(searchString))
            {
                zooAnimals = zooAnimals.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(zooAnimalZoo))
            {
                zooAnimals = zooAnimals.Where(x => x.Name == zooAnimalZoo);
            }

            var zooAnimalViewModel = new ZooAnimalViewModel
            {
                Zoos = new SelectList(await zooQuery.Distinct().ToListAsync()),
                ZooAnimals = await zooAnimals.ToListAsync()
            };

            return View(zooAnimalViewModel);
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
