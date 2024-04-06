using System.ComponentModel.DataAnnotations;

namespace InnowiseTechTask.Models
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
