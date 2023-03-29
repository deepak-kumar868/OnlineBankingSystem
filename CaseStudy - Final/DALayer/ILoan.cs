using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DALayer
{
    public interface ILoan
    {
        public Task<LoanModel> TakeLoan(LoanModel loan);
        public Task<LoanModel> DeleteLoanRecord(int LoanId);
        public Task<LoanModel> GetLoanStatus(int lnId);
        public Task<LoanModel> UpdateLoanDetails(LoanModel Ln);
        public Task<List<LoanModel>> ShowAllAvailableLoans();
    }
}
