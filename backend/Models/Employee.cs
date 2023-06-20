using System.ComponentModel.DataAnnotations;
namespace AlcottBackend.Models;


public class Employee
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    [Required]
    public int Role { get; set; } = 1; // 0 for admin 1 for regular employee
    [Required]
    public string? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}