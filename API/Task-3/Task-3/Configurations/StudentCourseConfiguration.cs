namespace Task_3.Configurations;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder.HasOne(sc => sc.Student)
               .WithMany(s => s.Courses)
               .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Course)
               .WithMany(c => c.Students)
               .HasForeignKey(sc => sc.CourseId);
    }
}