using CustomerPurchase.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CustomerPurchase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private CustomerPurchasesDbContext _context;

    public CustomersController(CustomerPurchasesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers(CancellationToken cancellationToken)
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }
    
    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetCustomerPurchasesByIdAsync(int id, CancellationToken cancellationToken)
    {
        var response = await _context.Customers
            .Where(c => c.CustomerId == id)
            .Select(c => new
            {
                firstName = c.FirstName,
                lastName = c.LastName,
                phoneNumber = c.PhoneNumber,
                purchases = c.Purchases.Select(p => new
                {
                    date = p.PurchaseDate,
                    rating = p.Rating,
                    price = p.AvailableProgram.Price,
                    washingMachine = new
                    {
                        serial = p.AvailableProgram.WashingMachine.SerialNumber,
                        maxWeight = p.AvailableProgram.WashingMachine.MaxWeight,
                    },
                    program = new
                    {
                        name = p.AvailableProgram.WashProgram.Name,
                        duration = p.AvailableProgram.WashProgram.DurationMinutes
                    }
                    
                })
                
            }).FirstOrDefaultAsync(cancellationToken);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
        }
}