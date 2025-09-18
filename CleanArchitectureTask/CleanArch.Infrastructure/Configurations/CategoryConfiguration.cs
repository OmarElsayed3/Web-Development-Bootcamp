using CleanArch.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(CategoryConstants.CategoryNameMaxLengthValue);
                        
            builder
                .Property(x=>x.CreatedAt)
                .HasDefaultValueSql("getdate()");
            
            builder
                .Property(x=>x.UpdatedAt)
                .HasDefaultValueSql("getdate()");
            
        }
    }
}