using Microsoft.EntityFrameworkCore;
using QuantumGate.BookCatalog.Models;
using System;

namespace QuantumGate.BookCatalog.EF
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext(DbContextOptions<BookCatalogContext> options) : base(options) { }
        public virtual DbSet<Book>? Books { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}