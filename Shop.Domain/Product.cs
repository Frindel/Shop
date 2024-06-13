namespace Shop.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public List<Order> Orders { get; set; } = null!;
    }
}
