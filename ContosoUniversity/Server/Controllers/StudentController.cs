using ContosoUniversity.Server.Data;
using ContosoUniversity.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Student>>>> GetAllStudents()
        {
            return await _studentService.GetStudents();
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<ApiResponse<Student>>> GetStudent(int studentId)
        {
            return await _studentService.GetStudent(studentId);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Student>>> AddStudent(Student Student)
        {
            return await _studentService.AddStudent(Student);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<Student>>> EditStudent(Student Student)
        {
            return await _studentService.EditStudent(Student);
        }

    }
}
