namespace API_Task2.Models;

public class WorksOn
{
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    
    // Navigation properties
    public virtual Employee Employee { get; set; }
    public virtual Project Project { get; set; }
}