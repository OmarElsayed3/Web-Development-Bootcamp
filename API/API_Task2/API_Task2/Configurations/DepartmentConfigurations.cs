using API_Task2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Task2.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasOne(d => d.Manager)
            .WithOne(e => e.DeptManager)
            .HasForeignKey<Department>(d => d.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}