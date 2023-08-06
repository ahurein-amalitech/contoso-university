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
            var result = await _http.GetFromJsonAsync<ApiResponse<IEnumerable<Student>>>("/api/student");
            Console.WriteLine(result);
            if (result is not null && result.Data is not null)
            {
                Students = result.Data;
            }
            StudentsChanged.Invoke();
        }

        public async Task<Student?> EditStudent(Student student)
        {
            var result = await _http.PutAsJsonAsync("/api/student/", student);
            var editedStudent = (await result.Content.ReadFromJsonAsync<ApiResponse<Student>>())?.Data;

            return editedStudent;

        }
    }
}