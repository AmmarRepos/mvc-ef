using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace mvc_ef.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SqliteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SqliteContext>>()))
            {
                // Look for any movies.
                if (context.Country.Any())
                {
                    return;   // DB has been seeded
                }

                context.Country.AddRange(
                    new Country
                    {
                        CountryId = 3,
			Name = "P1",
                    },

		    new Country
                    {
			CountryId = 4,
			Name = "P2",
                    },

		    new Country
                    {
			CountryId = 5,
			Name = "P3",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
