using Api3.Models;
using PmApi.Models;

namespace PmApi.Dtos
{
    public class PmItemDto
    {
        public int Id { get; set; }
        public string AssetName { get; set; } = "";
        public string TaskName { get; set; } = "";
        public DateTime? PlannedDate { get; set; }
        public PmStatus Status { get; set; }
    }
}
