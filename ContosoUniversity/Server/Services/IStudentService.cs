using ContosoUniversity.Server.MappingProfiles.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Services
{
    public interface IStudentService
    {
        Task<ActionResult<ApiResponse<IEnumerable<Student>>>> GetAllStudent();
        Task<ApiResponse<Student>> GetStudent(int studentId);
        Task<ApiResponse<CreateStudentDto>> AddStudent(CreateStudentDto student);

        Task<ApiResponse<Student>> EditStudent(Student student);

    }
}
