namespace FinTracker.Domain.DTO;

public class FinanceDTO
{
    public string Title { get; set; }

    public string Category { get; set; }

    public string Reason { get; set; }

    public decimal Value { get; set; }

    public int UserId { get; set; }
}