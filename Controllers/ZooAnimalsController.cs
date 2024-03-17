using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CA3MVC.Data;
using CA3MVC.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZooAnimal.ToListAsync());
        }

        // GET: ZooAnimals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooAnimal = await _context.ZooAnimal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooAnimal == null)
            {
                return NotFound();
            }

            return View(zooAnimal);
        }

        // GET: ZooAnimals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZooAnimals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZooId,Species,Name,Description,ImageUrl,HabitatInformation,Diet,SpecialCareRequirements,ConservationStatus")] ZooAnimal zooAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zooAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zooAnimal);
        }

        // GET: ZooAnimals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooAnimal = await _context.ZooAnimal.FindAsync(id);
            if (zooAnimal == null)
            {
                return NotFound();
            }
            return View(zooAnimal);
        }

        // POST: ZooAnimals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZooId,Species,Name,Description,ImageUrl,HabitatInformation,Diet,SpecialCareRequirements,ConservationStatus")] ZooAnimal zooAnimal)
        {
            if (id != zooAnimal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zooAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZooAnimalExists(zooAnimal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zooAnimal);
        }

        // GET: ZooAnimals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooAnimal = await _context.ZooAnimal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooAnimal == null)
            {
                return NotFound();
            }

            return View(zooAnimal);
        }

        // POST: ZooAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zooAnimal = await _context.ZooAnimal.FindAsync(id);
            if (zooAnimal != null)
            {
                _context.ZooAnimal.Remove(zooAnimal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZooAnimalExists(int id)
        {
            return _context.ZooAnimal.Any(e => e.Id == id);
        }
    }
}
