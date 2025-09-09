namespace Task_3.Models;

public class StudentCourse : BaseEntity
{
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

    public int CourseId { get; set; }
    public virtual Course Course { get; set; }
}