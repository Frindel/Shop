using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Orders
{
    public class CreateOrderRequest
    {
        public List<int> ProductsId { get; set; } = null!;
    }
}
