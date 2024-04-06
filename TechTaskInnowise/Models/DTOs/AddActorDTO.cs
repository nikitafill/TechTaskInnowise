﻿using System.ComponentModel.DataAnnotations;

namespace InnowiseTechTask.Models.DTOs
{
    public class AddActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
