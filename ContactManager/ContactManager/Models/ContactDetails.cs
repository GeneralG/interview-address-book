using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class ContactDetails
    {
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$|^[\w-]+@([\w-]+\.)+[\w-]+$")]
        [DisplayName("Contact Item")]
        public string contactItem { get; set; }
        public int contactId { get; set; }
        [ForeignKey("contactId")]
        public int contact { get; set; }
    }
}
