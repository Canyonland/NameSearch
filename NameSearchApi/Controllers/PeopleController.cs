using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NameSearchCore;
using static System.String;
using static System.Linq.Queryable;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace NameSearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private PersonRepository _personRepository;
        private FileSaver _fileSaver;
        public PeopleController(PersonRepository personRepository, FileSaver fileSaver)
        {
            _personRepository = personRepository;
            _fileSaver = fileSaver;
        }
        // GET api/People
        [HttpGet()]
        public async Task<IActionResult> Get(string name)
        {
            if (IsNullOrEmpty(name))
                return StatusCode(400, "name can't be blank");
            List<PersonProfile> people = await _personRepository.SearchPeople(name);


            if (people != null && people.Any())
                return Ok(people);
            else
                return StatusCode(404);
        }


       

        // POST api/People/1
        [HttpPost("{id}/Photo")]
        public async Task<IActionResult> PostPhoto(int id, IFormFile  file)
        {
            if (file.ContentType != "image/jpeg")
                return StatusCode(400, "please upload a jpg image");
            var person = await _personRepository.Get(id);
            if(person ==null)
                return StatusCode(404);
            else
            {
               
                person.PicturePath = await _fileSaver.Save(file);
                await _personRepository.UpdateAsync(person);
                return Ok(person);
            }
        }
       
        // GET api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Person person = await _personRepository.GetDetail(id);


            if (person != null)
                return Ok(person);
            else
                return StatusCode(404);
        }
        /*
        // PUT api/People/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/People/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
