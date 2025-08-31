namespace API_Task2.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int? DepartmentId { get; set; }
    
    // Navigation properties
    public virtual ICollection<WorksOn> WorksOns { get; set; }
}