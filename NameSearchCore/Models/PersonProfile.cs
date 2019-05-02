using System;
using System.Collections.Generic;
using System.Text;

namespace NameSearchCore
{
    public class PersonProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhotoURI { get; set; }
        public string PicturePath { get; set; }
        public string PhotoUploadURI { get; set; }

        public List<string> Interests { get; set; }
    }
}
