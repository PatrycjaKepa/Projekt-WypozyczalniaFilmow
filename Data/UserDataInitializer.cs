using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projekt_WypozyczalniaFilmow.Models;

namespace Projekt_WypozyczalniaFilmow.Data
{
    public static class UserDataInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Projekt_WypozyczalniaFilmowContext>();
                if (context.User.Any())
                {
                    return;
                }

                var users = new User[]
                {
                    new  User {FirstName = "user", LastName = "test1",  Email = "user@user1.pl", Password = "user1", Role = PermissionRole.User },
                    new  User {FirstName = "admin", LastName = "test2",  Email = "admin@admin1.pl", Password = "admin1", Role = PermissionRole.Admin }
                };

                foreach (User user in users)
                {
                    context.User.Add(user);
                }
                context.SaveChanges();

                if (context.Movie.Any())
                {
                    return;
                }

                var categories = new Category[]
                {
                    new Category { Name ="Horror"},
                    new Category { Name ="Comedy"},
                    new Category { Name ="Action"}
                };

                ICollection<Category> categories1 = new List<Category>
                {
                    categories[1],
                    categories[2]
                };

                ICollection<Category> categories2 = new List<Category>
                {
                    categories[1],
                    categories[0]
                };

                var movies = new Movie[]
                {
                    new  Movie {Categories = categories1, Name = "Avatar", Price = 20, Description = "fajny film"},
                    new  Movie {Categories = categories2,  Name = "Pukając do drzwi", Price = 20, Description = "fajny film"},
                    new  Movie {Categories = categories2,  Name = "Terminator", Price = 20, Description = "fajny film"}
                };

                foreach (Movie movie in movies)
                {
                    context.Movie.Add(movie);
                }
                context.SaveChanges();

                var lends = new Lend[]
                {//Client do wyrzucenia i wybierasz usera z tabeli users
                    new Lend {User=users[0], Movie=movies[0], RentDate = new DateTime(2023-02-10), ReturnDate= new DateTime(2023-02-15)},
                    new Lend {User=users[0], Movie=movies[1], RentDate = new DateTime(2023-02-10), ReturnDate= new DateTime(2023-02-15)},
                    new Lend {User=users[1], Movie=movies[2], RentDate = new DateTime(2023-02-12), ReturnDate= new DateTime(2023-02-16)}
                };

                foreach (Lend lend in lends)
                {
                    context.Lend.Add(lend);
                }
                context.SaveChanges();
            }
            
        }
    }
}