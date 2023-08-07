using ContosoUniversity.Server.Core.IRepositories;
using ContosoUniversity.Server.Core.Repositories;

namespace ContosoUniversity.Server.Core.IConfiguration;

public interface IUnitOfWork
{
    IStudentRepository Students { get; set; }
    ICourseRepository Courses { get; set; }
    Task CommitChangesToDb();
}