using Infrastructure.Context;
using Infrastructure.Interfaces;
using WebApp.Models;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public Student CreateStudent(Student student)
        {
            student.Id = 0;
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                existingStudent.WillAttend = student.WillAttend;

                _context.Students.Update(existingStudent);
                _context.SaveChanges();
            }
            return student;
        }

        public int DeleteStudent(int id)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                _context.Students.Remove(existingStudent);
                _context.SaveChanges();
                return existingStudent.Id;
            }
            return -1;

        }

        public Student GetStudentById(int id)
        {
            var std = _context.Students.FirstOrDefault(x => x.Id == id);
            return std;
        }

        public List<Student> GetStudentList()
        {
            var std = _context.Students.ToList();
            return std;
        }

    }
}
