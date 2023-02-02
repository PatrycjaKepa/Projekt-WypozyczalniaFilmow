using Microsoft.AspNetCore.Mvc;
using Projekt_WypozyczalniaFilmow.Models;

namespace Projekt_WypozyczalniaFilmow.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Film()
        {
            var film = new Film
            {
                id = 1,
                name = "Avatar",
                price = 12,
                description = "Fajny film",
                category = "nwm"
            };

            return View(film);
        }
    }
}
