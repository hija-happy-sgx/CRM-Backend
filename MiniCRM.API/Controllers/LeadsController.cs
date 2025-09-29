using Microsoft.AspNetCore.Mvc;
using MiniCRM.Data.Context;
using MiniCRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly MiniCrmDbContext _context;
        public LeadsController(MiniCrmDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetLeads() => Ok(await _context.Leads.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            return lead == null ? NotFound() : Ok(lead);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] Lead lead)
        {
            lead.CreatedDate = DateTime.Now;
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
            return Ok(lead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(int id, [FromBody] Lead lead)
        {
            var existing = await _context.Leads.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = lead.Name;
            existing.Company = lead.Company;
            existing.Email = lead.Email;
            existing.Phone = lead.Phone;
            existing.Status = lead.Status;
            existing.Budget = lead.Budget;
            existing.Authority = lead.Authority;
            existing.Need = lead.Need;
            existing.Timeline = lead.Timeline;
            existing.Score = lead.Score;
            existing.AssignedTo = lead.AssignedTo;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
