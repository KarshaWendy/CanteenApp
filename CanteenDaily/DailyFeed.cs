using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenDaily
{
    public class DailyFeed
    {
        public long ID { get; set; }
        public string SerialNumber { get; set; }
        public DateTime InsertTime { get; set; }
        public Double Amount { get; set; }
        public string StaffNumber { get; set; }
        public string Department { get; set; }
        public string CardName { get; set; }
        public string ClientCode { get; set; }
        public string MealType { get; set; }
        public string UsageInstance { get; set; }
    }
}
