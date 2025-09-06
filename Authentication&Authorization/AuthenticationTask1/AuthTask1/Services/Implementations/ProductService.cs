using AuthTask1.Dto.Product;
using AuthTask1.Models;
using AuthTask1.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace AuthTask1.Services.Implementations;

public class ProductService(IGenericRepository<Product> productRepository, IMapper mapper) : IProductService
{
    public async Task<Response<ProductDto>> CreateProduct(ProductDto createProduct, string createdBy)
    {
        try
        {
            var product = mapper.Map<Product>(createProduct);
            product.CreatedBy = createdBy;
            product.IsApproved = false;
            productRepository.Add(product);
            await productRepository.SaveChangesAsync();
            var productDto = mapper.Map<ProductDto>(product);
            return new Response<ProductDto>
            {
                Status = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Product created successfully",
                Data = productDto
            };
        }
        catch (Exception ex)
        {
            return new Response<ProductDto>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }

    public async Task<Response<IEnumerable<ProductDto>>> GetPendingProducts()
    {
        try
        {
            var products = productRepository.GetAll().Where(p => !p.IsApproved);
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);
            return new Response<IEnumerable<ProductDto>>
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Pending products retrieved successfully",
                Data = productDtos
            };
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<ProductDto>>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }

    public async Task<Response<ProductDto>> ApproveProduct(int id)
    {
        try
        {
            var product = productRepository.GetById(id);
            if (product == null)
            {
                return new Response<ProductDto>
                {
                    Status = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Product not found"
                };
            }

            product.IsApproved = true;
            productRepository.Update(product);
            await productRepository.SaveChangesAsync();
            var productDto = mapper.Map<ProductDto>(product);
            return new Response<ProductDto>
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Product approved successfully",
                Data = productDto
            };
        }
        catch (Exception ex)
        {
            return new Response<ProductDto>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }

    public async Task<Response<ProductDto>> RejectProduct(int id)
    {
        try
        {
            var product = productRepository.GetById(id);
            if (product == null)
            {
                return new Response<ProductDto>
                {
                    Status = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Product not found"
                };
            }

            product.IsApproved = false;
            productRepository.Update(product);
            var productDto = mapper.Map<ProductDto>(product);
            return new Response<ProductDto>
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Product rejected successfully",
                Data = productDto
            };
        }
        catch (Exception ex)
        {
            return new Response<ProductDto>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }

    public async Task<Response<IEnumerable<ProductDto>>> GetApprovedProducts()
    {
        try
        {
            var products = productRepository.GetAll().Where(p => p.IsApproved);
            var productDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return new Response<IEnumerable<ProductDto>>
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Approved products retrieved successfully",
                Data = productDto
            };
        }
        catch (Exception ex)
        {
            return new Response<IEnumerable<ProductDto>>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }

    public async Task<Response<ProductDto>> GetProductById(int id)
    {
        try
        {
            var product = productRepository.GetById(id);
            if (product == null || !product.IsApproved)
            {
                return new Response<ProductDto>
                {
                    Status = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Product not found"
                };
            }

            var productDto = mapper.Map<ProductDto>(product);
            return new Response<ProductDto>
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Product retrieved successfully",
                Data = productDto
            };
        }
        catch (Exception ex)
        {
            return new Response<ProductDto>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
        }
    }
}