using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
 
    public class StudentController : Controller
    {
        private AppDbContext _context;
        private IStudentService _service;

        public StudentController(AppDbContext context)
        {
            _context = context;
            _service = new StudentService(context);
        }

        [HttpGet]
        public ViewResult List()
        {
            //var liste = Repository.Students;
            var dblist = _service.GetStudentList();

            var modelList = new List<StudentModel>();

            foreach (var item in dblist)
            {
                var model = new StudentModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Email = item.Email;
                model.Phone = item.Phone;
                model.WillAttend = item.WillAttend;

                modelList.Add(model);
            }


            return View(modelList);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            //var student = Repository.GetStudentById(id);
            var student = _service.GetStudentById(id);

            if (id == 0)
                return View(new StudentModel()); // ilk olarak model boş

            if (student == null)
                return NotFound();

            var studentModel = new StudentModel();
            studentModel.Id = student.Id;
            studentModel.Name = student.Name;
            studentModel.Email = student.Email;
            studentModel.Phone = student.Phone;
            studentModel.WillAttend = student.WillAttend;

            return View(studentModel);
        }

        [HttpPost]
        public IActionResult SaveDetail(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                if (studentModel.Id == 0)
                {
                    var student = new Student();
                    student.Name = studentModel.Name;
                    student.Email = studentModel.Email;
                    student.Phone = studentModel.Phone;
                    student.WillAttend = studentModel.WillAttend;
                    student.Surname = "Bozkurt";
                    student.RegisterDate = DateTime.Now;
                    student.BirthDate = DateTime.Now.AddYears(-5);
                    _service.CreateStudent(student);

                }
                else
                {
                    var student = _service.GetStudentById(studentModel.Id);
                    if (student != null)
                    {
                        student.Name = studentModel.Name;
                        student.Email = studentModel.Email;
                        student.Phone = studentModel.Phone;
                        student.WillAttend = studentModel.WillAttend;

                        _service.UpdateStudent(student);
                    }
                }
                //if (student.Id == 0)
                //    Repository.AddStudent(student);
                //else
                //    Repository.UpdateStudent(student);

                return RedirectToAction("List");
            }

            return View(studentModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //var student = Repository.GetStudentById(id);
            var student = _service.GetStudentById(id);
            if (student != null)
            {
                _service.DeleteStudent(id);
                //Repository.Students.Remove(student);
            }
            return RedirectToAction("List");
        }

    }
}
