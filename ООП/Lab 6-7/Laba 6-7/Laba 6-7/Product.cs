using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba_6_7
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public float  rating { get; set; }
        public decimal price { get; set; }
        public int count { get; set; }
        public string color { get; set; }
        public string description { get; set; }

    }
}
