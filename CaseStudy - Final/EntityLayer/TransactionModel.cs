using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public string AccountNo { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateOfTransaction { get; set; }
    }
}
