using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models
{
    public class Monitoring
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string Aggregate { get; set; }

        [StringLength(50)]
        public string Node { get; set; }

        [StringLength(50)]
        public string Player { get; set; }

        [StringLength(50)]
        public string NodeType { get; set; }

        [StringLength(50)]
        public string TaskType { get; set; }

        [StringLength(50)]
        public string SLA { get; set; }

        [StringLength(50)]
        public string Shifting { get; set; }

        public int? ProcessDuration { get; set; } // Nullable if not always provided

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string ContactCC { get; set; }

        [StringLength(50)]
        public string LastControlPosition { get; set; }

        public DateTime? NextReconciliationDate { get; set; }

        public int? Delay { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}
