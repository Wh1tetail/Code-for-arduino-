using Api3.Models;
using PmApi.Models;

namespace PmApi.Dtos
{
    public class CreateScheduleDto
    {
        public int AssetId { get; set; }
        public int TaskId { get; set; }
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
    }
}
