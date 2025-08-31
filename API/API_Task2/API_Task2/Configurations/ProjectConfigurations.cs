using API_Task2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Task2.Configurations;

public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasMany(p => p.WorksOns)
            .WithOne(wo => wo.Project)
            .HasForeignKey(wo => wo.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}