namespace WebApp.Models
{
    public static class Repository
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1; 

        public static List<Student> Students
        {
            get
            {
                return students;
            }
        }
        public static void AddStudent(Student student)
        {
            student.Id = nextId++; 
            students.Add(student);
        }
        public static Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }


        public static void UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                existingStudent.WillAttend = student.WillAttend;
            }
        }

    }
}
