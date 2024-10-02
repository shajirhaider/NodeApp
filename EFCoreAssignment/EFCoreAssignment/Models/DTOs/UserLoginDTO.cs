using System.ComponentModel.DataAnnotations;



namespace EFCoreAssignment.Models
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(100, ErrorMessage = "UserName cannot exceed 255 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        // Default constructor
        public UserLoginDTO() { }

        // Parameterized constructor
        public UserLoginDTO(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}

