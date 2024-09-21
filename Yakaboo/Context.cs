using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Configurations;
using Yakaboo.Models;

namespace Yakaboo
{
    public class Context : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YakabooLibrary;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Author>(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration<Book>(new BookConfiguration());
            modelBuilder.ApplyConfiguration<Publisher>(new PublisherConfiguration());

            modelBuilder.Entity<Author>().HasData(
                new Author { ID = 1, Name = "Stephen Robert", Surname = "Covey" },
                new Author { ID = 2, Name = "Napoleon", Surname = "Hill" });
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { ID = 1, Name = "KSD", Address = "Some1" });
            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, Title = "The 7 habits of highly effective people", Price = 260, Size = 356,  AuthorID = 1, PublisherID = 1},
                new Book { ID = 2, Title = "Think and grow reach", Price = 237, Size = 225, AuthorID = 2, PublisherID = 1 });
        }
    }
}