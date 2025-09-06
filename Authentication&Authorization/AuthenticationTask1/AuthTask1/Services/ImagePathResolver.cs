using AuthTask1.Dto.Product;
using AuthTask1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AuthTask1.Services;

public class ImagePathResolver : IValueResolver<ProductDto, Product, string>
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ImagePathResolver(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public string Resolve(ProductDto source, Product destination, string destMember, ResolutionContext context)
    {
        if (source.Image == null)
            return destMember;
        var webRootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var uploadsFolder = Path.Combine(webRootPath, "images", "products");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + source.Image.FileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            source.Image.CopyTo(fileStream);
        }
        return "/images/products/" + uniqueFileName;
    }
}