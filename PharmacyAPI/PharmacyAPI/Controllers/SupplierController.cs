using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly AppDbContext _context;

    public SupplierController(AppDbContext context)
    {
        _context = context;
    }

    // Supplier Registration
    [HttpPost("register")]
    public async Task<IActionResult> Register(Supplier supplier)
    {
        var existingSupplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.CompanyRegistrationId == supplier.CompanyRegistrationId);

        if (existingSupplier != null)
        {
            return Conflict(new { message = "This Company Registration ID is already in use." });
        }

        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Register), supplier);
    }

    // Supplier Login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] SupplierLoginRequest loginRequest)
    {
        var supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

        if (supplier == null)
        {
            return Unauthorized("Invalid email or password");
        }

        return Ok(new { message = "Login successful", supplierId = supplier.SupplierId });
    }


    // Send Tender Proposal
    [HttpPost("send-tender")]
    public async Task<IActionResult> SendTender([FromBody] TenderRequest tenderRequest)
    {
        if (string.IsNullOrEmpty(tenderRequest.CompanyRegistrationId))
        {
            return BadRequest("Company Registration ID cannot be empty.");
        }

   
        var supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.CompanyRegistrationId == tenderRequest.CompanyRegistrationId);

        if (supplier == null)
        {
            return NotFound("Supplier not found.");
        }

        var tender = new Tender
        {
            CompanyRegistrationId = tenderRequest.CompanyRegistrationId,
            TenderDetails = tenderRequest.TenderDetails,
            SubmissionDate = DateTime.UtcNow
        };

        try
        {
            _context.Tenders.Add(tender);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tender Proposal Sent Successfully" });
        }
        catch (Exception ex)
        {
            
            var errorMessage = $"An error occurred while saving the entity changes. " +
                               $"Inner Exception: {ex.InnerException?.Message ?? "None"}";

            
            Console.WriteLine(errorMessage);

           
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = errorMessage });
        }
    }

}




public class SupplierLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}


public class TenderRequest
{
    public string CompanyRegistrationId { get; set; }
    public string TenderDetails { get; set; }
}
