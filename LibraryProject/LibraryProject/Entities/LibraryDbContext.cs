using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Entities
{
    public class LibraryDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BooksStatus { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(b => b.AuthoLastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<BookStatus>()
                .Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<BorrowedBook>()
                .Property(bb => bb.DateOfBorrowingBook)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
              .Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
              .Property(c => c.DateOfBirth)
              .IsRequired()
              .HasMaxLength(100);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
