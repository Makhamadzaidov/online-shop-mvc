﻿using OnlineMarket.Domain.Commons;

namespace OnlineMarket.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
