using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class Country
    {
	[Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

	// One-to-Many (City - Country)
	// public ICollection<City> City { get; set; }
	public ICollection<City> Cities { get; set; }
    }
}
