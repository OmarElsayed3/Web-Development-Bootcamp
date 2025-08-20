using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

var cs = "Server=OMAR;Database=Dapper_Task_1;Trusted_Connection=True;TrustServerCertificate=True;";

await using var conn = new SqlConnection(cs);
await conn.OpenAsync();


#region insert a new Category
    var categoryParams = new DynamicParameters();
    categoryParams.Add("@Name", "Beverages");
    await conn.ExecuteAsync("usp_InsertCategory", categoryParams, commandType: CommandType.StoredProcedure);
#endregion

#region insert a new product
    var spParams = new DynamicParameters();
    spParams.Add("@Name", "Tea");
    spParams.Add("@Price", 99.99m);
    spParams.Add("@CategoryId", 1);

    await conn.ExecuteAsync("usp_InsertProduct", spParams, commandType: CommandType.StoredProcedure);

#endregion

#region Update Product

    // var updateParams = new DynamicParameters();
    // updateParams.Add("@Id", 1);
    // updateParams.Add("@Name", "Green Tea");
    // updateParams.Add("@Price", 89.99m);
    // updateParams.Add("@CategoryId", 1);
    // await conn.ExecuteAsync("usp_UpdateProduct", updateParams, commandType: CommandType.StoredProcedure);


#endregion

#region Update Category
    // var updateCategoryParams = new DynamicParameters();
    // updateCategoryParams.Add("@Id", 1);
    // updateCategoryParams.Add("@Name", "Hot Beverages");
    // await conn.ExecuteAsync("usp_UpdateCategory", updateCategoryParams, commandType: CommandType.StoredProcedure); 
#endregion

#region Delete Product
    // var deleteParams = new DynamicParameters();
    // deleteParams.Add("@ProductId", 1);
    // await conn.ExecuteAsync("usp_DeleteProduct", deleteParams, commandType: CommandType.StoredProcedure);
#endregion

#region Delete Category
    // var deleteCategoryParams = new DynamicParameters();
    // deleteCategoryParams.Add("@CategoryId", 1);
    // await conn.ExecuteAsync("usp_DeleteCategory", deleteCategoryParams, commandType: CommandType.StoredProcedure);
#endregion

#region retrieve all categories using the correct view
    var categories = await conn.QueryAsync<Category>("SELECT * FROM vw_Categories");
    foreach (var category in categories)
    {
        Console.WriteLine($"Category ID: {category.Id}, Name: {category.Name}");
    }
#endregion

#region retrieve all products using the correct view
    var products = await conn.QueryAsync<Product>("SELECT * FROM vw_Products");
    foreach (var product in products)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.ProductPrice}, Category Name: {product.CategoryName}");
    }
#endregion

#region find a product by Name

    var productName = "Tea";
    var productByName = await conn.QueryFirstOrDefaultAsync<Product>(
        "SELECT * FROM dbo.fn_GetProductByName(@Name)",
        new { Name = productName });
    if (productByName != null)
    {
        Console.WriteLine($"Found Product: ID: {productByName.ProductId}, Name: {productByName.ProductName}, Price: {productByName.ProductPrice}, Category Name: {productByName.CategoryName}");
    }  
#endregion

#region find a category by Name
    var categoryName = "Beverages";
    var categoryByName = await conn.QueryFirstOrDefaultAsync<Category>(
        "SELECT * FROM dbo.ufn_GetCategoryByName(@Name)",
        new { Name = categoryName });
    if (categoryByName != null)
    {
        Console.WriteLine($"Found Category: ID: {categoryByName.Id}, Name: {categoryByName.Name}");
    }  
#endregion

#region Models
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
    }
#endregion
