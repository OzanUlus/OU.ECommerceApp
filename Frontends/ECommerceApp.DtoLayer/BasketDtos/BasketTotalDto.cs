﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DtoLayer.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(bi => bi.Price * bi.Quantity); }
    }
}