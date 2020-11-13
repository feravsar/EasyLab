using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request{
    public class LoginRequest{
        [Required]
        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
    }
}