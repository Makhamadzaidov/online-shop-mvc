﻿namespace OnlineMarket.Domain.Commons
{
    public abstract class Auditable
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
