using System.Collections.Generic;

namespace postman_demo.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Purchases = new HashSet<Purchases>();
        }

        public string Eid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
