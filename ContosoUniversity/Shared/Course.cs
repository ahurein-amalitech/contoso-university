using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContosoUniversity.Shared
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }  = string.Empty;
        public int Credits { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
