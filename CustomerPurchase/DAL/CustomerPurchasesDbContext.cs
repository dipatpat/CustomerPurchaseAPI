using CustomerPurchase.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchase.DAL;

public class CustomerPurchasesDbContext : DbContext
{
    public DbSet<WashProgram> WashPrograms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }

    protected CustomerPurchasesDbContext()
    {
    }

    public CustomerPurchasesDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PurchaseHistory>() // composite key
            .HasKey(ph => new { ph.AvailableProgramId, ph.CustomerId });
        
        modelBuilder.Entity<PurchaseHistory>()
            .Property(p => p.PurchaseDate)
            .HasDefaultValueSql("getdate()"); // defaults to current date if not provided
        
        modelBuilder.Entity<AvailableProgram>()
            .Property(p => p.Price)
            .HasColumnType("decimal(10,2)"); //restricting decimal
        
        modelBuilder.Entity<WashingMachine>()
            .Property(p => p.MaxWeight)
            .HasColumnType("decimal(10,2)"); //restrictin decimal
        
        modelBuilder.Entity<WashProgram>().HasData(
            new WashProgram { ProgramId = 1, Name = "Program 1", DurationMinutes = 10, TemperatureCelsius = 30 },
            new WashProgram { ProgramId = 2, Name = "Program 2", DurationMinutes = 10, TemperatureCelsius = 30 },
            new WashProgram { ProgramId = 3, Name = "Program 3", DurationMinutes = 10, TemperatureCelsius = 30 }
        );

        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram { AvailableProgramId = 1, ProgramId = 1, WashingMachineId = 1, Price = 55 },
            new AvailableProgram { AvailableProgramId = 2, ProgramId = 2, WashingMachineId = 2, Price = 65 },
            new AvailableProgram { AvailableProgramId = 3, ProgramId = 3, WashingMachineId = 3 , Price = 78}
        );


        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "John", LastName = "Smith", PhoneNumber = "234243242" },
            new Customer { CustomerId = 2, FirstName = "Ana", LastName = "Lala", PhoneNumber = "412411" },
            new Customer { CustomerId = 3, FirstName = "Eva", LastName = "Bebe", PhoneNumber = "21412313" }
        );

        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine { WashingMachineId = 1, MaxWeight = 10, SerialNumber = "2374192381" },
            new WashingMachine { WashingMachineId = 2, MaxWeight = 10, SerialNumber = "81734124" },
            new WashingMachine { WashingMachineId = 3, MaxWeight = 10, SerialNumber = "13741923421" }
        );
        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = new DateTime(2024, 12, 10) },
            new PurchaseHistory { AvailableProgramId = 2, CustomerId = 2, PurchaseDate = new DateTime(2024, 11, 10) },
            new PurchaseHistory { AvailableProgramId = 3, CustomerId = 3, PurchaseDate = new DateTime(2024, 10, 10) }
        );
    }
}