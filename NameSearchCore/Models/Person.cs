using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NameSearchCore
{
    [Table("people")]
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PicturePath { get; set; }
        public List<PersonInterest> PeopleInterests { get; set; }
    }

    
}
