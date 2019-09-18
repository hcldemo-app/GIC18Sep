using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class CompanyId
    {
        public CompanyId()
        {
            ProductCompany = new HashSet<ProductCompany>();
            UsersInfo = new HashSet<UsersInfo>();
        }

        public int CompanyId1 { get; set; }
        public string CustomerCode { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string RegionState { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<ProductCompany> ProductCompany { get; set; }
        public ICollection<UsersInfo> UsersInfo { get; set; }
    }
}
