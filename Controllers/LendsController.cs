using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_WypozyczalniaFilmow.Data;
using Projekt_WypozyczalniaFilmow.Models;

namespace Projekt_WypozyczalniaFilmow.Controllers
{
    public class LendsController : Controller
    {
        private readonly Projekt_WypozyczalniaFilmowContext _context;

        public LendsController(Projekt_WypozyczalniaFilmowContext context)
        {
            _context = context;
        }

        // GET: Lends
        public async Task<IActionResult> Index()
        {
              return View(await _context.Lend.ToListAsync());
        }

        // GET: Lends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lend == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // GET: Lends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Client,MovieName,RentDate,HowMuchWeeks,BeingLate")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lend);
        }

        // GET: Lends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lend == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend.FindAsync(id);
            if (lend == null)
            {
                return NotFound();
            }
            return View(lend);
        }

        // POST: Lends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Client,MovieName,RentDate,HowMuchWeeks,BeingLate")] Lend lend)
        {
            if (id != lend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendExists(lend.Id))
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
            return View(lend);
        }

        // GET: Lends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lend == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // POST: Lends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lend == null)
            {
                return Problem("Entity set 'Projekt_WypozyczalniaFilmowContext.Lend'  is null.");
            }
            var lend = await _context.Lend.FindAsync(id);
            if (lend != null)
            {
                _context.Lend.Remove(lend);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendExists(int id)
        {
          return _context.Lend.Any(e => e.Id == id);
        }
    }
}
