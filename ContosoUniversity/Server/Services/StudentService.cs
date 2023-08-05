using ContosoUniversity.Server.Core.Repositories;
using ContosoUniversity.Server.Data;
using ContosoUniversity.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Server.Services
{
    public class StudentService : IStudentService
    {
        private readonly SchoolContext _context;
        private readonly IStudentRepository _studentRepository;

        public StudentService(SchoolContext context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }

        public async Task<ActionResult<ApiResponse<List<Student>>>> GetStudents()
        {   
            var students = await _context.Students.ToListAsync();
            var response = new ApiResponse<List<Student>>
            {
                Data = students,
            };
            return response;
        }

        public async Task<ApiResponse<Student>> GetStudent(int studentId)
        {
            var response = new ApiResponse<Student>();
            var student =  await _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(s => s.ID == studentId);
            if(student == null) { 
                response.Success = false;
                response.Message = "No student exist with the provided Id";
            }else
            {
                response.Data = student;
            }
            return response;
        }

        public async Task<ApiResponse<Student>> AddStudent(Student Student)
        {
            var response = new ApiResponse<Student>();
            await _context.Students.AddAsync(Student);
            _context.SaveChanges();
            response.Data = Student;
            return response;
        }

        public async Task<ApiResponse<Student>> EditStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
