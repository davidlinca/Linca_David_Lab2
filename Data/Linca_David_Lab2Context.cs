using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Linca_David_Lab2.Models;

namespace Linca_David_Lab2.Data
{
    public class Linca_David_Lab2Context : DbContext
    {
        public Linca_David_Lab2Context (DbContextOptions<Linca_David_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Linca_David_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Linca_David_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Linca_David_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Linca_David_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
