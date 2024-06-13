using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Orders
{
    public class EditOrderRequest
    {

        [Required]
        public int Id { get; set; }
        
        public List<int> ProductsId { get; set; } = null!;
    }
}
