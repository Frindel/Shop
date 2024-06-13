using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Orders
{
    public class DeleteOrderRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
