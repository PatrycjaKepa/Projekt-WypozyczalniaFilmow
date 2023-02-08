using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projekt_WypozyczalniaFilmow.Models;

namespace Projekt_WypozyczalniaFilmow.Data
{
    public class MovieDataInitislizer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Projekt_WypozyczalniaFilmowContext>();
                if (context.Movie.Any())
                {
                    return;
                }

                var categories = new Category[]
                {
                    new Category { Name ="Horror"},
                    new Category { Name ="Comedy"}
                };

                var movies = new Movie[]
                {
                    new  Movie { Name = "test1", Price = 20, Description = "fajny film"},
                    new  Movie { Name = "test2", Price = 20, Description = "fajny film"}
                };

                foreach (Movie movie in movies)
                {
                    context.Movie.Add(movie);
                }
                context.SaveChanges();
            }

        }
    }
}
