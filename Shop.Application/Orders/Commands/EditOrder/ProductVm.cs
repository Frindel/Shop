﻿namespace Shop.Application.Orders.Commands.EditOrder
{
    public class ProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
