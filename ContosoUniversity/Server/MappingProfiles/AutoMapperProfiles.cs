using AutoMapper;
using ContosoUniversity.Server.MappingProfiles.DTOs;

namespace ContosoUniversity.Server.MappingProfiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CreateCourseDto, Course>().ReverseMap();
        CreateMap<CourseDto, Course>().ReverseMap();
        
        CreateMap<CreateStudentDto, Student>().ReverseMap();
        CreateMap<StudentDto, Student>();
        CreateMap<Student, StudentDto>();
    }
}