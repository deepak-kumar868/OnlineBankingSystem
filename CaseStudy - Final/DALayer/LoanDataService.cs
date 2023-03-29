using System;
using System.Collections.Generic;
using System.Text;
using DALayer.Models;
using DALayer;
using EntityLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DALayer
{
    public class LoanDataService : ILoan 
    {
        private OnlineBankingSystemContext db;
        public LoanDataService(OnlineBankingSystemContext db)
        {
            this.db = db;
        }

        public async Task<LoanModel> TakeLoan(LoanModel loan)
        {
            Loan l = new Loan();
            l.AccountNo = loan.AccountNo;
            l.CustomerId = loan.CustomerId;
            l.LoanAmount = loan.LoanAmount;
            l.LoanId = loan.LoanId;
            try
            {
                await db.Loans.AddAsync(l);
                db.SaveChanges();

                return loan;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }

                throw new Exception(e.Message);
            }

        }
        public async Task<LoanModel> DeleteLoanRecord(int LoanId)
        {
            LoanModel? l = new LoanModel();
            Loan? LRec;
            try
            {
                LRec = await db.Loans.FindAsync(LoanId);
                if (LRec != null)
                {
                    db.Loans.Remove(LRec);
                    db.SaveChanges();

                    l.AccountNo = LRec.AccountNo;
                    l.CustomerId = LRec.CustomerId;
                    l.LoanAmount = LRec.LoanAmount;
                    l.LoanId = LRec.LoanId;

                    return l;
                }
                else
                {
                    throw new Exception("Cannot find Record");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoanModel> GetLoanStatus(int lnId)
        {
            LoanModel? l = new LoanModel();
            Loan? LRec;
            try
            {
                LRec =await db.Loans.FindAsync(lnId);
                if (LRec != null)
                {
                    l.AccountNo = LRec.AccountNo;
                    l.CustomerId = LRec.CustomerId;
                    l.LoanAmount = LRec.LoanAmount;
                    l.LoanId = LRec.LoanId;

                    return l;
                }
                else
                {
                    throw new Exception("Record not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<LoanModel> UpdateLoanDetails(LoanModel UpdRec)
        {          
            try
            {
                var l = await db.Loans.FindAsync(UpdRec.LoanId);
                if (l != null)
                {
                    l.AccountNo = UpdRec.AccountNo;
                    l.CustomerId = UpdRec.CustomerId;
                    l.LoanAmount = UpdRec.LoanAmount;
                    l.LoanId = UpdRec.LoanId;

                    db.Entry(l).State = EntityState.Modified;
                    db.SaveChanges();
                    return UpdRec;
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
        public async Task<List<LoanModel>> ShowAllAvailableLoans()
        {
            List<LoanModel> loanlst = new List<LoanModel>();
            IEnumerable<Loan> ln;
            try
            {
                ln =await db.Loans.ToListAsync();

                //code to copy data from data model to user model
                foreach (var d in ln)
                {
                    LoanModel l = new LoanModel();
                    l.AccountNo = d.AccountNo;
                    l.CustomerId = d.CustomerId;
                    l.LoanAmount = d.LoanAmount;
                    l.LoanId = d.LoanId;
                    loanlst.Add(l);
                }
                return loanlst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
