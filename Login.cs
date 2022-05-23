using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Login
    {

        [Key]
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Special Characters are not allowed")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
}
