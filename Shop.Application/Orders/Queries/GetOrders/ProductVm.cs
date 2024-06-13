namespace Shop.Application.Orders.Queries.GetOrders
{
    public class ProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
