using System.Collections.Generic;

namespace postman_demo.Models
{
    public partial class Products
    {
        public Products()
        {
            Purchases = new HashSet<Purchases>();
        }

        public string Pid { get; set; }
        public string Name { get; set; }
        public int? Qoh { get; set; }
        public int? QohThreshold { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal? DiscntRate { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
