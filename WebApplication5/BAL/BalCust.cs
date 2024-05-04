using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using WebApplication5.DAL;
using System.Security.Cryptography;

namespace WebApplication5.BAL
{
    public class BalCust
    {
        public int InsertCust(Customer cust)
        {
            try
            {
               DalCust obj= new DalCust();
               return obj.InsertCust(cust);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateCust(Customer cust)
        {
            try
            {
                DalCust obj = new DalCust();
                return obj.UpdateCust(cust);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteCust(int cid)
        {
            try
            {
                DalCust obj = new DalCust();
                return obj.DeleteCust(cid);
            }
            catch
            {
                return 0;
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                DalCust obj = new DalCust();
                return obj.GetCustomers();
            }
            catch
            {
                return null;
            }
        }

        public int CheckDuplicate(string cemail)
        {
            try
            {
                DalCust obj = new DalCust();
                return obj.CheckDuplicate(cemail);
            }
            catch
            {
                return -1;
            }
        }
    }
}