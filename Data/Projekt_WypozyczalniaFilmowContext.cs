using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_WypozyczalniaFilmow.Models;

namespace Projekt_WypozyczalniaFilmow.Data
{
    public class Projekt_WypozyczalniaFilmowContext : DbContext
    {
        public Projekt_WypozyczalniaFilmowContext (DbContextOptions<Projekt_WypozyczalniaFilmowContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt_WypozyczalniaFilmow.Models.User> User { get; set; } = default!;
    }
}
