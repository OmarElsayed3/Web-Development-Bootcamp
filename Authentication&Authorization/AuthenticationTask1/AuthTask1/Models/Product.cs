
namespace AuthTask1.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ProductImageUrl { get; set; }
    public string CreatedBy { get; set; }
    public bool IsApproved { get; set; } = false;
    
    public virtual ICollection<CartItem> CartItems { get; set; }
}