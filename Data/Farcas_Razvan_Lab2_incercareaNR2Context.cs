using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farcas_Razvan_Lab2_incercareaNR2.Models;

namespace Farcas_Razvan_Lab2_incercareaNR2.Data
{
    public class Farcas_Razvan_Lab2_incercareaNR2Context : DbContext
    {
        public Farcas_Razvan_Lab2_incercareaNR2Context (DbContextOptions<Farcas_Razvan_Lab2_incercareaNR2Context> options)
            : base(options)
        {
        }

        public DbSet<Farcas_Razvan_Lab2_incercareaNR2.Models.Book> Book { get; set; } = default!;

        public DbSet<Farcas_Razvan_Lab2_incercareaNR2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Farcas_Razvan_Lab2_incercareaNR2.Models.Author>? Author { get; set; }

        public DbSet<Farcas_Razvan_Lab2_incercareaNR2.Models.Category>? Category { get; set; }

        public DbSet<Farcas_Razvan_Lab2_incercareaNR2.Models.BookCategory>? BookCategory { get; set; }
    }
}
