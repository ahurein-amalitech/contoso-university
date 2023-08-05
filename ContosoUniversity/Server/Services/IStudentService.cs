using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Services
{
    public interface IStudentService
    {
        Task<ActionResult<ApiResponse<List<Student>>>> GetStudents();
        Task<ApiResponse<Student>> GetStudent(int studentId);
        Task<ApiResponse<Student>> AddStudent(Student student);

        Task<ApiResponse<Student>> EditStudent(Student student);

    }
}
