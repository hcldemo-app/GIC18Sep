using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class ProductInfo
    {
        public ProductInfo()
        {
            ProductCompany = new HashSet<ProductCompany>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitPrice { get; set; }

        public ICollection<ProductCompany> ProductCompany { get; set; }
    }
}
