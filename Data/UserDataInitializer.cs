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
                    new  User { FirstName = "user", LastName = "test1",  Email = "user@user1.pl", Password = "user1", Role = PermissionRole.User },
                    new  User { FirstName = "admin", LastName = "test2",  Email = "admin@admin1.pl", Password = "admin1", Role = PermissionRole.Admin }
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