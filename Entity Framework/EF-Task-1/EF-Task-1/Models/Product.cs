﻿namespace EF_Task_1.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int? CategoryId { get; set; }
    
    // Navigation property
    public Category Category { get; set; }
}