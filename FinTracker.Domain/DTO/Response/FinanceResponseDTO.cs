﻿namespace FinTracker.Domain.DTO.Response;

public class FinanceResponseDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Category { get; set; }

    public string Reason { get; set; }

    public decimal Value { get; set; }

    public DateTime OcurrencyDate { get; set; } = DateTime.Now;
}