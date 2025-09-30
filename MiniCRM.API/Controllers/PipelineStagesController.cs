using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Core.Models;
using MiniCRM.Data;
using MiniCRM.Data.Context;

namespace MiniCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PipelineStagesController : ControllerBase
    {
        private readonly MiniCrmDbContext _context;

        public PipelineStagesController(MiniCrmDbContext context)
        {
            _context = context;
        }

        // GET: api/PipelineStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PipelineStage>>> GetPipelineStages()
        {
            return await _context.PipelineStages
                                 .OrderBy(s => s.StageOrder)
                                 .ToListAsync();
        }

        // GET: api/PipelineStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PipelineStage>> GetPipelineStage(int id)
        {
            var stage = await _context.PipelineStages.FindAsync(id);
            if (stage == null) return NotFound();
            return stage;
        }

        // POST: api/PipelineStages
        [HttpPost]
        public async Task<ActionResult<PipelineStage>> CreatePipelineStage(PipelineStage stage)
        {
            _context.PipelineStages.Add(stage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPipelineStage), new { id = stage.StageId }, stage);
        }

        // PUT: api/PipelineStages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePipelineStage(int id, PipelineStage stage)
        {
            if (id != stage.StageId) return BadRequest();

            _context.Entry(stage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PipelineStages.Any(e => e.StageId == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/PipelineStages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePipelineStage(int id)
        {
            var stage = await _context.PipelineStages.FindAsync(id);
            if (stage == null) return NotFound();

            _context.PipelineStages.Remove(stage);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
