using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface ITransaction
    {
        public Transaction MakeTransaction(Transaction acct);
        public void DeleteTransaction(int TransId, string AcctNo);
        public Transaction GetTransactionStatus(int TransId);
        //public Account ShowByAcctNo(int ActNum);
        public IEnumerable<Transaction> ShowAllTransactions();
    }
}
