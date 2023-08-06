namespace ContosoUniversity.Server.MappingProfiles.DTOs;


public class EnrollmentDto
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }
    public Course Course { get; set; }
}

public class createEnrollmentDto
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }
}