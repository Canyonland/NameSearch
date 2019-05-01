using System;
using System.Collections.Generic;

namespace NameSearchCore
{
   

    public class Interest
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
