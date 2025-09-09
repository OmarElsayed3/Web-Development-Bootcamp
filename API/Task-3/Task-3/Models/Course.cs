namespace Task_3.Models;

public class Course : BaseEntity
{
    public string Name { get; set; }
    public int Hours { get; set; }
    
    // Navigation property
    public virtual ICollection<StudentCourse> Students { get; set; }
}