using Api3.Models;

namespace PmApi.Models
{
    public class PmSchedule
    {
        public int Id { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        public int TaskId { get; set; }
        public MaintenanceTask Task { get; set; } = null!;

        public ScheduleType ScheduleType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Weekly
        public int? EveryNWeeks { get; set; }
        public DayOfWeek? WeekDay { get; set; }

        // Monthly
        public int? EveryNMonths { get; set; }
        public int? DayOfMonth { get; set; }

        // Odometer
        public int? StartOdometer { get; set; }
        public int? EveryNKilometers { get; set; }

        public ICollection<PmEvent> Events { get; set; } = new List<PmEvent>();
    }
}
