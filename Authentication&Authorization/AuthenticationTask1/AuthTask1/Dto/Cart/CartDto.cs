namespace AuthTask1.Dto.Cart;

public class CartDto
{
    public string UserId { get; set; }
    public string UName { get; set; }
    public List<CartItemDto> CartItems { get; set; }
    
}
