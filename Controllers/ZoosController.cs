﻿using System;
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
    public class ZoosController : Controller
    {
        private readonly CA3MVCContext _context;

        public ZoosController(CA3MVCContext context)
        {
            _context = context;
        }

        // GET: Zoos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zoo.ToListAsync());
        }

        // GET: Zoos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoo = await _context.Zoo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoo == null)
            {
                return NotFound();
            }



            return View(zoo);
        }

        // GET: Zoos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zoos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,ContactInformation,OperatingHours,TicketPrice,Description")] Zoo zoo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zoo);
        }

        // GET: Zoos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoo = await _context.Zoo.FindAsync(id);
            if (zoo == null)
            {
                return NotFound();
            }
            return View(zoo);
        }

        // POST: Zoos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,ContactInformation,OperatingHours,TicketPrice,Description")] Zoo zoo)
        {
            if (id != zoo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZooExists(zoo.Id))
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
            return View(zoo);
        }

        // GET: Zoos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoo = await _context.Zoo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoo == null)
            {
                return NotFound();
            }

            return View(zoo);
        }

        // POST: Zoos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoo = await _context.Zoo.FindAsync(id);
            if (zoo != null)
            {
                _context.Zoo.Remove(zoo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZooExists(int id)
        {
            return _context.Zoo.Any(e => e.Id == id);
        }
    }
}
