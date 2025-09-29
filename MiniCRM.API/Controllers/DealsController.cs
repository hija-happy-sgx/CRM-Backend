using Microsoft.AspNetCore.Mvc;
using MiniCRM.Data.Context;
using MiniCRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealsController : ControllerBase
    {
        private readonly MiniCrmDbContext _context;
        public DealsController(MiniCrmDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetDeals() => Ok(await _context.Deals.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeal(int id)
        {
            var deal = await _context.Deals.FindAsync(id);
            return deal == null ? NotFound() : Ok(deal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal([FromBody] Deal deal)
        {
            deal.CreatedDate = DateTime.Now;
            _context.Deals.Add(deal);
            await _context.SaveChangesAsync();
            return Ok(deal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeal(int id, [FromBody] Deal deal)
        {
            var existing = await _context.Deals.FindAsync(id);
            if (existing == null) return NotFound();

            existing.LeadId = deal.LeadId;
            existing.SalesRepId = deal.SalesRepId;
            existing.StageId = deal.StageId;
            existing.Value = deal.Value;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeal(int id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if (deal == null) return NotFound();

            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
