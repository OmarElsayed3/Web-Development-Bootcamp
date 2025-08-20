using EF_Task_1.Data;
using EF_Task_1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Task_1;

public class Actions
{
    public void InsertCategory(ApplicationDbContext db, string categoryName)
    {
        var category = new Category { Name = categoryName };
        db.Categories.Add(category);
        db.SaveChanges();
        Console.WriteLine("Category inserted successfully.");
    }

    public void InsertProduct(ApplicationDbContext db, string productName, decimal price, int categoryId)
    {
        var product = new Product { Name = productName, Price = price, CategoryId = categoryId };
        db.Products.Add(product);
        db.SaveChanges();
        Console.WriteLine("Product inserted successfully.");
    }

    public void UpdateProduct(ApplicationDbContext db, int productId, string newName, decimal newPrice)
    {
        var existingProduct = db.Products.FirstOrDefault(p => p.Id == productId);
        if (existingProduct != null)
        {
            existingProduct.Name = newName;
            existingProduct.Price = newPrice;
            db.Products.Update(existingProduct);
            db.SaveChanges();
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void DeleteProduct(ApplicationDbContext db, int productId)
    {
        var productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);
        if (productToDelete != null)
        {
            db.Products.Remove(productToDelete);
            db.SaveChanges();
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteCategory(ApplicationDbContext db, string categoryName)
    {
        var categoryToDelete = db.Categories.FirstOrDefault(c => c.Name == categoryName);
        if (categoryToDelete != null)
        {
            db.Categories.Remove(categoryToDelete);
            db.SaveChanges();
            Console.WriteLine("Category deleted successfully.");
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }
    public void FindProduct(ApplicationDbContext db, string productName)
    {
        var findP = db.Products
            .Where(p => p.Name == productName)
            .Select(p => new
            {
                ProductId = p.Id,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryName = p.Category.Name
            })
            .ToList();
        
        foreach (var item in findP)
        {
            Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Price: {item.ProductPrice}, Category: {item.CategoryName}");
        }
    }

    public void FindCategory(ApplicationDbContext db, string categoryName)
    {
        var findC = db.Categories
            .Where(c => c.Name == categoryName)
            .Select(c => new
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                ProductCount = c.Products.Count
            })
            .ToList();
        
        foreach (var item in findC)
        {
            Console.WriteLine($"Category ID: {item.CategoryId}, Name: {item.CategoryName}, Product Count: {item.ProductCount}");
        }
    }
    public void DisplayAllProducts(ApplicationDbContext db)
    {
        var products = db.Products.Include(p => p.Category).ToList();
        Console.WriteLine("All Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category?.Name}");
        }
    }
    public void DisplayAllCategories(ApplicationDbContext db)
    {
        var categories = db.Categories.Include(c => c.Products).ToList();
        Console.WriteLine("All Categories:");
        foreach (var category in categories)
        {
            Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            foreach (var product in category.Products)
            {
                Console.WriteLine($"  Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
    }
}