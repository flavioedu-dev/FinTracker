﻿namespace FinTracker.Domain.DTO;

public class UserResponseDTO
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; }
}
