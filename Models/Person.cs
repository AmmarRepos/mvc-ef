using System.ComponentModel.DataAnnotations;

namespace MvcDB.Models
{
    public class Person
    {
	[Key]
        public int Id { get; set; }
        public string Name { get; set; }

	// [Display(Name = "Birth Date")]
        // [DataType(DataType.Date)]
        // public DateTime BirthDate { get; set; }

        public List<Language> Langauges { get; set; } = new List<Language>(); 
    }
}
