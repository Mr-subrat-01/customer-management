using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication5;
using Dapper;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WebApplication5.DAL
{
    public class DalCust
    {
        public SqlConnection con;
        
        public DalCust()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            con.Open();
        }

        public int InsertCust(Customer cust)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@custEmail", cust.custEmail);
                parm.Add("@custName", cust.custName);
                parm.Add("@custAdd", cust.custAdd);
                parm.Add("@custPhone", cust.custPhone);
                parm.Add("@operation", "INSERT");
                int r = con.Execute("sp_customer_operation", parm, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@custId", cust.custId);
                parm.Add("@custEmail", cust.custEmail);
                parm.Add("@custName", cust.custName);
                parm.Add("@custAdd", cust.custAdd);
                parm.Add("@custPhone", cust.custPhone);
                parm.Add("@operation", "UPDATE");
                int r = con.Execute("sp_customer_operation", parm, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@custId", cid);
                parm.Add("@operation", "DELETE");
                int r = con.Execute("sp_customer_operation", parm, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@operation", "SELECT");
                return con.Query<Customer>("sp_customer_operation",parm,commandType:CommandType.StoredProcedure).ToList();
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@operation", "CHECK-DUPLICATE");
                parm.Add("@custEmail", cemail);
                List<Customer> list = con.Query("sp_customer_operation", parm, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();
                if (list.Count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}