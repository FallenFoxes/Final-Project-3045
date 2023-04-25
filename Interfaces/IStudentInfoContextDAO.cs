using Final_Project_3045.Model;

namespace Final_Project_3045.Interfaces
{
    public interface IStudentInfoContextDAO
    {
       List<StudentInfo> GetAllStudents();
       StudentInfo GetStudentById(int studentId);
       int? RemoveStudentById(int id);
       int? UpdateStudent(StudentInfo student);
       int? Add(StudentInfo student);
            
    }
}
