﻿namespace MagnesiaPcShop.Entities
{
    public class Shipper : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Order> Orders { get; set; }
    }
}