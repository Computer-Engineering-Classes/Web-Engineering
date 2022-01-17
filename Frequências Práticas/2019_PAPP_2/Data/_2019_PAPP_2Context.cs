using _2019_PAPP_2.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019_PAPP_2.Data
{
    public class _2019_PAPP_2Context : DbContext
    {
        public _2019_PAPP_2Context(DbContextOptions<_2019_PAPP_2Context> options)
            : base(options)
        {
        }

        public DbSet<Carro> Carro { get; set; }

        public DbSet<Marca> Marca { get; set; }
    }
}
