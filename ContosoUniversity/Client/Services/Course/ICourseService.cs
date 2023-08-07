using ContosoUniversity.Shared;

namespace ContosoUniversity.Client.Services
{
    public interface ICourseService
    {
        event Action CoursesChanged;
        IEnumerable<Course> Courses { get; set; }
        Task GetCourses();
        Task<Course> GetCourse(int courseId);
        Task<Course?> EditCourse(int courseId, Course course);
        Task<bool> DeleteCourse(int courseId);
        Task<Course?> CreateCourse(Course course);
    }
}