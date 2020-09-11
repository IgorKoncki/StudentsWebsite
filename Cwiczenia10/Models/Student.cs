using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.Models
{
    public class Student
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Studies { get; set; }
        [Required]
        public int Id;
    }
}
