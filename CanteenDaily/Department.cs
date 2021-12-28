using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenDaily
{
    public class Department
    {
        public string Name { get; set; }
        public string DepartmentKey { get; set; }
        public int Override { get; set; }

        public string FoodType { get; set; }
        public string TeaType { get; set; }
    }
}
