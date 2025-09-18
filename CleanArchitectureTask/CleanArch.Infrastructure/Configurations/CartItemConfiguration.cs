using CleanArch.Domain.Models.CartItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder
            .Property(ci => ci.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder
            .Property(ci => ci.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("getdate()");

        builder
            .Property(x => x.UpdatedAt)
            .HasDefaultValueSql("getdate()");

        builder
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ci => ci.Product)
            .WithMany(cat => cat.CartItems) 
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}