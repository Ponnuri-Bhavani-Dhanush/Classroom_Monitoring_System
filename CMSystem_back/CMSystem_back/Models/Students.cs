using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSystem_back.Models
{
    public class Students
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string Rollnumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Place { get; set; }

    }
}