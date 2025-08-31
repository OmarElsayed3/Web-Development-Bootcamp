namespace API_Task2.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int? ManagerId { get; set; }
    public DateTime Since { get; set; }
    
    // Navigation properties
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual Employee Manager { get; set; }
}