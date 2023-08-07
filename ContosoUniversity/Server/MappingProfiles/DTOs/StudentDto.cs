namespace ContosoUniversity.Server.MappingProfiles.DTOs;

public class StudentDto
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; }
}
public class CreateStudentDto
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

public class EditStudentDto
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }    
}