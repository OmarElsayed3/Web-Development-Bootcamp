using API_Task2.Dto;
using API_Task2.Models;
using AutoMapper;

namespace API_Task2.Services;

public class ImagePathResolver : IValueResolver<EmployeeDto, Employee, string>
{
    public string Resolve( EmployeeDto source, Employee destination, string destMember, ResolutionContext context)
    {
        if (source.Image == null) 
            return destMember;
        var fileName = Guid.NewGuid() + Path.GetExtension(source.Image.FileName);
        var filePath = Path.Combine("wwwroot/employee", fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        source.Image.CopyTo(stream);
        
        return $"/employee/{fileName}";
    }
}