using System;
using System.IO;
using Xunit;
using NameSearchCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NameSearchTest
{
    public class IntegrationTest
    {
        private PersonService _personService;
        private CommunityContext _communityContext;
        private PersonRepository _personRepository;

        public IntegrationTest()
        {
            var dbOptions = new DbContextOptionsBuilder<CommunityContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _communityContext = new CommunityContext(dbOptions);
            _personRepository = new PersonRepository(_communityContext);


        }
        [Fact]
        public async Task AddPersonTest()
        {
            Person newPerson = new Person { FirstName = "first", LastName = "Last", Age = 10, Address = "Somewhere" };
            _personRepository.AddPerson(newPerson).Wait();

            Person savedPerson = await _personRepository.Get(1);

            Assert.True(savedPerson != null,"expecting the person is saved with Id 1");
            Assert.Equal(newPerson.FirstName, savedPerson.FirstName);


           
        }
    }
}
