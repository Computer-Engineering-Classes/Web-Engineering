using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2021_PAPP1_2.Models;

namespace _2021_PAPP1_2.Data
{
    public class _2021_PAPP1_2Context : DbContext
    {
        public _2021_PAPP1_2Context (DbContextOptions<_2021_PAPP1_2Context> options)
            : base(options)
        {
        }

        public DbSet<_2021_PAPP1_2.Models.Livro> Livro { get; set; }
    }
}
