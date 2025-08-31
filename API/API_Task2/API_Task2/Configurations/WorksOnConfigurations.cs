using API_Task2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Task2.Configurations;

public class WorksOnConfigurations : IEntityTypeConfiguration<WorksOn>
{
    public void Configure(EntityTypeBuilder<WorksOn> builder)
    {
        builder.HasKey(wo => new { wo.EmployeeId, wo.ProjectId });
        
        builder.HasOne(wo => wo.Employee)
            .WithMany(e => e.WorksOns)
            .HasForeignKey(wo => wo.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(wo => wo.Project)
            .WithMany(p => p.WorksOns)
            .HasForeignKey(wo => wo.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}