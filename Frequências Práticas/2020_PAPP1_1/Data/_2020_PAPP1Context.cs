using Microsoft.EntityFrameworkCore;
using _2020_PAPP1.Models;

namespace _2020_PAPP1.Data
{
    public class _2020_PAPP1Context : DbContext
    {
        public _2020_PAPP1Context(DbContextOptions<_2020_PAPP1Context> options)
            : base(options)
        {
        }

        public DbSet<Utilizador> Utilizador { get; set; }
    }
}
