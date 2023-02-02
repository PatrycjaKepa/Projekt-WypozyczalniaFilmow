using Microsoft.AspNetCore.Mvc;
using Projekt_WypozyczalniaFilmow.Models;
using System.Diagnostics;

namespace Projekt_WypozyczalniaFilmow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Produkt(string name)
        {
            return View();
        }
    }
}