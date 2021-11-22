using Aula4.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula4.Data
{
    public class Aula4Context : DbContext
    {
        public Aula4Context(DbContextOptions<Aula4Context> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Course> Course { get; set; }
    }
}
