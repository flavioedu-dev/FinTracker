using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTracker.Domain.Entities;

public class Finance
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Category { get; set; }

    public string Reason { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Value { get; set; }

    [Required]
    public DateTime OcurrencyDate { get; set; } = DateTime.Now;

    [ForeignKey("User")]
    public int UserId { get; set; }

    public User? User { get; set; }
}
