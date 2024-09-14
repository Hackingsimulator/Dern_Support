using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ErdAndEF.Models
{
    public class ScheduledRepair
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime RepairDate { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore] // Prevents deserialization from JSON
        public string? UserId { get; set; }
    }
}
