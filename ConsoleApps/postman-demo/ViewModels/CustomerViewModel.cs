using System;

namespace postman_demo.ViewModels
{
    public class CustomerViewModel
    {
        public string Cid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int? VisitsMade { get; set; }
        public DateTime? LastVisitDate { get; set; }
    }
}