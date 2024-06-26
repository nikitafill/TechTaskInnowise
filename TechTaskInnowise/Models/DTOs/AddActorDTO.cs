﻿using System.ComponentModel.DataAnnotations;

namespace TechTaskInnowise.Models.DTOs
{
    public class AddActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> FilmIds { get; set; }
    }
}
