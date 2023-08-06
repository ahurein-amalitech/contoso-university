using AutoMapper;
using ContosoUniversity.Server.Core.IConfiguration;
using ContosoUniversity.Server.MappingProfiles.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Server.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ActionResult<ApiResponse<IEnumerable<Student>>>> GetAllStudent()
    {
        var students = await _unitOfWork.Students.GetAll();
        var response = new ApiResponse<IEnumerable<Student>>
        {
            Data = students,
        };
        return response;
    }

    public async Task<ApiResponse<Student>> GetStudent(int studentId)
    {
        var response = new ApiResponse<Student>();
        var student = await _unitOfWork.Students.GetById(studentId);
        if (student == null)
        {
            response.Success = false;
            response.Message = "No student exist with the provided Id";
        }
        else
        {
            response.Data = student;
        }

        return response;
    }
    
    public async Task<ApiResponse<CreateStudentDto>> AddStudent(CreateStudentDto createStudentDto)
    {
        var response = new ApiResponse<CreateStudentDto>();
        var student = _mapper.Map<Student>(createStudentDto);
        await _unitOfWork.Students.Create(student);
        await _unitOfWork.CommitChangesToDb();

        response.Data = createStudentDto;
        return response;
    }

    public async Task<ApiResponse<Student>> EditStudent(Student student)
    {
        throw new NotImplementedException();
    }
}