using Microsoft.AspNetCore.Mvc;
using Projekt_WypozyczalniaFilmow.Models;
using System.Diagnostics;

namespace Projekt_WypozyczalniaFilmow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("role") == (int)PermissionRole.Admin)
            {
                return View("IndexAdmin");//strona glowna po zalogowaniu sie admina
            }
            if (HttpContext.Session.GetInt32("role") == (int)PermissionRole.User)
            {
                return View("IndexUser");//strona glowna po zalogowaniu sie użytkownika
            }
            return View("Index");
        }
    }
}