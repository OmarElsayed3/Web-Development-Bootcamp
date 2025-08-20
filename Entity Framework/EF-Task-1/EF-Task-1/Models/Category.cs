namespace EF_Task_1.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation property
    public ICollection<Product> Products { get; set; } = new List<Product>();
}