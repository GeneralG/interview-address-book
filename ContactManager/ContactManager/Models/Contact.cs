using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<ContactDetails> contactDetails { get; set; }
    }
}
