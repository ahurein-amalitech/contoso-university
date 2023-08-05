using ContosoUniversity.Server.Core.Repositories;

namespace ContosoUniversity.Server.Core.IConfiguration;

public interface IUnitOfWork
{
    IStudentRepository Students { get; set; }
    Task CommitChangesToDb();
}