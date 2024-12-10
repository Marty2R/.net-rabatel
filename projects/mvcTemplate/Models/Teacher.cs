using System;

namespace mvc.Models;

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
    public string Subject { get; set; }
    public DateTime HireDate { get; set; }
}
