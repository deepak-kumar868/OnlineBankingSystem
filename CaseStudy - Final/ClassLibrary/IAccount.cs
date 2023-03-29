using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using EntityLayer;

namespace DAL
{
    public interface IAccount
    {
        public AccountModel AddAccount(AccountModel acct);
        public AccountModel DeleteAccount(int AcctNum);
        public AccountModel UpdateAccount(AccountModel acct);
        public AccountModel ShowByAcctNo(int ActNum);
        public IEnumerable<AccountModel> ShowAllAccounts();
    }
}
