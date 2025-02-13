using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ViewResult List()
        {
            var liste = Repository.Students;
            return View(liste);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var student = Repository.GetStudentById(id);

            if (id == 0)
                return View(new Student()); // ilk olarak model boş

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult SaveDetail(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Id == 0)
                    Repository.AddStudent(student);
                else
                    Repository.UpdateStudent(student);

                return RedirectToAction("List");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Validator(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            return View("Success");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = Repository.GetStudentById(id);
            if (student != null)
            {
                Repository.Students.Remove(student);
            }
            return RedirectToAction("List");
        }

    }
}
