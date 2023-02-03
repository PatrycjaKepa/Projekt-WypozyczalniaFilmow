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
                    new  User { FirstName = "test1", LastName = "test1sur",  Email = "test1@test.pl", Password = "test1"},
                    new  User { FirstName = "test1", LastName = "test1sur", Email = "test1@test.pl", Password = "test1"}
                };

                foreach (User user in users)
                {
                    context.User.Add(user);
                }
                context.SaveChanges();
            }
            
        }
    }
}