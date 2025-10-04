
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly AppDbContext _context;

    public StockController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddStock([FromBody] Stock stock)
    {
        if (stock == null)
        {
            return BadRequest("Stock data is required.");
        }

        if (string.IsNullOrWhiteSpace(stock.StockType) || (stock.StockType != "Internal" && stock.StockType != "External"))
        {
            return BadRequest("Invalid StockType. Use 'Internal' or 'External'.");
        }

        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] Stock stock)
    {
        if (stock == null || id != stock.Id)
        {
            return BadRequest("Invalid stock data.");
        }

        var existingStock = await _context.Stocks.FindAsync(id);
        if (existingStock == null)
        {
            return NotFound("Stock not found.");
        }

        if (string.IsNullOrWhiteSpace(stock.StockType) || (stock.StockType != "Internal" && stock.StockType != "External"))
        {
            return BadRequest("Invalid StockType. Use 'Internal' or 'External'.");
        }

        _context.Entry(existingStock).CurrentValues.SetValues(stock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound("Stock not found.");
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
    {
        return await _context.Stocks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Stock>> GetStockById(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound("Stock not found.");
        }
        return stock;
    }

 
}
