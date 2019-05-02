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

        public DbSet<PersonInterest> PeopleInterests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Henry", LastName = "Smith", Age = 30, Address = "1234 Quiet Street" },
                new Person { Id = 2, FirstName = "Lisa", LastName = "Rich", Age = 30, Address = "1234 Noisy Street" },
                new Person { Id = 3, FirstName = "Emma", LastName = "Moses", Age = 30, Address = "1234 Normal Street" },
                new Person { Id = 4, FirstName = "Henry", LastName = "Moor", Age = 30, Address = "1234 Main Street" },
                new Person { Id = 5, FirstName = "Rich", LastName = "Lisa", Age = 30, Address = "1234 State Street" },
                new Person { Id = 6, FirstName = "John", LastName = "Moor", Age = 30, Address = "1234 Wall Street" },
                new Person { Id = 7, FirstName = "Mark", LastName = "Dean", Age = 30, Address = "1234 Spring Street" },
                new Person { Id = 8, FirstName = "Rob", LastName = "Henderson", Age = 30, Address = "1234 Summer Street" },
                new Person { Id = 9, FirstName = "Tiffany", LastName = "Locante", Age = 30, Address = "1234 Fall Street" },
                new Person { Id = 10, FirstName = "Laura", LastName = "Carrell", Age = 30, Address = "1234 Winter Street" }


                );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Value = "reading" },
                new Interest { Id = 2, Value = "watching movies" },
                new Interest { Id = 3, Value = "travelling" },
                new Interest { Id = 4, Value = "biking" },
                new Interest { Id = 5, Value = "running" },
                new Interest { Id = 6, Value = "gardening" },
                new Interest { Id = 7, Value = "shopping" },
                new Interest { Id = 8, Value = "boating" },
                new Interest { Id = 9, Value = "fishing" },
                new Interest { Id = 10, Value = "swimming" }
                );

            modelBuilder.Entity<PersonInterest>().HasData(
               new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
               new PersonInterest { Id = 2, PersonId = 1, InterestId = 2 },
               new PersonInterest { Id = 3, PersonId = 2, InterestId = 2 },
               new PersonInterest { Id = 4, PersonId = 2, InterestId = 3 },
               new PersonInterest { Id = 5, PersonId = 3, InterestId = 3 },
               new PersonInterest { Id = 6, PersonId = 3, InterestId = 4 },
               new PersonInterest { Id = 7, PersonId = 4, InterestId = 4 },
               new PersonInterest { Id = 8, PersonId = 4, InterestId = 5 },
               new PersonInterest { Id = 9, PersonId = 5, InterestId = 5 },
               new PersonInterest { Id = 10, PersonId = 5, InterestId = 6 },
               new PersonInterest { Id = 11, PersonId = 6, InterestId = 6 },
               new PersonInterest { Id = 12, PersonId = 6, InterestId = 7 },
               new PersonInterest { Id = 13, PersonId = 7, InterestId = 7 },
               new PersonInterest { Id = 14, PersonId = 7, InterestId = 8 },
               new PersonInterest { Id = 15, PersonId = 8, InterestId = 8 },
               new PersonInterest { Id = 16, PersonId = 8, InterestId = 9 },
               new PersonInterest { Id = 17, PersonId = 9, InterestId = 9 },
               new PersonInterest { Id = 18, PersonId = 9, InterestId = 10 },
               new PersonInterest { Id = 19, PersonId = 10, InterestId = 10 },
               new PersonInterest { Id = 20, PersonId = 10, InterestId = 1 }


               );
        }


    }
}