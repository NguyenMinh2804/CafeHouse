using Quản_lý_quán_cafe.dAO;
using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_quán_cafe
{
    public partial class Form2 : Form
    {
        private account login;

        public account Login
        {
            get { return Login; }
            set { login = value; }
        }
        

        public Form2(account acc)
        {
            this.login = acc;
            InitializeComponent();
            loadTable();
            loadCategory();
            if(login.Type==1)
            {
                aminToolStripMenuItem.Enabled = true;
            }
            else
            {
                aminToolStripMenuItem.Enabled = false;
            }
        }
 
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongtinadmin f=new thongtinadmin();
            f.loginAccount = this.login;
            f.loginAccount = login;
            f.InsertFood += f_InsertFood;
            f.DeleteFood += f_DeleteFood;
            f.UpdateFood += f_UpdateFood;
            f.ShowDialog();
        }

        void f_UpdateFood(object sender, EventArgs e)
        {
            loadFood((comboBox1.SelectedItem as category).Id );
            if (listView1.Tag != null)
                showBill((listView1.Tag as table).ID);
        }

        void f_DeleteFood(object sender, EventArgs e)
        {
            loadFood((comboBox1.SelectedItem as category).Id);
            if (listView1.Tag != null)
                showBill((listView1.Tag as table).ID);
            loadTable();
        }

        void f_InsertFood(object sender, EventArgs e)
        {
            loadFood((comboBox1.SelectedItem as category).Id);
            if (listView1.Tag != null)
                showBill((listView1.Tag as table).ID);
        }

        void loadCategory()
        {
            List<category> listCategory = categoryDAO.Instance.getlistcategory();
            comboBox1.DataSource = listCategory;
            comboBox1.DisplayMember = "name";
        }
        void loadFood(int id)
        {
            List<food> listFood = foodDAO.Instance.getlistfood(id);
            comboBox2.DataSource = listFood;
            comboBox2.DisplayMember = "name";
        }
        void loadTable()
        {
            flpnban.Controls.Clear();
            List<table> tablelist = tableDAO.Instance.loadTable();
            foreach(table item in tablelist)
            {
                Button btn = new Button() { Width=tableDAO.widt,Height=tableDAO.height};
                btn.Click += Btn_Click;
                btn.Tag = item;
                btn.Text = item.Name + Environment.NewLine + item.Status;
                flpnban.Controls.Add(btn);
                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightGray;
                        break;
                    default:
                        btn.BackColor = Color.Green;
                        break;
                }
               

            }
        }
        void showBill(int id)
        {
            listView1.Items.Clear();
            List<Quản_lý_quán_cafe.dTO.menu> listBillInfo = menuDAO.Instance.getListMenu(id);
            float totalprice=0;
            foreach (Quản_lý_quán_cafe.dTO.menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Cout.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Total.ToString());
                totalprice = totalprice + item.Total;
                listView1.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");      
            tbtotalprice.Text = totalprice.ToString("c",culture);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           int tableID = ((sender as Button).Tag as table).ID;
            listView1.Tag = (sender as Button).Tag;
            showBill(tableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongtintaikhoan t = new thongtintaikhoan( login );
            t.ShowDialog();
        }

        private void aminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongtinadmin a = new thongtinadmin();
            a.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null )
            {
                return;
            }
            category selected = cb.SelectedItem as category ;
            id = selected.Id;
            loadFood( id);
        }

        private void btthemmon_Click(object sender, EventArgs e)
        {
            table table = listView1.Tag as table;
            int idBill = BillDAO.Instance.getBillID(table.ID);
            int foodID = (comboBox2.SelectedItem as food).Id;
            int count = (int)numericUpDown1.Value;
            if (idBill ==-1)
            {
                BillDAO.Instance.insertBill(table.ID);
                BillInfoDAO.Instance.insertBillInfo(BillDAO.Instance.getMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.insertBillInfo(idBill, foodID, count);
            }
            showBill(table.ID);
            loadTable();
        }

        private void btthanhtoan_Click(object sender, EventArgs e)
        {
            table table = listView1.Tag as table;
            int idBill = BillDAO.Instance.getBillID(table.ID);
            double totalprice = Convert.ToDouble(tbtotalprice.Text.Split(',')[0]);
            if(idBill != -1)
            {
                if(MessageBox.Show("Bạn có muốn thanh toán cho bàn " +table.Name,"Thông báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.chekout(idBill,(float)totalprice);
                    showBill(table.ID);
                    loadTable();
                }
            }
        }
        
    }
}
