using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenDaily
{
    public class Employee
    {
        public string StaffNumber { get; set; }
        public string StaffName { get; set; }
        public string Department { get; set; }
        public int Status { get; set; }
        public DateTime Dates { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CardIssueDate { get; set; }
        public string Issuer { get; set; }
        public string Deactivator { get; set; }
        public DateTime DateDeactivated { get; set; }
        public DateTime DateReinstate { get; set; }
        public string Reinstater { get; set; }

    }
}
