namespace AuthTask1.Models;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; }
    
    public virtual ICollection<CartItem> CartItems { get; set; }
    public virtual User User { get; set; }
}