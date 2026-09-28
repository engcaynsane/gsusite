using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models;
public class Student
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [StringLength(80)]
    public string? Faculty { get; set; }
}