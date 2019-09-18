using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class EmployeeMyhcl
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Band { get; set; }
        public int? ManagerId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Location { get; set; }
        public int? TotalLeaves { get; set; }
        public string Email { get; set; }
    }
}
