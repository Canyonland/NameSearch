using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NameSearchCore
{
    public class PersonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PersonRepository _personRepository;
        private readonly string _personApiPath;

        public PersonService(IHttpContextAccessor httpContextAccessor, PersonRepository personRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _personRepository = personRepository;
            _personApiPath = $@"{_httpContextAccessor.HttpContext.Request.Scheme.ToString()}://{_httpContextAccessor.HttpContext.Request.Host.ToString()}{_httpContextAccessor.HttpContext.Request.Path.ToString()}";
        }
        public async Task<Person> GetPersonByID(int id)
        {
            return await _personRepository.Get(id);
        }
        public async Task<Person> GetPersonDetail(int id)
        {
            return await _personRepository.GetDetail(id);
        }

        public async Task<List<PersonProfile>> SearchPeopleByName (string name)
        {
            //Thread.Sleep(10000);
            List<Person> people = await _personRepository.SearchPeople(name);
            return people.ConvertAll<PersonProfile>(p => new PersonProfile
            {

                Name = $"{p.FirstName} {p.LastName}",
                Age = p.Age,
                Address = p.Address,
                Id = $@"GET {_personApiPath}/{p.Id}",
                PicturePath = p.PicturePath,
                PhotoUploadURI = $@"POST {_personApiPath}/{p.Id}/photo"


            });
        }
        public async Task<Person> AddPerson(Person newPerson)
        {
            return await _personRepository.AddPerson(newPerson);
        }

        public async Task<string> PostPhoto(IFormFile photoFile, Person person)
        {
            string photoUrl;
            string fileName;
            string fileFullName;
            string fileFullPath
;            using (MemoryStream photoStream = new MemoryStream())
            {
                photoFile.CopyTo(photoStream);

                fileName = person.PicturePath?? Guid.NewGuid().ToString();
               
                fileFullName = $"{fileName}.jpg";
                fileFullPath = $@"{Directory.GetCurrentDirectory()}\wwwroot\Photos\{fileFullName}";
                await Utilities.SaveFile(photoStream, fileFullPath);


                person.PicturePath = fileName;
                await _personRepository.Update(person);
            }
            photoUrl= $@"{_personApiPath}/{person.Id}/photos/{fileFullName}";
            return photoUrl;
        }

       
    }
}
