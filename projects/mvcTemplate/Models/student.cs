namespace mvc.Models;

public enum Major
{
    CS, IT, MATH, OTHER
}

public class Student
{
    // variables d'instance
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }
    public Major Major { get; set; }
    public DateTime AdmissionDate { get; set; }
}