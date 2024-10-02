using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models.DTOs
{
    public class SlaRequestDto
    {
        public int? SlaId { get; set; }
        [Required(ErrorMessage = "SLA Name is required.")]
        [StringLength(100, ErrorMessage = "SLA Name cannot exceed 100 characters.")]
        public string SlaName { get; set; }

        [Required(ErrorMessage = "Frequency Transaction is required.")]
        public string FrequencyTransaction { get; set; }

        [Required(ErrorMessage = "Frequency Position is required.")]
        public string FrequencyPosition { get; set; }

        [Required(ErrorMessage = "Anniversary is required.")]
        public bool Anniversary { get; set; }


        [Required(ErrorMessage = "ExcludeWeekends is required.")]
        public bool ExcludeWeekends { get; set; }

        [Required(ErrorMessage = "Reminder Days is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Reminder Days must be a non-negative number.")]
        public int ReminderDays { get; set; }

        [Required(ErrorMessage = "Escalation Days is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Escalation Days must be a non-negative number.")]
        public int EscalationDays { get; set; }
    }

}
