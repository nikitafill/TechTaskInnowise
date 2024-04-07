using System.ComponentModel.DataAnnotations;

namespace TechTaskInnowise.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  ICollection<Film> Films { get; set; }
    }
}
