using System;
using System.Collections.Generic;

namespace postman_demo.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Purchases = new HashSet<Purchases>();
        }

        public string Cid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int? VisitsMade { get; set; }
        public DateTime? LastVisitDate { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
