using AuthTask1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthTask1.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasMany(c => c.CartItems)
               .WithOne(ci => ci.Cart)
               .HasForeignKey(ci => ci.CartId)
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.User)
               .WithOne(u => u.Cart)
               .HasForeignKey<Cart>(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}