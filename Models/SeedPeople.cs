using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcDB.Models
{
    public static class SeedPeople
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcContext>>()))
            {
                // Look for any movies.
                if (context.People.Any())
                {
                    return;   // DB has been seeded
                }

                context.People.AddRange(
                    new People
                    {
                        PersonId = 1,
			Name = "P1",
                    },

		    new People
                    {
                        PersonId = 2,
			Name = "P2",
                    },

		    new People
                    {
                        PersonId = 3,
			Name = "P3",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
