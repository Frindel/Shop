﻿using MediatR;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class GetOrdersQuery : IRequest<OrdersListVm>
    {
    }
}