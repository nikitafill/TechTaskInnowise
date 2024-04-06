using InnowiseTechTask.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using InnowiseTechTask.Models;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.Models;

namespace InnowiseTechTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
