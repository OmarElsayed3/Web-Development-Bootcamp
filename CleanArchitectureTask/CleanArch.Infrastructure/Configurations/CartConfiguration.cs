using CleanArch.Domain.Models.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.UserId)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("getdate()");

        builder
            .Property(x => x.UpdatedAt)
            .HasDefaultValueSql("getdate()");
        

        builder
            .HasQueryFilter(c => !c.IsDeleted);
    }
}