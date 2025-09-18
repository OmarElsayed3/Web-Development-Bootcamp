using CleanArch.Domain.Models.Base;
using CleanArch.Domain.Models.Products;

namespace CleanArch.Domain.Models.Categories;

public class Category : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    // Navigation property
    public virtual ICollection<Product> Products { get; set; }
}