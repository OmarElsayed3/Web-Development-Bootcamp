namespace Task_3.Models;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Navigation property
    public virtual ICollection<StudentCourse> Courses { get; set; }
}