using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class Language
    {
	[Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }
	// Many-to-Many (Language - Person)
	public virtual ICollection<Person> People { get; set; }
	// public List<Person> People { get; set; } = new List<Person>(); 
    }
}
