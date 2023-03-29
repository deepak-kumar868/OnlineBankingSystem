using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;



namespace DAL
{
    public class AccountDataService :IAccount
    {
        private OnlineBankingContext db;

        public AccountDataService(OnlineBankingContext db)
        {
            this.db = db;
        }
       
        public AccountModel AddAccount(AccountModel NewAct)
        {
            Account act = new Account();
            //act.AccountNo = NewAct.AccountNo;
            act.CustomerId = NewAct.CustomerId;
            act.AccountTypeId = NewAct.AccountTypeId;
            act.Balance = NewAct.Balance;
            act.Branch = NewAct.Branch;

            try
            {
                db.Accounts.Add(act);
                db.SaveChanges();

                return NewAct;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public AccountModel DeleteAccount(int ActNo)
        {
            AccountModel act = new AccountModel();

            var Rec = db.Accounts.Find(ActNo);

            if(Rec!=null)
            {
                db.Accounts.Remove(Rec);

                act.CustomerId = Rec.CustomerId;
                act.AccountTypeId = Rec.AccountTypeId;
                act.Balance = Rec.Balance;
                act.Branch = Rec.Branch;

                return act;
            }
            else
            {
                throw new Exception("Account not found");
            }
        }
        public AccountModel UpdateAccount(AccountModel UpAct)
        {
            Account act = new Account();
            act.CustomerId = UpAct.CustomerId;
            act.AccountTypeId = UpAct.AccountTypeId;
            act.Balance = UpAct.Balance;
            act.Branch = UpAct.Branch;

            try
            {
                if (UpAct != null)
                {
                    db.Entry(act).State = EntityState.Modified;
                    db.SaveChanges();

                    return UpAct;
                }
                else
                {
                    throw new Exception("Updation failed");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }         
        }
        public AccountModel ShowByAcctNo(int ActNum)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AccountModel> ShowAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
