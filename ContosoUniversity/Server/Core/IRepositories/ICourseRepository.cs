namespace ContosoUniversity.Server.Core.IRepositories;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<bool> Update(int id, Course course);
}