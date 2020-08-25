using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request
{
    public class ExchangeRefreshTokenRequest
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set;}
    }
}