namespace InnowiseTechTask.Models.DTOs
{
    public class UpdActorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
