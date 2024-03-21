
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Models;

public class CustomerModel
{
    public string? CustomerId { get; set; }

    public string? Participant { get; set; }

    public string? Reason { get; set; }
}
