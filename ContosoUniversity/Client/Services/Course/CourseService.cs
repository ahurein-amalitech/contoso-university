using ContosoUniversity.Shared;
using System.Net.Http.Json;

namespace ContosoUniversity.Client.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _http;

        public event Action CoursesChanged;

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();


        public CourseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Course> GetCourse(int courseId)
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<Course>>($"/api/course/{courseId}");
            return result?.Data;
        }

        public async Task GetCourses()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ApiResponse<IEnumerable<Course>>>("/api/course");
                if (result is not null && result.Data is not null)
                {
                    Courses = result.Data;
                }
                CoursesChanged.Invoke();
            }
            catch (Exception ex)
            {}
        }

        public async Task<Course?> EditCourse(int courseId, Course course)
        {
            var result = await _http.PutAsJsonAsync($"/api/course/{courseId}", course);
            var editedCourse = (await result.Content.ReadFromJsonAsync<ApiResponse<Course>>())?.Data;
            return editedCourse;

        }

        public async Task<Course?> CreateCourse(Course course)
        {
            var response = await _http.PostAsJsonAsync("/api/course", course);
            var result = (await response.Content.ReadFromJsonAsync<ApiResponse<Course>>());
            return result.Data;
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            var result = await _http.DeleteAsync($"/api/course/{courseId}");
            return ((await result.Content.ReadFromJsonAsync<ApiResponse<Course>>())!).Success;
        }
    }
}