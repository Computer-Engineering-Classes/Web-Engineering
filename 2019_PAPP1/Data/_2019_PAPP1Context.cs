using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2019_PAPP1.Models;

namespace _2019_PAPP1.Data
{
    public class _2019_PAPP1Context : DbContext
    {
        public _2019_PAPP1Context (DbContextOptions<_2019_PAPP1Context> options)
            : base(options)
        {
        }

        public DbSet<_2019_PAPP1.Models.Piloto> Piloto { get; set; }
    }
}
