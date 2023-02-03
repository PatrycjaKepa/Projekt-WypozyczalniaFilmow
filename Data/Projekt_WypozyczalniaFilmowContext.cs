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
        public DbSet<Projekt_WypozyczalniaFilmow.Models.Movie> Movie { get; set; } = default!;
        public DbSet<Projekt_WypozyczalniaFilmow.Models.Category> Category { get; set; } = default!;
        public DbSet<Projekt_WypozyczalniaFilmow.Models.Lend> Lend { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Lend>().ToTable("Lend");
        }
    }
}
