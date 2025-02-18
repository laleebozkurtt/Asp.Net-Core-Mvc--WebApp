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
                return View(new StudentModel()); // ilk olarak model boş

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult SaveDetail(StudentModel student)
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
