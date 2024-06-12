using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public bool? IsAdmin { get; set; }
    }
}
