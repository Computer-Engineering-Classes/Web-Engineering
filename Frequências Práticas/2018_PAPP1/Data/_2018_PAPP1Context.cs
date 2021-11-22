using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2018_PAPP1.Models;

namespace _2018_PAPP1.Data
{
    public class _2018_PAPP1Context : DbContext
    {
        public _2018_PAPP1Context (DbContextOptions<_2018_PAPP1Context> options)
            : base(options)
        {
        }

        public DbSet<_2018_PAPP1.Models.Cliente> Cliente { get; set; }
    }
}
