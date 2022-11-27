using System.ComponentModel.DataAnnotations;

namespace mvc_ef.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
	
	// public virtual ICollection<LanguagePerson> LanguagesPeople { get; set; }
	// Many-to-Many (Language - Person)
	public virtual ICollection<Person> People { get; set; }
    }
}
