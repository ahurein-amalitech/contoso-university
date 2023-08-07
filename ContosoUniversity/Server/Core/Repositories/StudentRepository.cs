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
    
    public async Task<bool> Update(int id, Student studentDto)
    {
        var entityExist = await _dbset.FindAsync(id);
        if (entityExist is not null )
        {
            entityExist.FirstMidName = studentDto.FirstMidName;
            entityExist.LastName = studentDto.LastName;
            entityExist.EnrollmentDate = entityExist.EnrollmentDate;
            return true;
        }
        Console.WriteLine("DTO does not exist");       
        return false;
    }
    
} 