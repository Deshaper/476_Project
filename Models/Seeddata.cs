//using Microsoft.EntityFrameworkCore;

//namespace MVC476.Models
//{
  //  public class Seeddata
    //{
    //}
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC476.Data;
using System;
using System.Linq;

namespace MVC476.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MVC476Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<MVC476Context>>()))
        {
            // Look for any movies.
            if (context.Test.Any())
            {
                return;   // DB has been seeded
            }
            context.Test.AddRange(
                new Test
                {
                    name = "When Harry Met Sally",
                    BirthDay = DateTime.Parse("1989-2-12"),
                    description = "Romantic Comedy",
                    status = 7
                },
                new Test
                {
                    name = "Ghostbusters ",
                    BirthDay = DateTime.Parse("1984-3-13"),
                    description = "Comedy",
                    status = 8
                },
                new Test
                {
                    name = "Ghostbusters 2",
                    BirthDay = DateTime.Parse("1986-2-23"),
                    description = "Comedy",
                    status = 9
                },
                new Test
                {
                    name = "Rio Bravo",
                    BirthDay = DateTime.Parse("1959-4-15"),
                    description = "Western",
                    status = 3
                }
            );
            context.SaveChanges();
        }
    }
}