using EF_Task_1;
using EF_Task_1.Data;
using EF_Task_1.Models;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new ApplicationDbContext();
        Actions actions = new ();
        actions.InsertCategory(db, "Beverages");
        actions.InsertProduct(db, "Tea", 1.50m, 1);
        actions.UpdateProduct(db, 1, "Coca Cola Zero", 1.75m);
        // actions.DeleteProduct(db, 2);
        //actions.DeleteCategory(db, "Beverages");
        //actions.FindProduct(db, "Tea");
        //actions.DisplayAllProducts(db);   
    }
}