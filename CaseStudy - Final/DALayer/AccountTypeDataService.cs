using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DALayer;
using DALayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DALayer
{
    public class AccountTypeDataService : IAccountType
    {
        private OnlineBankingSystemContext db;
        public AccountTypeDataService(OnlineBankingSystemContext db)
        {
            this.db = db;
        }
        public async Task<AccountTypeModel> AddNewAcctType(AccountTypeModel AddRec)
        {
            AccountType a = new AccountType();
            a.AccountTyp = AddRec.AccountTyp;
            a.AccountTypeId = AddRec.AccountTypeId;
            a.Interest = AddRec.Interest;
            a.MinBalance = AddRec.MinBalance;
            a.TransactionLimit = AddRec.TransactionLimit;


            try
            {
                await db.AccountTypes.AddAsync(a);
                db.SaveChanges();

                return AddRec;
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
        public async Task<AccountTypeModel> DeleteAcctType(int ActTypeId)
        {
            AccountTypeModel? a = new AccountTypeModel();
            AccountType? ActRec;
            try
            {
                ActRec = await db.AccountTypes.FindAsync(ActTypeId);
                if (ActRec != null)
                {
                    db.AccountTypes.Remove(ActRec);
                    db.SaveChanges();

                    a.AccountTyp = ActRec.AccountTyp;
                    a.AccountTypeId = ActRec.AccountTypeId;
                    a.Interest = ActRec.Interest;
                    a.MinBalance = ActRec.MinBalance;
                    a.TransactionLimit = ActRec.TransactionLimit;

                    return a;
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
        public async Task<AccountTypeModel> GetActTypeServices(int ActTypId)
        {
            AccountTypeModel? a = new AccountTypeModel();
            AccountType? ActRec;
            try
            {
                ActRec = await db.AccountTypes.FindAsync(ActTypId);
                if (ActRec != null)
                {
                    a.AccountTyp = ActRec.AccountTyp;
                    a.AccountTypeId = ActRec.AccountTypeId;
                    a.Interest = ActRec.Interest;
                    a.MinBalance = ActRec.MinBalance;
                    a.TransactionLimit = ActRec.TransactionLimit;

                    return a;
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
        public async Task<AccountTypeModel> UpdateAcctTypeDetails(AccountTypeModel UpdRec)
        {
            try
            {
                var a = await db.AccountTypes.FindAsync(UpdRec.AccountTypeId);
                if (a != null)
                {
                    a.AccountTyp = UpdRec.AccountTyp;
                    a.AccountTypeId = UpdRec.AccountTypeId;
                    a.Interest = UpdRec.Interest;
                    a.MinBalance = UpdRec.MinBalance;
                    a.TransactionLimit = UpdRec.TransactionLimit;

                    db.Entry(a).State = EntityState.Modified;
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
        public async Task<List<AccountTypeModel>> ShowAllAccountTypes()
        {
            List<AccountTypeModel> lst = new List<AccountTypeModel>();
            IEnumerable<AccountType> act;
            try
            {
                act = await db.AccountTypes.ToListAsync();

                //code to copy data from data model to user model
                foreach (var Rec in act)
                {
                    AccountTypeModel a = new AccountTypeModel();
                    a.AccountTyp = Rec.AccountTyp;
                    a.AccountTypeId = Rec.AccountTypeId;
                    a.Interest = Rec.Interest;
                    a.MinBalance =Rec.MinBalance;
                    a.TransactionLimit = Rec.TransactionLimit;
                    lst.Add(a);
                }
                return lst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
