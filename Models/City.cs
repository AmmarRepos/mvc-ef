using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class City
    {
        public int CityId { get; set; }
	[Display(Name = "City Name")]
        public string CityName { get; set; }

	// One-to-Many (City - Country)
	public int CountryId { get; set; }
	public Country Country { get; set; }

	// One-to-Many (Person - City)
	public ICollection<Person>? People { get; set; }
    }
}
