namespace API_Task2.Models;

public class Dependent
{
    public int DependentId { get; set; }
    public string Name { get; set; }
    public string Relationship { get; set; }
    public string Gender { get; set; }
    public int EmployeeId { get; set; }
    
    // Navigation property
    public virtual Employee Employee { get; set; }
}