﻿namespace Shopping.Aggregator.Web.DTOs
{
    public class BasketDto
    {
        public string? UserName { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public decimal TotalPrice { get; set; }
    }
}
