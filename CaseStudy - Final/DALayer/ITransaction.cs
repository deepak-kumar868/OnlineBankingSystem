using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using DALayer.Models;
using EntityLayer;

namespace DALayer
{
    public interface ITransaction
    {
        public Task<TransactionModel> MakeTransaction(TransactionModel trans);
        public Task<TransactionModel> DeleteTransaction(int Tid);
        public Task<TransactionModel> GetTransactionStatus(int TransId);  
        public Task<TransactionModel> UpdateTransaction(TransactionModel trans);
        public Task<List<TransactionModel>> ShowAllTransactions();
    }
}
