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
                    new  User {FirstName = "Janek", LastName = "Użytkownik",  Email = "janek@user1.pl", Password = "Janek123", Role = PermissionRole.User },
                    new  User {FirstName = "Sylwia", LastName = "Użytkownik",  Email = "sylwia@user2.pl", Password = "Sylwia123", Role = PermissionRole.User },
                    new  User {FirstName = "Mietek", LastName = "Administrator",  Email = "mietek@admin.pl", Password = "Mietek123", Role = PermissionRole.Admin }
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
                    new Category { Name ="Thriller"},
                    new Category { Name ="Horror"},
                    new Category { Name ="Psychologiczny"},
                    new Category { Name ="Czarna komedia "},
                    new Category { Name ="Akcja"},
                    new Category { Name ="Kryminał"}
                };

                ICollection<Category> categories1 = new List<Category>
                {
                    categories[0]
                };

                ICollection<Category> categories2 = new List<Category>
                {
                    categories[4],
                    categories[5]
                };

                ICollection<Category> categories3 = new List<Category>
                {
                    categories[1]
                };

                ICollection<Category> categories4 = new List<Category>
                {
                    categories[2]
                };
                ICollection<Category> categories5 = new List<Category>
                {
                    categories[3]
                };

                var movies = new Movie[]
                {
                    new  Movie {Categories = categories1, Name = "The Infernal Machine", Price = (decimal) 20, Description = "Kontrowersyjny i samotny pisarz musi się ujawnić, gdy zaczyna otrzymywać niepokojące listy od psychofana."},
                    new  Movie {Categories = categories2,  Name = "Lou", Price = (decimal) 20, Description = "Szorstka samotniczka wiodąca spokojne życie ze swym psem staje do walki z żywiołami i własną mroczną przeszłością, gdy córeczka sąsiadki zostaje porwana podczas burzy."},
                    new  Movie {Categories = categories1 ,  Name = "Violent Night", Price = (decimal) 2.00, Description = "Gdy grupa najemników atakuje posiadłość zamożnej rodziny, Święty Mikołaj musi wkroczyć, aby uratować dzień (i Boże Narodzenie)."},
                    new  Movie {Categories = categories3,  Name = "The Invitation", Price = (decimal) 2.00, Description = "Po wykonaniu testu DNA Evie odnajduję rodzinę, o której istnieniu nie wiedziała. Zaproszona na wystawne wesele początkowo jest nimi zafascynowana, ale na światło dzienne wychodzą przerażające rodzinne sekrety."},
                    new  Movie {Categories = categories4,  Name = "Jaula", Price = (decimal) 2.00, Description = "Kiedy pewna para znajduje doświadczone przez los dziecko, kobieta stara się zrozumieć dziwne zachowania dziewczynki, by odkryć jej tożsamość i mroczną przeszłość."},
                    new  Movie {Categories = categories3,  Name = "Smile", Price = (decimal) 2.00, Description = "Po tym, jak dr Rose Carter bierze udział w traumatycznym zdarzeniu z udziałem pacjentki, wokół niej zaczynają dziać się niewytłumaczalne rzeczy."},
                    new  Movie {Categories = categories5,  Name = "The Menu", Price = (decimal) 2.00, Description = "Młoda para wybiera się na odległą wyspę, do ekskluzywnej restauracji. Okazuje się jednak, że nie wszystko jest takie jakim się wydaje a w menu czekają zaskakujące niespodzianki."}
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