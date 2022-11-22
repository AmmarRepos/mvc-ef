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
                if (context.Countries.Any())
                {
                    return;   // DB has been seeded
                }

                context.Countries.AddRange(
                    new Country
                    {
                        CountryId = 1,
			CountryName = "Country1",
                    },

		    new Country
                    {
			CountryId = 2,
			CountryName = "Country2",
                    },

		    new Country
                    {
			CountryId = 3,
			CountryName = "Country3",
                    }
                );

		context.Cities.AddRange(
                    new City
                    {
                        CityId = 1,
			CityName = "CityA",
			CountryId = 1,
                    },
		    new City
		    {
                        CityId = 2,
			CityName = "CityB",
			CountryId = 1,
                    },
		    new City
		    {
                        CityId = 3,
			CityName = "CityC",
			CountryId = 2,
                    }
                );
		context.People.AddRange(
                    new Person
                    {
                        PersonId = 1,
			PersonName = "PersonA",
			CityId = 1,
                    },
		    new Person
		    {
                        PersonId = 2,
			PersonName = "PersonB",
			CityId = 1,
                    },
		    new Person
		    {
                        PersonId = 3,
			PersonName = "PersonC",
			CityId = 2,
                    }
                );
		context.Languages.AddRange(
                    new Language
                    {
                        LanguageId = 1,
			LanguageName = "LanguageA",
		    },
		    new Language
		    {
                        LanguageId = 2,
			LanguageName = "LanguageB",
                    },
		    new Language
		    {
                        LanguageId = 3,
			LanguageName = "LangaugeC",
                    }
                );
                context.SaveChanges();
	    }
	}
    }
}
