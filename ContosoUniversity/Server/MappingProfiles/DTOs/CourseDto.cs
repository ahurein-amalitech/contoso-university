namespace ContosoUniversity.Server.MappingProfiles.DTOs;

public class CourseDto
{
    public int CourseID { get; set; }
    public string Title { get; set; }  = string.Empty;
    public int Credits { get; set; }
}

public class CreateCourseDto
{
    public string Title { get; set; }  = string.Empty;
    public int Credits { get; set; }
}

public class UpdateCourseDto
{
    public string Title { get; set; }  = string.Empty;
    public int Credits { get; set; }  
}