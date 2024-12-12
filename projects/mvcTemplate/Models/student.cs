using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATH, OTHER
}

public class Student : IdentityUser
{
    // variables d'instance
    //public string Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }
    public Major Major { get; set; }
    public DateTime AdmissionDate { get; set; }

}