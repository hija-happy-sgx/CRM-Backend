using Microsoft.AspNetCore.Mvc;
using MiniCRM.Data.Context;
using MiniCRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly MiniCrmDbContext _context;
        public ActivitiesController(MiniCrmDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetActivities() => Ok(await _context.Activities.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            return activity == null ? NotFound() : Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            activity.CreatedDate = DateTime.Now;
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            var existing = await _context.Activities.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Type = activity.Type;
            existing.Notes = activity.Notes;
            existing.DueDate = activity.DueDate;
            existing.LeadId = activity.LeadId;
            existing.DealId = activity.DealId;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
