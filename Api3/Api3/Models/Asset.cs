namespace PmApi.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? SerialNumber { get; set; }

        public ICollection<PmSchedule> Schedules { get; set; } = new List<PmSchedule>();
    }
}
