using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class ProductCompany
    {
        public int ProductCompanyId { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        public CompanyId Company { get; set; }
        public ProductInfo Product { get; set; }
    }
}
