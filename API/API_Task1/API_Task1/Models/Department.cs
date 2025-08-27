namespace API_Task1.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    //Navigation Property
    public virtual ICollection<Employee> Employees { get; set; }
}