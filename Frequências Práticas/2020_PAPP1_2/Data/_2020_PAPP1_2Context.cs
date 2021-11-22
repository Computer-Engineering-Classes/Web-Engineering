using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2020_PAPP1_2.Models;

namespace _2020_PAPP1_2.Data
{
    public class _2020_PAPP1_2Context : DbContext
    {
        public _2020_PAPP1_2Context (DbContextOptions<_2020_PAPP1_2Context> options)
            : base(options)
        {
        }

        public DbSet<_2020_PAPP1_2.Models.Carro> Carro { get; set; }
    }
}
