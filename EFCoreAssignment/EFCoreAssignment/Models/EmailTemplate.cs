using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models
{
    public class EmailTemplate
    {
        [Key]
        public int? EmailTemplateId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailTemplateName { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailTemplateSubject { get; set; }

        [Required]
        public string EmailTemplateBody { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}
