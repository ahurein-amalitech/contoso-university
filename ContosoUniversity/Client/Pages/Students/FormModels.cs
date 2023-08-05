using ContosoUniversity.Shared;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Client.Pages.Students
{
    public class StudentModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Invalid name length")]
        public string LastName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Invalid name length")]
        public string FirstMidName { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
