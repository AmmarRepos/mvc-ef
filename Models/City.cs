using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class City
    {
	[Key]
        public int CityId { get; set; }
        public string Name { get; set; }

	// One-to-Many (City - Country)
	public int CountryId { get; set; }
	public Country Country { get; set; }

	// One-to-Many (Person - City)
	public ICollection<Person> Person { get; set; }


    }
}
