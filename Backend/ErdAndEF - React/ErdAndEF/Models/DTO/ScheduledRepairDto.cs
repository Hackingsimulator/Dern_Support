using System;
using System.ComponentModel.DataAnnotations;

namespace ErdAndEF.Models
{
    public class ScheduledRepairDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime RepairDate { get; set; }
    }
}
