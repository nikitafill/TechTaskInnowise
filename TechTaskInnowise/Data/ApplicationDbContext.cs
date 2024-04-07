using TechTaskInnowise.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.Models;

namespace TechTaskInnowise.Data
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
