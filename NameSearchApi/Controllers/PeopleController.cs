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
using System.IO;

namespace NameSearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private PersonService _personService;
        public PeopleController( PersonService personService)
        {
            _personService = personService;
        }
        // GET api/People
        [HttpGet()]
        public async Task<IActionResult> Get(string name)
        {
            //if (IsNullOrEmpty(name))
             //   return StatusCode(400, "name can't be blank");
            List<PersonProfile> people = await _personService.SearchPeopleByName(name);


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
            var person = await _personService.GetPersonByID(id);
            if(person ==null)
                return StatusCode(404);
            else
            {
                string photoUrl;
                photoUrl = await _personService.PostPhoto(file, person);

                return Ok(photoUrl);
            }
        }
       
        // GET api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Person person = await _personService.GetPersonDetail(id);


            if (person != null)
                return Ok(person);
            else
                return StatusCode(404);
        }


        // POST api/People
        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            try
            {
                return Ok(await _personService.AddPerson(person));
            }
            catch(Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        /*
        // DELETE api/People/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
