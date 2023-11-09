using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Contact
{
    public class SendMail
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
