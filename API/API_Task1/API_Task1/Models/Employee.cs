﻿namespace API_Task1.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }

    //Navigation Property
    public Department Department { get; set; }
    public Role Role { get; set; }
    public Login Login { get; set; }
}