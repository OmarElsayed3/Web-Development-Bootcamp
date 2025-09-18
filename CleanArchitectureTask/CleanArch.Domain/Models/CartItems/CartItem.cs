using CleanArch.Domain.Models.Base;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Models.Products;

namespace CleanArch.Domain.Models.CartItems;

public class CartItem : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    // Navigation properties
    public virtual Cart? Cart { get; set; }
    public virtual Product? Product { get; set; }
}