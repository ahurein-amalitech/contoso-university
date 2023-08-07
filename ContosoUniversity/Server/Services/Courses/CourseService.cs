using AutoMapper;
using ContosoUniversity.Server.Core.IConfiguration;
using ContosoUniversity.Server.MappingProfiles.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Services.Courses;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;     
    }
    public async Task<ActionResult<ApiResponse<IEnumerable<Course>>>> GetAllCourse()
    {
        var courses = await _unitOfWork.Courses.GetAll();
        var response = new ApiResponse<IEnumerable<Course>>
        {
            Data = courses,
        };
        return response;
    }

    public async Task<ApiResponse<Course>> GetCourse(int courseId)
    {
        var response = new ApiResponse<Course>();
        var course = await _unitOfWork.Courses.GetById(courseId);
        if (course == null)
        {
            response.Success = false;
            response.Message = "No student exist with the provided Id";
        }
        else
        {
            response.Data = course;
        }

        return response;
    }

    public async Task<ApiResponse<CreateCourseDto>> AddCourse(CreateCourseDto courseDto)
    {
        var response = new ApiResponse<CreateCourseDto>();
        var course = _mapper.Map<Course>(courseDto);
        await _unitOfWork.Courses.Create(course);
        await _unitOfWork.CommitChangesToDb();

        response.Data = courseDto;
        return response;
    }

    public async Task<ApiResponse<UpdateCourseDto>> EditCourse(int courseId, UpdateCourseDto courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);
        bool isUpdated = await _unitOfWork.Courses.Update(courseId, course);
        var response = new ApiResponse<UpdateCourseDto>();
        if (isUpdated)
        {
            Console.WriteLine("update successful");
            await _unitOfWork.CommitChangesToDb();
            response.Data = courseDto;
        }
        else
        {
            response.Success = false;
            response.Message = "update were not successful";
        }
        return response;
    }

    public async Task<ApiResponse<CourseDto>> DeleteCourse(int courseId)
    {
        var course = await _unitOfWork.Courses.GetById(courseId);
        var response = new ApiResponse<CourseDto>();
        if (course is not null)
        {
            _unitOfWork.Courses.Delete(course);
            await _unitOfWork.CommitChangesToDb();
            response.Message = "Student deleted successfully";
            return response;
        }

        response.Message = "Encountered an error deleting the user";
        return response;
    }
}