using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

	// One-to-Many (City - Country)
	public ICollection<City> Cities { get; set; }
    }
}
