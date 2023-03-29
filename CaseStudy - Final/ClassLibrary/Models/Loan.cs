using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int? CustomerId { get; set; }
        public int? LoanAmount { get; set; }
        public string AccountNo { get; set; }
        public string LoanStatus { get; set; }

        public virtual Account AccountNoNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
