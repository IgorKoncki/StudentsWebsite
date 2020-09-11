using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.Models
{
    public class CreateStudentViewModel
    {
        public SelectList AllStudies { get; set; }
        public Student Student { get; set; }
    }
}
