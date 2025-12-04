using Api3.Models;

namespace PmApi.Models
{
    public class PmEvent
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }
        public PmSchedule Schedule { get; set; } = null!;

        public DateTime? PlannedDate { get; set; }      // для временных графиков
        public int? PlannedOdometer { get; set; }       // для пробега

        public PmStatus Status { get; set; }

        public DateTime? CompletedDate { get; set; }
        public int? CompletedOdometer { get; set; }
    }
}
