using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Accounts
{
    public class UpdateAccessTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; } = null!;
    }
}
