using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Account
    {
        public Account()
        {
            LoanAccountNoNavigations = new HashSet<Loan>();
            LoanCustomers = new HashSet<Loan>();
            TransactionAccountNoNavigations = new HashSet<Transaction>();
            TransactionCustomers = new HashSet<Transaction>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhNo { get; set; }
        public int? CustomerAge { get; set; }
        public DateTime? Dob { get; set; }
        public string AccountNo { get; set; }
        public string Ifsc { get; set; }
        public int? AccountTypeId { get; set; }
        public int? Balance { get; set; }
        public string Branch { get; set; }
        public string CustomerType { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual UserCredential UserCredential { get; set; }
        public virtual ICollection<Loan> LoanAccountNoNavigations { get; set; }
        public virtual ICollection<Loan> LoanCustomers { get; set; }
        public virtual ICollection<Transaction> TransactionAccountNoNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionCustomers { get; set; }
    }
}
