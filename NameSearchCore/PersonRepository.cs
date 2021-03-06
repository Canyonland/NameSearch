﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.String;
namespace NameSearchCore
{
    public class PersonRepository
    {
        private readonly CommunityContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PersonRepository (CommunityContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Person> Get(int id)
        {
            return await _dbContext.People.FindAsync(id);

        }
        public async Task<Person> AddPerson(Person person)
        {
              _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }
        public async Task<Person> GetDetail(int id)
        {
            return await _dbContext.People.AsQueryable().Include(person => person.PeopleInterests).ThenInclude( pi => pi.Interest).Where(person => person.Id == id).FirstOrDefaultAsync();

        }
        public async Task<List<Person>> SearchPeople(string name)
        {


            if (IsNullOrEmpty(name))
                return await _dbContext.People.Include(person => person.PeopleInterests).ThenInclude(pi => pi.Interest).ToListAsync();
            else
                return await _dbContext.People.AsQueryable().Include(person => person.PeopleInterests).ThenInclude(pi => pi.Interest).Where(p => p.FirstName.ToLower().IndexOf ( name.ToLower())!=-1 || p.LastName.ToLower().IndexOf(name.ToLower()) != -1).ToListAsync();
            
           
           
        }
        public async Task Update(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
