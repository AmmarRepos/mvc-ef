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
                        CountryId = 1,
			Name = "Country1",
                    },

		    new Country
                    {
			CountryId = 2,
			Name = "Country2",
                    },

		    new Country
                    {
			CountryId = 3,
			Name = "Country3",
                    }
                );

		context.City.AddRange(
                    new City
                    {
                        CityId = 1,
			Name = "CityA",
			CountryId = 1,
                    },
		    new City
		    {
                        CityId = 2,
			Name = "CityB",
			CountryId = 1,
                    },
		    new City
		    {
                        CityId = 3,
			Name = "CityC",
			CountryId = 2,
                    }
                );
		context.Person.AddRange(
                    new Person
                    {
                        PersonId = 1,
			Name = "PersonA",
			CityId = 1,
                    },
		    new Person
		    {
                        PersonId = 2,
			Name = "PersonB",
			CityId = 1,
                    },
		    new Person
		    {
                        PersonId = 3,
			Name = "PersonC",
			CityId = 2,
                    }
                );
		context.Language.AddRange(
                    new Language
                    {
                        LanguageId = 1,
			Name = "LanguageA",
		    },
		    new Language
		    {
                        LanguageId = 2,
			Name = "LanguageB",
                    },
		    new Language
		    {
                        LanguageId = 3,
			Name = "LangaugeC",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
