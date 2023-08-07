using AutoMapper;
using ContosoUniversity.Server.Data;
using ContosoUniversity.Server.MappingProfiles.DTOs;
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
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Student>>>> GetAllStudent()
        {
            return await _studentService.GetAllStudent();
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<ApiResponse<Student>>> GetStudent(int studentId)
        {
            return await _studentService.GetStudent(studentId);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateStudentDto>>> AddStudent(CreateStudentDto createStudentDto)
        {
            return await _studentService.AddStudent(createStudentDto);
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult<ApiResponse<EditStudentDto>>> EditStudent(int studentId, [FromBody] EditStudentDto student)
        {
            return await _studentService.EditStudent(studentId, student);
        }
        
        [HttpDelete("{studentId}")]
        public async Task<ActionResult<ApiResponse<StudentDto>>> DeleteStudent(int studentId)
        {
            var response = await _studentService.DeleteStudent(studentId);
            Console.WriteLine(response);
            return response;
        }


    }
}
