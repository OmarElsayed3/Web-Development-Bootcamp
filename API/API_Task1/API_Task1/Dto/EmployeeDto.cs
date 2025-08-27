namespace API_Task1.Models;

public class EmployeeDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }
}