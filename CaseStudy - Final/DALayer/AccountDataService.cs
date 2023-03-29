using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;



namespace DALayer
{
    public class AccountDataService :IAccount
    {
        private OnlineBankingSystemContext db;

        public AccountDataService(OnlineBankingSystemContext db)
        {
            this.db = db;
        }
       
        public async Task<AccountModel> AddAccount(AccountModel NewAct)
        {
            Account act = new Account();
            act.CustomerId = NewAct.CustomerId;
            act.CustomerName = NewAct.CustomerName;
            act.CustomerAddress = NewAct.CustomerAddress;
            act.CustomerPhNo = NewAct.CustomerPhNo;
            act.CustomerAge = NewAct.CustomerAge;
            act.Dob = NewAct.Dob;
            act.AccountNo = NewAct.AccountNo;
            act.AccountTypeId = NewAct.AccountTypeId;
            act.Balance = NewAct.Balance;
            act.Branch = NewAct.Branch;
            act.CustomerType = NewAct.CustomerType;


            try
            {
                await db.Accounts.AddAsync(act);
                db.SaveChanges();

                return NewAct;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<AccountModel> DeleteAccount(int cusId)
        {
             AccountModel act = new AccountModel();
              var Rec = await db.Accounts.FindAsync(cusId);

            if(Rec!=null)
            {
                db.Accounts.Remove(Rec);
                db.SaveChanges();

                act.CustomerId = Rec.CustomerId;
                act.CustomerName = Rec.CustomerName;
                act.CustomerAddress = Rec.CustomerAddress;
                act.CustomerPhNo = Rec.CustomerPhNo;
                act.CustomerAge = Rec.CustomerAge;
                act.Dob = Rec.Dob;
                act.AccountNo = Rec.AccountNo;
                act.AccountTypeId = Rec.AccountTypeId;
                act.Balance = Rec.Balance;
                act.Branch = Rec.Branch;
                act.CustomerType = Rec.CustomerType;

                return act;
            }
            else
            {
                throw new Exception("Account not found");
            }
        }
        public async Task<AccountModel> UpdateAccount(AccountModel UpdAct)
        {
            try
            {
                var act = await db.Accounts.FindAsync(UpdAct.CustomerId);
                if (act != null)
                {
                    act.CustomerId = UpdAct.CustomerId;
                    act.CustomerName = UpdAct.CustomerName;
                    act.CustomerAddress = UpdAct.CustomerAddress;
                    act.CustomerPhNo = UpdAct.CustomerPhNo;
                    act.CustomerAge = UpdAct.CustomerAge;
                    act.Dob = UpdAct.Dob;
                    act.AccountNo = UpdAct.AccountNo;
                    act.AccountTypeId = UpdAct.AccountTypeId;
                    act.Balance = UpdAct.Balance;
                    act.Branch = UpdAct.Branch;
                    act.CustomerType = UpdAct.CustomerType;

                    db.Entry(act).State = EntityState.Modified;
                    db.SaveChanges();

                    return UpdAct;
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


        public async Task<AccountModel> ShowByAcctNo(int cusId)
        {
            AccountModel act = new AccountModel();

            var Rec =await db.Accounts.FindAsync(cusId);

            if(Rec!=null)
            {

                act.CustomerId = Rec.CustomerId;
                act.CustomerName = Rec.CustomerName;
                act.CustomerAddress = Rec.CustomerAddress;
                act.CustomerPhNo = Rec.CustomerPhNo;
                act.CustomerAge = Rec.CustomerAge;
                act.Dob = Rec.Dob;
                act.AccountNo = Rec.AccountNo;
                act.AccountTypeId = Rec.AccountTypeId;
                act.Balance = Rec.Balance;
                act.Branch = Rec.Branch;
                act.CustomerType = Rec.CustomerType;

                return act;
            }
            else
            {
                throw new Exception("Account Not Found");
            }

        }
        public async Task<List<AccountModel>> ShowAllAccounts()
        {
            List<AccountModel> acctlst = new List<AccountModel>();
            IEnumerable<Account> lst;

            try
            {
                lst =await db.Accounts.ToListAsync();

                foreach(var Rec in lst)
                {
                    AccountModel act = new AccountModel();


                    act.CustomerId = Rec.CustomerId;
                    act.CustomerName = Rec.CustomerName;
                    act.CustomerAddress = Rec.CustomerAddress;
                    act.CustomerPhNo = Rec.CustomerPhNo;
                    act.CustomerAge = Rec.CustomerAge;
                    act.Dob = Rec.Dob;
                    act.AccountNo = Rec.AccountNo;
                    act.AccountTypeId = Rec.AccountTypeId;
                    act.Balance = Rec.Balance;
                    act.Branch = Rec.Branch;
                    act.CustomerType = Rec.CustomerType;

                    acctlst.Add(act);
                }
                return acctlst;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
