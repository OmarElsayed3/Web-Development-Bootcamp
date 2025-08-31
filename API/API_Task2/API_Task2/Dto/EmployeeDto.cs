namespace API_Task2.Dto;

public class EmployeeDto
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public IFormFile? Image { get; set; }
    public int? DepartmentId { get; set; }
    
}