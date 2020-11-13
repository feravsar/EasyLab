using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request
{
    public class RegisterUserRequest
    {

        [Required]
        [RegularExpression("^20[0-9]{9}$", ErrorMessage = "Username must be: 20.........")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name can not be longer than 30 characters and less than 2 characters", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Surname can not be longer than 30 characters and less than 2 characters", MinimumLength = 2)]
        public string Surname { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
