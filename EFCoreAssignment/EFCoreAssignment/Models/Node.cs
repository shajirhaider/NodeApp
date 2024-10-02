using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }

        [Required]
        [StringLength(100)]
        public string NodeName { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string Aggregate { get; set; }

        [StringLength(50)]
        public string Player { get; set; }

        [StringLength(50)]
        public string NodeType { get; set; }

        [StringLength(50)]
        public string NodeSubType { get; set; }

        [StringLength(50)]
        public string LifeInsuranceClass { get; set; }

        [StringLength(50)]
        public string? NodeIdentifier { get; set; }

        public int SlaId { get; set; }

        [StringLength(50)]
        public string PeriodicFormat { get; set; }

        public DateTime? PeriodicFormatStartDate { get; set; }

        [StringLength(50)]
        public string TransactionFormat { get; set; }

        public DateTime? TransactionFormatStartDate { get; set; }

        [StringLength(50)]
        public string TaskType { get; set; }

        public int? EmailTemplateId { get; set; }

        [StringLength(50)]
        public string Shifting { get; set; }

        public int? ProcessDuration { get; set; }

        public int? ContactId { get; set; }

        public int? ContactCCId { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}
