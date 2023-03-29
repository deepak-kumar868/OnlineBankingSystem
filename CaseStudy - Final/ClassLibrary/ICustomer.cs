using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using EntityLayer;

namespace DAL
{
    public interface ICustomer
    {
        public CustomerModel AddCustomer(CustomerModel cust);
        public CustomerModel DeleteCustomer(int CusId);
        public CustomerModel UpdateCustomer(CustomerModel UpdRec);
        public CustomerModel ShowByCustId(int CusId);
        public List<CustomerModel> ShowAllCustomers();
    }
}
