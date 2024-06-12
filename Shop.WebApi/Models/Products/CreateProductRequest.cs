using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Products
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
