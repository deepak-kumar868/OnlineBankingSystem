using System;
using EntityLayer;
using DALayer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DALayer
{
    public class UserLoginDataService : IUser
    {
        private OnlineBankingSystemContext db;
        public UserLoginDataService(OnlineBankingSystemContext db)
        {
            this.db = db;
        }
        public async Task<UserModel> GetValidUser(UserModel user)
        {

            UserModel udet = new UserModel();

            try
            {
                var validuser =await db.UserCredentials.Where(c => c.UserName == user.UserName
                                && c.Password == user.Password).SingleOrDefaultAsync();
                if (validuser != null)
                {
                    udet.UserName = validuser.UserName;
                    udet.Password = validuser.Password;
                    udet.Role = validuser.Role;
                    return udet;
                }
                else
                {
                    throw new Exception("Invalid Username or Password");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public async Task<CredentialModel> RegisterUser(CredentialModel NewUsr)
        {
            UserCredential NewRec = new UserCredential();
            NewRec.UserName = NewUsr.UserName;
            NewRec.Password = NewUsr.Password;
            NewRec.Role = NewUsr.Role;
            NewRec.AccountNo = NewUsr.AccountNo;
            NewRec.MobileNo = NewUsr.MobileNo;
            try
            {
                if(NewUsr.Password==NewUsr.ConfirmPassword)
                {
                    await db.UserCredentials.AddAsync(NewRec);
                    int status = db.SaveChanges();

                    if (status > 0)
                    {
                        return NewUsr;
                    }
                    else
                    {
                        throw new Exception("Insertion failed");
                    }
                }
                else
                {
                    throw new Exception("Password and Confirm Password must be same");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
