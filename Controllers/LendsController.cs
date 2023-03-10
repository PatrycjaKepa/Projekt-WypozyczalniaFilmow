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
            var lends = from m in _context.Lend
                        select m;

            lends.Include(m => m.User);
            lends.Include(m => m.Movie);

            if (HttpContext.Session.GetInt32("role") == (int)PermissionRole.User ||
                HttpContext.Session.GetInt32("role") == (int)PermissionRole.Admin
                )
            {
                if (HttpContext.Session.GetInt32("role") == (int)PermissionRole.User)
                {
                    lends = lends.Where(s => s.UserId == HttpContext.Session.GetInt32("userId"));
                }
                return View(await lends.ToListAsync());
            }
            if(TempData["error"] != null)
            {
                ViewBag.error = TempData["error"].ToString();
            }
            if (TempData["success"] != null)
            {
                ViewBag.succes = TempData["success"].ToString();
            }
            return RedirectToAction("Login", "Users");
        }
        [HttpGet]
        public IActionResult Rent(int id)
        {
            var lend = new Lend();
            var movie = _context.Movie.Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return RedirectToAction("Index", "Home");//przekierowanie do bledu
            }
            lend.Movie = movie;

            if(TempData["error"] != null)
            {
                ViewBag.error = TempData["error"].ToString();
            }

            return View(lend);
        }

        [HttpPost]
        public IActionResult RentAction(int User, int Movie, DateTime RentDate, DateTime ReturnDate)
        {
            if (RentDate > ReturnDate || RentDate < new DateTime())
            {
                TempData["error"] = "Data wypożyczenia nie może być w czasie przyszlym, ani być większa, niż data oddania";
                return RedirectToAction("Rent", "Lends", new { id = Movie });
                //ViewBag.error = "Data wypożyczenia nie może być w czasie przyszlym, ani być większa, niż data oddania";
                //return RedirectToAction("Rent", "Lends", new { id = Movie });
            }
            var movie = _context.Movie.Where(m => m.Id == Movie).FirstOrDefault();
            if (movie == null)
            {
                ViewBag.error = "Film nie istnieje";
                return RedirectToAction("Rent", "Lends", new { id = Movie });
            }
            var lend = new Lend();
            lend.User = _context.User.Where(m => m.Id == User).First();
            lend.Movie = _context.Movie.Where(m => m.Id == Movie).First();
            lend.RentDate = RentDate;
            lend.ReturnDate = ReturnDate;
            lend.lendStatus = LendStatus.Rented;
            lend.Price = (ReturnDate - RentDate).Days * lend.Movie.Price;
            //var lendsForMovie = _context.Lend.Where(m => m.Movie == lend.Movie &&
            //(
            //m.ReturnDate == null || (
            //m.RentDate > lend.ReturnDate && m.ReturnDate > lend.RentDate)
            //)
            //).FirstOrDefault();
            //if (lendsForMovie != null)
            //{
            //    return RedirectToAction();// nie można wypożyczyć
            //}
            _context.Add(lend);
            _context.SaveChanges();
            return Redirect("~/Lends/");//przekierowanie do wypozyczen
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

        public IActionResult SetPaid(int id)
        {
            var lend = _context.Lend.Where(m => m.Id == id).FirstOrDefault();
            if (lend == null)
            {
                ViewBag.error = "Zamówienie nie istnieje";
            }
            if (!lend.isRented())
            {
                ViewBag.error = "Zamówienie nie jest w statusie " + LendStatus.Rented;
            }
            lend.lendStatus = LendStatus.Paid;
            _context.Update(lend);
            _context.SaveChanges();
            TempData["success"] = "Zmieniono status zamówienia";
            //ViewBag.success = "Zmieniono status zamówienia";
            return RedirectToAction("Index", "Lends");
        }

        public IActionResult SetRejected(int id)
        {
            var lend = _context.Lend.Where(m => m.Id == id).FirstOrDefault();
            if (lend == null)
            {
                ViewBag.error = "Zamówienie nie istnieje";
            }
            if (!lend.isRented())
            {
                ViewBag.error = "Zamówienie nie jest w statusie " + LendStatus.Rented;
            }
            lend.lendStatus = LendStatus.Rejected;
            _context.Update(lend);
            _context.SaveChanges();
            ViewBag.success = "Zmieniono status zamówienia";
            return RedirectToAction("Index", "Lends");
        }

        public IActionResult SetCanceled(int id)
        {
            var lend = _context.Lend.Where(m => m.Id == id).FirstOrDefault();
            if (lend == null)
            {
                ViewBag.Error = "Zamówienie nie istnieje";
            }
            if (!lend.isRented())
            {
                ViewBag.Error = "Zamówienie nie jest w statusie " + LendStatus.Rented;
            }
            lend.lendStatus = LendStatus.Canceled;
            _context.Update(lend);
            _context.SaveChanges();
            ViewBag.Success = "Zmieniono status zamówienia";
            return RedirectToAction("Index", "Lends");
        }
    }
}
