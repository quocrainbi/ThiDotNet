using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiDotNet.DTO;

namespace ThiDotNet.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private AccountDAO()
        { 
        }
        public bool Login(string username, string password)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public List<Account> SelectAccount( )
        {
            List<Account> list = new List<Account>();

            string query = "USP_SelectAccount ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }

            return list;
        }
        public bool ResetAccount(string username)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("USP_ResetPWd @@username",new object[] {username});
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteAccount @@username", new object[] { username });
            return result > 0;
        }

    }
}
