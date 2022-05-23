using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Patient
    {

        [Key]
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Range(0,120,ErrorMessage ="Age should be in between 120")]
        public int Age { get; set; }
        [Required]
        public string DateofBirth { get; set; }
    }
}
