using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CustomerDataService : ICustomer
    {
        private OnlineBankingContext db;

        public CustomerDataService(OnlineBankingContext db)
        {
            this.db = db;
        }


        public List<CustomerModel> ShowAllCustomers()
        {
            List<CustomerModel> cusList = new List<CustomerModel>();
            IEnumerable<Customer> cusList2;
            try
            {
                cusList2 = db.Customers.ToList();

                //code to copy data from data model to user model
                foreach (var d in cusList2)
                {
                    CustomerModel m = new CustomerModel();

                    m.CustomerId = d.CustomerId;
                    m.CustomerName = d.CustomerName;
                    m.CustomerAddress = d.CustomerAddress;
                    m.CustomerPhNo = d.CustomerPhNo;
                    m.CustomerAge = d.CustomerAge;
                    m.Dob = d.Dob;
                    cusList.Add(m);
                }
                return cusList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CustomerModel AddCustomer(CustomerModel NewCust)
        {
            Customer cus = new Customer();
            cus.CustomerName = NewCust.CustomerName;
            cus.CustomerAddress = NewCust.CustomerAddress;
            cus.CustomerPhNo = NewCust.CustomerPhNo;
            cus.CustomerAge = NewCust.CustomerAge;
            cus.Dob = NewCust.Dob;
            try
            {
                db.Customers.Add(cus);
                db.SaveChanges();


                IEnumerable<int> record = db.Customers.Where(c => c.CustomerName == NewCust.CustomerName &&
                                                    c.CustomerAddress == NewCust.CustomerAddress &&
                                                    c.CustomerPhNo == NewCust.CustomerPhNo &&
                                                    c.CustomerAge == NewCust.CustomerAge &&
                                                    c.Dob == NewCust.Dob
                                             ).ToList().Select(cus => cus.CustomerId);

                foreach (var ele in record)
                {
                    NewCust.CustomerId = (int)ele;
                }

                return NewCust;
            }
            catch(Exception e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                
                throw new Exception(e.Message);
            }
            
        }

        public CustomerModel DeleteCustomer(int CusId)
        {
            CustomerModel? cus = new CustomerModel();
            Customer? CRec;
            try
            {
                CRec = db.Customers.Find(CusId);
                if(CRec!=null)
                {
                    db.Customers.Remove(CRec);
                    db.SaveChanges();

                    cus.CustomerId = CRec.CustomerId;
                    cus.CustomerName = CRec.CustomerName;
                    cus.CustomerAddress = CRec.CustomerAddress;
                    cus.CustomerPhNo = CRec.CustomerPhNo;
                    cus.CustomerAge = CRec.CustomerAge;
                    cus.Dob = CRec.Dob;

                    return cus;
                }
                else
                {
                    throw new Exception("Cannot find Customer");
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CustomerModel ShowByCustId(int CusId)
        {
            CustomerModel? cus = new CustomerModel();
            Customer? CRec;
            try
            {
                CRec = db.Customers.Find(CusId);
                if(CRec!=null)
                {
                    cus.CustomerId = CRec.CustomerId;
                    cus.CustomerName = CRec.CustomerName;
                    cus.CustomerAddress = CRec.CustomerAddress;
                    cus.CustomerPhNo = CRec.CustomerPhNo;
                    cus.CustomerAge = CRec.CustomerAge;
                    cus.Dob = CRec.Dob;

                    return cus;
                }
                else
                {
                    throw new Exception("Customer Record not Found");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public CustomerModel UpdateCustomer(CustomerModel UpdRec)
        {
            Customer rec = new Customer();
            rec.CustomerId = UpdRec.CustomerId;
            rec.CustomerName = UpdRec.CustomerName;
            rec.CustomerAddress = UpdRec.CustomerAddress;
            rec.CustomerPhNo = UpdRec.CustomerPhNo;
            rec.CustomerAge = UpdRec.CustomerAge;
            rec.Dob = UpdRec.Dob;

            try
            {
                if(UpdRec!=null)
                {
                    db.Entry(rec).State = EntityState.Modified;
                    db.SaveChanges();
                    return UpdRec;
                }
                else
                {
                    throw new Exception("Updation failed");
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
