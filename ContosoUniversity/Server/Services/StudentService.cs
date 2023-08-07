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

    public async Task<ApiResponse<EditStudentDto>> EditStudent(int studentId, EditStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        bool isUpdated = await _unitOfWork.Students.Update(studentId, student);
        var response = new ApiResponse<EditStudentDto>();
        if (isUpdated)
        {
            Console.WriteLine("update successful");
            await _unitOfWork.CommitChangesToDb();
            response.Data = studentDto;
        }
        else
        {
            response.Success = false;
            response.Message = "update were not successful";
        }
        return response;
    }

    public async Task<ApiResponse<StudentDto>> DeleteStudent(int studentId)
    {
        var student = await _unitOfWork.Students.GetById(studentId);
        var response = new ApiResponse<StudentDto>();
        if (student is not null)
        {
             _unitOfWork.Students.Delete(student);
            await _unitOfWork.CommitChangesToDb();
            response.Message = "Student deleted successfully";
            return response;
        }

        response.Message = "Encountered an error deleting the user";
        return response;
    }
}