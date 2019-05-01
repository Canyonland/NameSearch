using Microsoft.AspNetCore.Http;
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
        public PersonRepository (CommunityContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Person> Get(int id)
        {
            return await _dbContext.People.FindAsync(id);

        }
        public async Task<Person> GetDetail(int id)
        {
            return await _dbContext.People.AsQueryable().Include(person => person.Interests).Where(person => person.Id == id).FirstOrDefaultAsync();

        }
        public async Task<List<PersonProfile>> SearchPeople(string name)
        {

                
                //Thread.Sleep(10000);

            var people = await _dbContext.People.AsQueryable().Where(p => p.FirstName.ToLower() == name.ToLower() || p.LastName == name.ToLower()).ToListAsync();

            string personApiPath = $@"{_httpContextAccessor.HttpContext.Request.Scheme.ToString()}://{_httpContextAccessor.HttpContext.Request.Host.ToString()}{_httpContextAccessor.HttpContext.Request.Path.ToString()}";
            return people.ConvertAll<PersonProfile>(p => new PersonProfile
            {

                Name = p.FirstName + p.LastName,
                Age = p.Age,
                Address = p.Address,
                Id = $@"GET {personApiPath}/{p.Id}",
                PicturePath = p.PicturePath,
                PhotoUploadURI = $@"POST {personApiPath}/{p.Id}/photo"


            });
           
        }
        public async Task UpdateAsync(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
