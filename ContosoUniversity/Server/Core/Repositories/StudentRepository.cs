using ContosoUniversity.Server.Data;

namespace ContosoUniversity.Server.Core.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(SchoolContext context) : base(context)
    {
    }
} 