using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DALayer
{
    public interface IUser
    {
        public Task<UserModel> GetValidUser(UserModel user);
        public Task<CredentialModel> RegisterUser(CredentialModel NewUsr);
    }
}
