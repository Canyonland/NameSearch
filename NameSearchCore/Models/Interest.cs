using System;
using System.Collections.Generic;

namespace NameSearchCore
{
   

    public class Interest
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<PersonInterest> PeopleInterests { get; set; }
    }
}
