using CleanArch.Domain.Models.Base;
using CleanArch.Domain.Models.CartItems;

namespace CleanArch.Domain.Models.Carts;

public class Cart :  Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Guid UserId { get; set; }
    
    // Navigation property
    public virtual ICollection<CartItem> CartItems { get; set; }
}