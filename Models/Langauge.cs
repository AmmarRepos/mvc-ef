using System.ComponentModel.DataAnnotations;

namespace MvcDB.Models
{
    public class Language
    {
	[Key]
        public int Id { get; set; }
        public string Name { get; set; }
	public List<Person> People { get; set; } = new List<Person>(); 

    }
}
