using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cwiczenia10.Controllers
{
    public class StudentsController : Controller
    {
        static List<Student> studentsList = new List<Student>();
        static List<String> Studies = new List<String>();
        static bool InitializedAlready = false;

        public StudentsController() : base()
        {
            if (!InitializedAlready)
            {
                InitializedAlready = true;
                Studies.Add("Informatyka");
                Studies.Add("Nowe Media");
                studentsList.Add(new Student { Id = 0, FirstName = "Tomasz", LastName = "Wisniewski", Studies = "Informatyka" });
                studentsList.Add(new Student { Id = 1, FirstName = "Janusz", LastName = "Wisniewski", Studies = "Informatyka" });
                studentsList.Add(new Student { Id = 2, FirstName = "Ania", LastName = "Kowalska", Studies = "Nowe Media" });
                studentsList.Add(new Student { Id = 3, FirstName = "Jacek", LastName = "Dmowski", Studies = "Nowe Media" });
            }
        }
        public IActionResult Index()
        {
            return View(new StudentsModel { StudentsList = studentsList });
        }

        // GET: Studentss/Create
        public IActionResult Create()
        {
            return View(new CreateStudentViewModel { AllStudies = new SelectList(Studies.Distinct().ToList()) });
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Student student = studentsList.Where(s => s.Id == Id).First();
            studentsList.Remove(student);
            return RedirectToAction(nameof(Index));
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Studies")] Student student)
        {
            if (ModelState.IsValid)
            {
                int newId = 0;
                foreach (Student s in studentsList)
                {
                    if(s.Id> newId)
                    {
                        newId = s.Id;
                    }
                }
                newId++;
                student.Id = newId;
                studentsList.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(new CreateStudentViewModel { Student = student, AllStudies = new SelectList(Studies.Distinct().ToList()) });
        }
    }
}