using System;
using System.Collections.Generic;

namespace GICMicro.Models
{
    public partial class LmsTransactions
    {
        public int TnsactionId { get; set; }
        public DateTime AppliedDate { get; set; }
        public string LeaveType { get; set; }
        public int EmpId { get; set; }
        public DateTime LeaveOnDate { get; set; }
        public string Status { get; set; }
    }
}
