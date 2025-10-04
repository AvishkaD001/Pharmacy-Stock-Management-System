using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PharmacyController(AppDbContext context)
        {
            _context = context;
        }

        // Pharmacy Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PharmacyLoginRequest loginRequest)
        {
            var pharmacy = await _context.Pharmacy
                .FirstOrDefaultAsync(p => p.Email == loginRequest.Email && p.Password == loginRequest.Password);

            if (pharmacy == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new { message = "Login successful", pharmacyId = pharmacy.PharmacyId });
        }

        // Search drugs by name
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Stock>>> SearchDrugs(string query)
        {
            var drugs = await _context.Stocks
                .Where(d => d.DrugName.Contains(query) || d.Location.Contains(query))
                .ToListAsync();

            return Ok(drugs);
        }

        // Get all drugs 
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllDrugs()
        {
            return await _context.Stocks.ToListAsync(); 
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyDrugs([FromBody] PurchaseRequest purchaseRequest)
        {
          
            var pharmacy = await _context.Pharmacy
                .FirstOrDefaultAsync(p => p.PharmacyId == purchaseRequest.PharmacyID);
            if (pharmacy == null)
            {
                return NotFound("Pharmacy not found");
            }

           
            var stock = await _context.Stocks.FindAsync(purchaseRequest.DrugID);
            if (stock == null)
            {
                return NotFound("Drug not found in stock");
            }

          
            if (stock.Quantity < purchaseRequest.Quantity)
            {
                return BadRequest("Not enough stock available");
            }

           
            stock.Quantity -= purchaseRequest.Quantity;

            
            var drugOrder = new DrugOrder
            {
                PharmacyId = pharmacy.PharmacyId, 
                DrugID = stock.Id, 
                Quantity = purchaseRequest.Quantity,
                OrderDate = DateTime.Now
            };

        
            _context.DrugOrders.Add(drugOrder);

            try
            {
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
              
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return Ok(new { message = "Purchase successful" });
        }



    }

    public class PharmacyLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class PurchaseRequest
    {
        public int PharmacyID { get; set; }
        public int DrugID { get; set; }
        public int Quantity { get; set; }
    }

}
