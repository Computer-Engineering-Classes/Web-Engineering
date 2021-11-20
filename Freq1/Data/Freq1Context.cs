using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Freq1.Models;

namespace Freq1.Data
{
    public class Freq1Context : DbContext
    {
        public Freq1Context (DbContextOptions<Freq1Context> options)
            : base(options)
        {
        }

        public DbSet<Freq1.Models.Contacto> Contacto { get; set; }
    }
}
