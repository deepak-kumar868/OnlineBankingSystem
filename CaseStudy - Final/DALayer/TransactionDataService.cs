using System;
using System.Collections.Generic;
using System.Text;
using DALayer;
using EntityLayer;
using DALayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DALayer
{
    public class TransactionDataService: ITransaction
    {
        private OnlineBankingSystemContext db;

        public TransactionDataService(OnlineBankingSystemContext db)
        {
            this.db = db;
        }

        public async Task<TransactionModel> MakeTransaction(TransactionModel NewTrans)
        {
            Transaction trans = new Transaction();
            trans.AccountNo = NewTrans.AccountNo;
            trans.CustomerId = NewTrans.CustomerId;
            trans.Amount = NewTrans.Amount;
            trans.DateOfTransaction = NewTrans.DateOfTransaction;
            trans.TransactionId = NewTrans.TransactionId;

            try
            {
                await db.Transactions.AddAsync(trans);
                db.SaveChanges();

                return NewTrans;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TransactionModel> DeleteTransaction(int Tid)
        {
            TransactionModel trans = new TransactionModel();

            var DelTrans = await db.Transactions.FindAsync(Tid);

            if (DelTrans != null)
            {
                db.Transactions.Remove(DelTrans);
                db.SaveChanges();

                trans.AccountNo = DelTrans.AccountNo;
                trans.CustomerId = DelTrans.CustomerId;
                trans.Amount = DelTrans.Amount;
                trans.DateOfTransaction = DelTrans.DateOfTransaction;
                trans.TransactionId = DelTrans.TransactionId;

                return trans;
            }
            else
            {
                throw new Exception("Account not found");
            }
        }
        public async Task<TransactionModel> UpdateTransaction(TransactionModel UpdTrans)
        {

            try
            {
                var trans = await db.Transactions.FindAsync(UpdTrans.TransactionId);
                if ( UpdTrans!= null)
                {
                    trans.AccountNo = UpdTrans.AccountNo;
                    trans.CustomerId = UpdTrans.CustomerId;
                    trans.Amount = UpdTrans.Amount;
                    trans.DateOfTransaction = UpdTrans.DateOfTransaction;
                    trans.TransactionId = UpdTrans.TransactionId;

                    db.Entry(trans).State = EntityState.Modified;
                    db.SaveChanges();

                    return UpdTrans;
                }
                else
                {
                    throw new Exception("Updation failed");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<TransactionModel> GetTransactionStatus(int Tid)
        {
            TransactionModel trans = new TransactionModel();

            var t = await db.Transactions.FindAsync(Tid);

            if (t != null)
            {
                trans.AccountNo = t.AccountNo;
                trans.CustomerId = t.CustomerId;
                trans.Amount = t.Amount;
                trans.DateOfTransaction = t.DateOfTransaction;
                trans.TransactionId = t.TransactionId;

                return trans;
            }
            else
            {
                throw new Exception("Transaction Id not found");
            }

        }
        public async Task<List<TransactionModel>> ShowAllTransactions()
        {
            List<TransactionModel> tlist = new List<TransactionModel>();
            IEnumerable<Transaction> lst;

            try
            {
                lst =await db.Transactions.ToListAsync();

                foreach (var t in lst)
                {
                    TransactionModel trans = new TransactionModel();
                    trans.AccountNo = t.AccountNo;
                    trans.CustomerId = t.CustomerId;
                    trans.Amount = t.Amount;
                    trans.DateOfTransaction = t.DateOfTransaction;
                    trans.TransactionId = t.TransactionId;
                    tlist.Add(trans);
                }
                return tlist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
