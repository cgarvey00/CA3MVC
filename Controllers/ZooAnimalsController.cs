using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CA3MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA3MVC.Data;
using ZooWebsite.Models;

namespace CA3MVC.Controllers
{
    public class ZooAnimalsController : Controller
    {
        private readonly CA3MVCContext _context;

        public ZooAnimalsController(CA3MVCContext context)
        {
            _context = context;
        }

        // GET: ZooAnimals
        public async Task<IActionResult> Index(string zooAnimalZoo, string searchString)
        {
            if (_context.Zoo == null)
            {
                return Problem("Entity set 'CA3MVCContext.Zoo' is null.");
            }

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
    }
}
