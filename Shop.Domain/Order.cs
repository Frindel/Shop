﻿namespace Shop.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public List<Product> Products { get; set; } = null!;
    }
}
