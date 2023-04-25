using System.Linq;
using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;

namespace Final_Project_3045.Data
{
    public class StudentInfoContextDAO : IStudentInfoContextDAO
    {
        private StudentInfoContext _context;
        public StudentInfoContextDAO(StudentInfoContext context)
        {
            _context= context;
        }

        public int? Add(StudentInfo student)
        {
            var students = _context.Students.Where(x => x.LastName.Equals(student.LastName)).FirstOrDefault();

            if (students == null)
                return null;

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public List<StudentInfo> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public StudentInfo GetStudentById(int id)
        {
            return _context.Students.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveStudentById(int id)
        {
            var student = this.GetStudentById(id);
            if (student == null) return null;
            try
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return 1;
            }      
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateStudent(StudentInfo student)
        {
            var studentToUpdate = this.GetStudentById(student.Id);

            if (studentToUpdate == null) 
                return null;

            studentToUpdate.FirstName= student.FirstName;
            studentToUpdate.LastName= student.LastName; 
            studentToUpdate.Birthday= student.Birthday; 
            studentToUpdate.CollegeProgram= student.CollegeProgram;
            studentToUpdate.ProgramYear= student.ProgramYear;

            try
            {
            _context.Students.Update(studentToUpdate);
            _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
