using System.ComponentModel.DataAnnotations;

namespace CustomerPurchase.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    public string? PhoneNumber { get; set; }
}