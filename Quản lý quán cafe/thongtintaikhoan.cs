using Quản_lý_quán_cafe.dAO;
using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_quán_cafe
{
    public partial class thongtintaikhoan : Form
    {
        private account login;

        public account Login
        {
            get { return Login; }
            set { login = value; changeAccount(login); }
        }

        void changeAccount(account acc)
        {
            tbtendangnhap.Text = login.UserName;
            textBox1.Text = login.DisplayName;

        }
        void UpdateAccountInfo()
        {
            string displayName = textBox1.Text;
            string password = textBox2.Text;
            string newpass = textBox3.Text;
            string reenterPass = textBox4.Text;
            string userName = tbtendangnhap.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        public class AccountEvent : EventArgs
        {
            private account acc;

            public account Acc
            {
                get { return acc; }
                set { acc = value; }
            }

            public AccountEvent(account acc)
            {
                this.Acc = acc;
            }
        }

        public thongtintaikhoan(account acc)
        {

            InitializeComponent();
            login = acc;
        }

        private void bthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
}
