namespace FinTracker.API.Models.Finance;

public class CreateFinanceModel
{
    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? Reason { get; set; }

    public decimal? Value { get; set; }

    public DateTime? OcurrencyDate { get; set; } = DateTime.Now;

    public int? UserId { get; set; }
}
