namespace API_Task2.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string? ImagePath { get; set; }
    public int? DepartmentId { get; set; }
    
    
    // Navigation properties
    public virtual ICollection<WorksOn> WorksOns { get; set; }
    public virtual Department Department { get; set; }
    
    public virtual Department DeptManager { get; set; }
    
    public virtual ICollection<Dependent> Dependents { get; set; }
    
}