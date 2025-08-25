namespace API_Task1.Models;

public class Login
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int EmployeeId { get; set; }
    
    //Navigation Property
    public Employee Employee { get; set; }
}