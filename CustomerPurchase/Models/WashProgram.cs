using System.ComponentModel.DataAnnotations;

namespace CustomerPurchase.Models;

public class WashProgram
{
    [Key]
    public int ProgramId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    public int DurationMinutes { get; set; }
    
    [Required]
    public int TemperatureCelsius { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new List<AvailableProgram>();
}