using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public int id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        public List<ContactDetails> contactDetails { get; set; }
    }
}
