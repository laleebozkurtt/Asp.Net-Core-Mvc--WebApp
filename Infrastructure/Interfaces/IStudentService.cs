using WebApp.Models;

namespace Infrastructure.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(Student student);
        Student UpdateStudent(Student student);
        int DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetStudentList();
    }
}
