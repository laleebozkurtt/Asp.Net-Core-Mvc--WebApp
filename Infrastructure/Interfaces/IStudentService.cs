using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using WebApp.Models;

namespace Infrastructure.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetStudentList();
    }
}
