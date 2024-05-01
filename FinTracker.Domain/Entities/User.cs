using System.ComponentModel.DataAnnotations;

namespace FinTracker.Domain.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    public string? FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public ICollection<Finance>? Finances { get; set; }
}