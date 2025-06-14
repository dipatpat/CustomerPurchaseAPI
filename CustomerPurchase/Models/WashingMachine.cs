using System.ComponentModel.DataAnnotations;

namespace CustomerPurchase.Models;

public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    
    [Required]
    public decimal MaxWeight { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
}