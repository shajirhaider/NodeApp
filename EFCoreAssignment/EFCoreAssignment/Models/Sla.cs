using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models
{
    public class Sla
    {
        [Key]
        public int? SlaId { get; set; }

        [Required]
        [StringLength(100)]
        public string SlaName { get; set; }

        public string SlaFrequencyTransaction { get; set; }

        public string SlaFrequencyPosition { get; set; }

        public bool SlaAnniversary { get; set; }

        public bool SlaExcludeWeekends { get; set; }

        public int? SlaReminderDays { get; set; }

        public int? SlaEscalationDays { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}