namespace WebApp.Models
{
    public static class Repository
    {
        private static List<StudentModel> students = new List<StudentModel>();
        private static int nextId = 1; 

        public static List<StudentModel> Students
        {
            get
            {
                return students;
            }
        }
        public static void AddStudent(StudentModel student)
        {
            student.Id = nextId++; 
            students.Add(student);
        }
        public static StudentModel GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }


        public static void UpdateStudent(StudentModel student)
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
