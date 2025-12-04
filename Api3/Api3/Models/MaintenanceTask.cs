namespace PmApi.Models
{
    public class MaintenanceTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public ICollection<PmSchedule> Schedules { get; set; } = new List<PmSchedule>();
    }
}
