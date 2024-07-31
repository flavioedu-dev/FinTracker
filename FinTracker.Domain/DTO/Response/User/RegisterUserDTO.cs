namespace FinTracker.Domain.DTO.Response.User;

public class RegisterUserResponseDTO
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; }
}