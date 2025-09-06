using AuthTask1.Dto.Product;
using AuthTask1.Models;

namespace AuthTask1.Services.Interfaces;

public interface IProductService
{
    Task<Response<ProductDto>> CreateProduct(ProductDto createProduct, string createdBy);
    Task<Response<IEnumerable<ProductDto>>> GetPendingProducts();
    Task<Response<ProductDto>> ApproveProduct(int id);
    Task<Response<ProductDto>> RejectProduct(int id);
    Task<Response<IEnumerable<ProductDto>>> GetApprovedProducts();
    Task<Response<ProductDto>> GetProductById(int id);
}