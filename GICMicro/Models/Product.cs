using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
    }
}
