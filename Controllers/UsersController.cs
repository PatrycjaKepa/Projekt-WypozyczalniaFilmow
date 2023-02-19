using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_WypozyczalniaFilmow.Data;
using Projekt_WypozyczalniaFilmow.Models;
using System.Text.RegularExpressions;

namespace Projekt_WypozyczalniaFilmow.Controllers
{
    public class UsersController : Controller
    {
        private readonly Projekt_WypozyczalniaFilmowContext _context;

        public UsersController(Projekt_WypozyczalniaFilmowContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Birthdate,Email,Password")] User user)
        {
            string pattern = "[a-z][A-Z][0-9]";
            Regex r = new Regex(pattern);
            
            if(ModelState.IsValid) 
            {
                if (r.IsMatch(user.Password) == false)
                {
                    ViewBag.error = ("Hasło musi posiadać przynajmniej jedną dużą literę i cyfrę");
                }
            }
            else
            {
                ViewBag.error = ("Hasło musi posiadać przynajmniej jedną dużą literę i cyfrę");
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Birthdate,Email,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'Projekt_WypozyczalniaFilmowContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.User.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginAction([Bind("Email,Password")] User user)
        {
            var authenticatedUser = _context.User.Where(
                u => u.Email == user.Email &&
                u.Password == user.Password
                ).SingleOrDefault();

            if (authenticatedUser == null)
            {
                ViewBag.error = "Coś poszło nie tak. Sprawdź e-mail lub hasło"; //loginPage - moze byc to samo, ale z parametrami i komunikatem bledu
                return View("Login");
            }

            HttpContext.Session.SetString("user", authenticatedUser.Email);
            HttpContext.Session.SetInt32("userId", authenticatedUser.Id);
            HttpContext.Session.SetInt32("role", (int) authenticatedUser.Role);

            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult LogoutAction()
        {
            HttpContext.Session.Clear();
            
            return Redirect("~/"); 
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return View("Index", "Home");
            }
            var user = _context.User.Where(m => m.Id == userId);
            return View(user.First());
        }
    }
}
