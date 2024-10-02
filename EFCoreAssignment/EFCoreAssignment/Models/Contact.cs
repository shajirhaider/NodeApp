using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Player { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Phone]
        [StringLength(20)]
        public string BusinessPhone { get; set; }

        [Phone]
        [StringLength(20)]
        public string MobilePhone { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow; // Default to current time

    }
}
