using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaDeCarros.Models;

namespace LojaDeCarros.Data
{
    public class LojaDeCarrosContext : DbContext
    {
        public LojaDeCarrosContext (DbContextOptions<LojaDeCarrosContext> options)
            : base(options)
        {
        }

        public DbSet<LojaDeCarros.Models.Car> Car { get; set; } = default!;

        public DbSet<LojaDeCarros.Models.Customer>? Customer { get; set; }

        public DbSet<LojaDeCarros.Models.Note>? Note { get; set; }

        public DbSet<LojaDeCarros.Models.Seller>? Seller { get; set; }
    }
}
