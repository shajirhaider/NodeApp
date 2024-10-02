using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models.DTOs
{
    public class NodeRequestDto
    {
        public int? NodeId { get; set; }

        [Required]
        [StringLength(100)]
        public string NodeName { get; set; }

        [StringLength(100)]
        public string Alias { get; set; }

        [StringLength(100)]
        public string Aggregate { get; set; }

        [StringLength(50)]
        public string NodeType { get; set; }

        [StringLength(50)]
        public string NodeSubType { get; set; }

        public int SlaId { get; set; }

        [StringLength(50)]
        public string TaskType { get; set; }

        public int? EmailTemplateId { get; set; }

        public string Shifting { get; set; }

        [Range(0, int.MaxValue)]
        public int ProcessDuration { get; set; }

        public int? ContactId { get; set; }

        public int? ContactCCId { get; set; }

        [StringLength(100)]
        public string Player { get; set; }
    }

}
