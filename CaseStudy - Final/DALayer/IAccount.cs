using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DALayer.Models;
using EntityLayer;

namespace DALayer
{
    public interface IAccount
    {
        public Task<AccountModel> AddAccount(AccountModel acct);
        public Task<AccountModel> DeleteAccount(int cusId);
        public Task<AccountModel> UpdateAccount(AccountModel acct);
        public Task<AccountModel> ShowByAcctNo(int cusId);
        public Task<List<AccountModel>> ShowAllAccounts();
    }
}
