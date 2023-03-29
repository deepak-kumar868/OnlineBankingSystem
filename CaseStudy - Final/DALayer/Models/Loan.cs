using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int? CustomerId { get; set; }
        public int? LoanAmount { get; set; }
        public string AccountNo { get; set; }

        public virtual Account AccountNoNavigation { get; set; }
        public virtual Account Customer { get; set; }
    }
}
