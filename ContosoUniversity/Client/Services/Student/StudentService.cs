using ContosoUniversity.Shared;
using System.Net.Http.Json;

namespace ContosoUniversity.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _http;

        public event Action StudentsChanged;

        public IEnumerable<Student> Students { get; set; } = new List<Student>();


        public StudentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<Student>>($"/api/student/{studentId}");
            return result?.Data;
        }

        public async Task GetStudents()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ApiResponse<IEnumerable<Student>>>("/api/student");
                if (result is not null && result.Data is not null)
                {
                    Students = result.Data;
                }
                StudentsChanged.Invoke();
            }
            catch (Exception ex)
            {}
        }

        public async Task<Student?> EditStudent(int studentId, Student student)
        {
            var result = await _http.PutAsJsonAsync($"/api/student/{studentId}", student);
            var editedStudent = (await result.Content.ReadFromJsonAsync<ApiResponse<Student>>())?.Data;

            return editedStudent;

        }

        public async Task<Student?> CreateStudent(Student student)
        {
            var response = await _http.PostAsJsonAsync("/api/student", student);
            var result = (await response.Content.ReadFromJsonAsync<ApiResponse<Student>>());
            Console.WriteLine(result);
            return result.Data;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var result = await _http.DeleteAsync($"/api/Student/{studentId}");
            return ((await result.Content.ReadFromJsonAsync<ApiResponse<Student>>())!).Success;
        }
    }
}