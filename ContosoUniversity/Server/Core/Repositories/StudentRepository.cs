using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Server.Data;
using ContosoUniversity.Server.MappingProfiles.DTOs;

namespace ContosoUniversity.Server.Core.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(SchoolContext context) : base(context)
    {
    }
    public override async Task<Student?> GetById(int studentId)
    {
        return  await _dbset.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(s => s.ID == studentId);
    }
} 