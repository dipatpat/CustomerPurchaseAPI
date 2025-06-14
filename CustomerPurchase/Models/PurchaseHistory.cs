using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerPurchase.Models;

public class PurchaseHistory
{
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(AvailableProgramId))]
    public AvailableProgram AvailableProgram { get; set; } = null!;
    
    public int CustomerId { get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;
    
    public DateTime PurchaseDate { get; set; }
    
    public int? Rating { get; set; }
}