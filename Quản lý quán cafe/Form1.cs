using Quản_lý_quán_cafe.dAO;
using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_quán_cafe
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }

        private void btdangnhap_Click(object sender, EventArgs e)
        {
            string userName = tbtendangnhap.Text;
            string passWord = tbmatkhau.Text;
            if (Login(userName, passWord))
            {
                account login = AccountDAO.Instance.GetAccountByUserName(userName);
                Form2 f = new Form2(login);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình ?","Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
