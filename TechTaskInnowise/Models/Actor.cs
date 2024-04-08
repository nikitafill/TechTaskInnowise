using System.ComponentModel.DataAnnotations;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new List<Film>();
        }
    }
}
