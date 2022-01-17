using _2019_PAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019_PAPP.Data
{
    public class _2019_PAPPContext : DbContext
    {
        public _2019_PAPPContext(DbContextOptions<_2019_PAPPContext> options)
            : base(options)
        {
        }

        public DbSet<Piloto> Piloto { get; set; }

        public DbSet<Carro> Carro { get; set; }
    }
}
