using ContosoUniversity.Server.MappingProfiles.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace ContosoUniversity.Server.Services.Courses;

public interface ICourseService
{
    Task<ActionResult<ApiResponse<IEnumerable<Course>>>> GetAllCourse();
    Task<ApiResponse<Course>> GetCourse(int courseId);
    Task<ApiResponse<CreateCourseDto>> AddCourse(CreateCourseDto course);
    Task<ApiResponse<UpdateCourseDto>> EditCourse(int courseId, UpdateCourseDto courseDto);
    Task<ApiResponse<CourseDto>> DeleteCourse(int courseId);
}
