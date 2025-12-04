using Api3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PmApi.Data;
using PmApi.Dtos;
using PmApi.Models;

namespace PmApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PmController : ControllerBase
    {
        private readonly PmDbContext _db;

        public PmController(PmDbContext db)
        {
            _db = db;
        }

        // GET api/pm?from=2025-01-01&to=2025-01-31&assetId=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PmItemDto>>> GetPmList(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to,
            [FromQuery] int? assetId)
        {
            var query = _db.PmEvents
                .Include(e => e.Schedule).ThenInclude(s => s.Asset)
                .Include(e => e.Schedule).ThenInclude(s => s.Task)
                .Where(e => e.PlannedDate != null &&
                            e.PlannedDate >= from && e.PlannedDate <= to);

            if (assetId.HasValue)
                query = query.Where(e => e.Schedule.AssetId == assetId.Value);

            var result = await query
                .Select(e => new PmItemDto
                {
                    Id = e.Id,
                    AssetName = e.Schedule.Asset.Name,
                    TaskName = e.Schedule.Task.Name,
                    PlannedDate = e.PlannedDate,
                    Status = e.Status
                }).ToListAsync();

            var today = DateTime.Today;

            foreach (var item in result)
            {
                if (item.Status == PmStatus.Completed) continue;

                if (item.PlannedDate < today) item.Status = PmStatus.Overdue;
                else if (item.PlannedDate == today) item.Status = PmStatus.DueToday;
                else item.Status = PmStatus.Upcoming;
            }

            return result;
        }

        // POST api/pm/5/complete
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var evt = await _db.PmEvents.FindAsync(id);
            if (evt == null) return NotFound();

            evt.Status = PmStatus.Completed;
            evt.CompletedDate = DateTime.Now;

            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
