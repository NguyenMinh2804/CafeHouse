using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dTO
{
    public class account
    {
        public account(string username, string displayname, int type, string password = null)
        {
            this.UserName = username;
            this.DisplayName = displayname;
            this.Type = type;
            this.Password = password;
        }
        public account(DataRow row)
        {
            this.UserName = row["username"].ToString();
            this.DisplayName =row["displayname"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["password"].ToString();
        }

        private int type;
        private string userName;
        private string displayName;
        private string password;

        public int Type { get => type; set => type = value; }
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
    }
}
