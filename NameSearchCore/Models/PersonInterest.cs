using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NameSearchCore
{
    [Table("PeopleInterests")]
    public class PersonInterest
    {
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int InterestId { get; set; }
        public Person person { get; set; }
        public Interest Interest { get; set; }

    }
}