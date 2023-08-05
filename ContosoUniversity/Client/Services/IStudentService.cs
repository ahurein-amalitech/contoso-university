using ContosoUniversity.Shared;

namespace ContosoUniversity.Client.Services
{
    public interface IStudentService
    {
        event Action StudentsChanged;
        List<Student> Students { get; set; }
        Task GetStudents();
        Task<Student> GetStudent(int studentId);
        Task<Student?> EditStudent(Student Student);
    }
}