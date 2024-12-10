using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATH, OTHER
}

public class Student
{
    // variables d'instance
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public int Age { get; set; }
    public double GPA { get; set; }
    public Major Major { get; set; }
    public DateTime AdmissionDate { get; set; }
}