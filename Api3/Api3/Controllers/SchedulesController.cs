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
    public class SchedulesController : ControllerBase
    {
        private readonly PmDbContext _db;

        public SchedulesController(PmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleDto dto)
        {
            var schedule = new PmSchedule
            {
                AssetId = dto.AssetId,
                TaskId = dto.TaskId,
                ScheduleType = dto.ScheduleType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                EveryNWeeks = dto.EveryNWeeks,
                WeekDay = dto.WeekDay,
                EveryNMonths = dto.EveryNMonths,
                DayOfMonth = dto.DayOfMonth,
                StartOdometer = dto.StartOdometer,
                EveryNKilometers = dto.EveryNKilometers
            };

            _db.PmSchedules.Add(schedule);
            await _db.SaveChangesAsync();

            var toDate = schedule.EndDate ?? DateTime.Today.AddYears(1);
            var events = GenerateEvents(schedule, schedule.StartDate, toDate);

            _db.PmEvents.AddRange(events);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule.Id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PmSchedule>> GetSchedule(int id)
        {
            var schedule = await _db.PmSchedules
                .Include(s => s.Asset)
                .Include(s => s.Task)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (schedule == null) return NotFound();
            return schedule;
        }

        private IEnumerable<PmEvent> GenerateEvents(PmSchedule s, DateTime from, DateTime to)
        {
            if (s.ScheduleType == ScheduleType.WeeklyTime &&
                s.EveryNWeeks.HasValue && s.WeekDay.HasValue)
            {
                var list = new List<PmEvent>();
                var first = from;

                while (first.DayOfWeek != s.WeekDay.Value)
                    first = first.AddDays(1);

                for (var d = first; d <= to; d = d.AddDays(7 * s.EveryNWeeks!.Value))
                {
                    list.Add(new PmEvent
                    {
                        ScheduleId = s.Id,
                        PlannedDate = d,
                        Status = PmStatus.Upcoming
                    });
                }

                return list;
            }

            if (s.ScheduleType == ScheduleType.MonthlyTime &&
                s.EveryNMonths.HasValue && s.DayOfMonth.HasValue)
            {
                var list = new List<PmEvent>();
                var current = new DateTime(from.Year, from.Month, 1);

                while (current <= to)
                {
                    var day = Math.Min(s.DayOfMonth.Value,
                        DateTime.DaysInMonth(current.Year, current.Month));

                    var date = new DateTime(current.Year, current.Month, day);

                    if (date >= from && date <= to)
                    {
                        list.Add(new PmEvent
                        {
                            ScheduleId = s.Id,
                            PlannedDate = date,
                            Status = PmStatus.Upcoming
                        });
                    }

                    current = current.AddMonths(s.EveryNMonths.Value);
                }

                return list;
            }

            if (s.ScheduleType == ScheduleType.Odometer &&
                s.StartOdometer.HasValue && s.EveryNKilometers.HasValue)
            {
                var list = new List<PmEvent>();
                var odo = s.StartOdometer.Value;

                for (int i = 0; i < 10; i++)
                {
                    list.Add(new PmEvent
                    {
                        ScheduleId = s.Id,
                        PlannedOdometer = odo,
                        Status = PmStatus.Upcoming
                    });

                    odo += s.EveryNKilometers.Value;
                }

                return list;
            }

            return Enumerable.Empty<PmEvent>();
        }
    }
}
