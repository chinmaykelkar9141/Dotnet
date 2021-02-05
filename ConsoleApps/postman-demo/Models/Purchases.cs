using System;

namespace postman_demo.Models
{
    public partial class Purchases
    {
        public int Pur { get; set; }
        public string Eid { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }
        public int? Qty { get; set; }
        public DateTime? Ptime { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customers C { get; set; }
        public virtual Employees E { get; set; }
        public virtual Products P { get; set; }
    }
}
