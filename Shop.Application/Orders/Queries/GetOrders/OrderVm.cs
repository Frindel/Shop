using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Orders.Queries.GetOrders
{
    public class OrderVm : MappingBase<Order>
    {
        public int Id { get; set; }

        public List<ProductVm> Product { get; set; } = null!;
        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>()
                .ForMember(orderVm => orderVm.Product,
                opt => opt.MapFrom(order =>
                
                order.Products.Select(c => new ProductVm()
                {
                    Id = c.Id,
                    Name = c.Name
                })));
        }
    }
}
