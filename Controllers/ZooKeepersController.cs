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
    public class ZooKeepersController : Controller
    {
        private readonly CA3MVCContext _context;

        public ZooKeepersController(CA3MVCContext context)
        {
            _context = context;
        }

        // GET: ZooKeepers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZooKeeper.ToListAsync());
        }

        // GET: ZooKeepers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooKeeper = await _context.ZooKeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooKeeper == null)
            {
                return NotFound();
            }

            return View(zooKeeper);
        }

        // GET: ZooKeepers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZooKeepers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Name,ContactInformation,ZooId,IsAdmin")] ZooKeeper zooKeeper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zooKeeper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zooKeeper);
        }

        // GET: ZooKeepers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooKeeper = await _context.ZooKeeper.FindAsync(id);
            if (zooKeeper == null)
            {
                return NotFound();
            }
            return View(zooKeeper);
        }

        // POST: ZooKeepers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Name,ContactInformation,ZooId,IsAdmin")] ZooKeeper zooKeeper)
        {
            if (id != zooKeeper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zooKeeper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZooKeeperExists(zooKeeper.Id))
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
            return View(zooKeeper);
        }

        // GET: ZooKeepers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooKeeper = await _context.ZooKeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooKeeper == null)
            {
                return NotFound();
            }

            return View(zooKeeper);
        }

        // POST: ZooKeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zooKeeper = await _context.ZooKeeper.FindAsync(id);
            if (zooKeeper != null)
            {
                _context.ZooKeeper.Remove(zooKeeper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZooKeeperExists(int id)
        {
            return _context.ZooKeeper.Any(e => e.Id == id);
        }
    }
}
