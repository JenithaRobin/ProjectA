using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Schedule
    {
        [Required]
        public int Patientid { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string Doctor { get; set; }
        [Required]
        public string VisitDate { get; set; }
        [Required]
        public string AppointmentTime { get; set; }
    }
}
