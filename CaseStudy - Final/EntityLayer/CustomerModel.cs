using System;

namespace EntityLayer
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhNo { get; set; }
        public int? CustomerAge { get; set; }
        public DateTime? Dob { get; set; }
    }
}
