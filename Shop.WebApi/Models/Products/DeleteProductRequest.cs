using System.ComponentModel.DataAnnotations;

namespace Shop.WebApi.Models.Products
{
    public class DeleteProductRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
