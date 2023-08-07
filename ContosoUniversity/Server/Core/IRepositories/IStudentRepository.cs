using ContosoUniversity.Server.Core.IRepositories;
using ContosoUniversity.Server.MappingProfiles.DTOs;

namespace ContosoUniversity.Server.Core.Repositories;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<bool> Update(int id, Student studentDto);
}