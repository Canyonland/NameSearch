using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSearchCore
{
    public class CommunityContext : DbContext
    {
        public CommunityContext(DbContextOptions<CommunityContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Henry", LastName = "Smith", Age = 30, Address = "1234 Quiet Street" },
                new Person { Id = 2, FirstName = "Lisa", LastName = "Rich", Age = 30, Address = "1234 Noisy Street" },
                new Person { Id = 3, FirstName = "Emma", LastName = "Moses", Age = 30, Address = "1234 Normal Street" },
                new Person { Id = 4, FirstName = "Henry", LastName = "Moor", Age = 30, Address = "1234 Main Street" },
                new Person { Id = 5, FirstName = "Rich", LastName = "Lisa", Age = 30, Address = "1234 State Street" },
                new Person { Id = 6, FirstName = "John", LastName = "Moor", Age = 30, Address = "1234 Wall Street" }
                );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, PersonId = 1, Value = "reading" },
                new Interest { Id = 2, PersonId = 2, Value = "watching movies" },
                new Interest { Id = 3, PersonId = 3, Value = "travelling" },
                new Interest { Id = 4, PersonId = 4, Value = "biking" },
                new Interest { Id = 5, PersonId = 5, Value = "running" },
                new Interest { Id = 6, PersonId = 6, Value = "do nothing" },
                new Interest { Id = 7, PersonId = 6, Value = "reading" },
                new Interest { Id = 8, PersonId = 5, Value = "watching movies" },
                new Interest { Id = 9, PersonId = 4, Value = "travelling" },
                new Interest { Id = 10, PersonId = 3, Value = "biking" },
                new Interest { Id = 11, PersonId = 2, Value = "running" },
                new Interest { Id = 12, PersonId = 1, Value = "do nothing" }
                );
        }


    }
}