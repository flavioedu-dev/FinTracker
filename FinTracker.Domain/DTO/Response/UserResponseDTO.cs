namespace FinTracker.Domain.DTO.Response;

public class UserResponseDTO
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; }
}