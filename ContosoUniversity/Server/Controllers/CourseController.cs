using AutoMapper;
using ContosoUniversity.Server.Data;
using ContosoUniversity.Server.MappingProfiles.DTOs;
using ContosoUniversity.Server.Services;
using ContosoUniversity.Server.Services.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Course>>>> GetAllCourse()
        {
            return await _courseService.GetAllCourse();
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<ApiResponse<Course>>> GetCourse(int courseId)
        {
            return await _courseService.GetCourse(courseId);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateCourseDto>>> AddCourse(CreateCourseDto createCourseDto)
        {
            return await _courseService.AddCourse(createCourseDto);
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult<ApiResponse<UpdateCourseDto>>> EditCourse(int courseId, [FromBody] UpdateCourseDto course)
        {
            return await _courseService.EditCourse(courseId, course);
        }
        
        [HttpDelete("{courseId}")]
        public async Task<ActionResult<ApiResponse<CourseDto>>> DeleteCourse(int courseId)
        {
            var response = await _courseService.DeleteCourse(courseId);
            return response;
        }


    }
}
