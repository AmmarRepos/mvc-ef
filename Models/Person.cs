using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }

	// One-to-Many (Person - City)
	public int CityId { get; set; }
	public City? City { get; set; }

	// public virtual ICollection<LanguagePerson> LanguagesPeople { get; set; }
	// Many-to-Many (Language - Person)
	public virtual ICollection<Language> Languages { get; set; }

	// [Display(Name = "Birth Date")]
        // [DataType(DataType.Date)]
        // public DateTime BirthDate { get; set; }

	// public List<Language> Langauges { get; set; } = new List<Language>();
    }
}
