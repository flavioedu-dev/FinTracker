using System.ComponentModel.DataAnnotations;

namespace FinTracker.Domain.DTO;

public class UserDTO
{
    public string? Username { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}