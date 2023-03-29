using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DALayer;
using DALayer.Models;
using System.Threading.Tasks;

namespace DALayer
{
    public interface IAccountType
    {
        public Task<AccountTypeModel> AddNewAcctType(AccountTypeModel AddRec);
        public Task<AccountTypeModel> DeleteAcctType(int ActTypeId);
        public Task<AccountTypeModel> GetActTypeServices(int ActTypId);
        public Task<AccountTypeModel> UpdateAcctTypeDetails(AccountTypeModel UpdRec);
        public Task<List<AccountTypeModel>> ShowAllAccountTypes();
    }
}
