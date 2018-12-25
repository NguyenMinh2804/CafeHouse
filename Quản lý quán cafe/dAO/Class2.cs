using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class AccountDAO
    {
        
            private static AccountDAO instance;

         public static AccountDAO Instance
            {
                get { if (instance == null) instance = new AccountDAO(); return instance; }
                private set { instance = value; }
            }

            private AccountDAO() { }

         public bool Login(string userName, string passWord)
            {
                string query = "USP_Login @userName , @passWord";

                DataTable result = dataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

                return result.Rows.Count > 0;
            }
            
        public account GetAccountByUserName(string userName)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new account(item);
            }
            return null;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = dataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return dataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
        }

        public bool insertAccount(string username,string displayName, int type)
        {
            string query = string.Format("insert into account(username,displayName,type) values (N'{0}',N'{1}',{2} )", username, displayName, type);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string displayName, int type)
        {
            string query = string.Format("UPDATE account SET displayname = N'{1}', type = {2} WHERE  username= N'{0}'", username, displayName, type);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("Delete account where username = N'{0}'", username);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool resetPassword(string username)
        {
            string query = string.Format("update account set password=N'0'where username = N'{0}'", username);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
