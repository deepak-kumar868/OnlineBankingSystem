using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class LoanModel
    {
        public int LoanId { get; set; }
        public int? CustomerId { get; set; }
        public int? LoanAmount { get; set; }
        public string AccountNo { get; set; }
    }
}
