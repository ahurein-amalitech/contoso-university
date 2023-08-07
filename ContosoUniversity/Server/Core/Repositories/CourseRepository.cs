using ContosoUniversity.Server.Core.IRepositories;
using ContosoUniversity.Server.Data;

namespace ContosoUniversity.Server.Core.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(SchoolContext context) : base(context)
    {
    }
    
    public async Task<bool> Update(int id, Course course)
    {
        var entityExist = await _dbset.FindAsync(id);
        if (entityExist is not null )
        {
            entityExist.Title = course.Title;
            entityExist.Credits = course.Credits;
            return true;
        }
        return false;
    }
}