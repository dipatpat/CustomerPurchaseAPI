using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerPurchase.Models;

public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    
   
    public int WashingMachineId { get; set; }
    [ForeignKey(nameof(WashingMachineId))]
    public WashingMachine WashingMachine { get; set; } = null!;
    
    public int ProgramId { get; set; }
    
    public decimal Price { get; set; }

    [ForeignKey(nameof(ProgramId))] public WashProgram WashProgram { get; set; } = null!;
    
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();
}