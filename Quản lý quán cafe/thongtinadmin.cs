using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quản_lý_quán_cafe.dAO;
using Quản_lý_quán_cafe.dTO;

namespace Quản_lý_quán_cafe
{
    public partial class thongtinadmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource category = new BindingSource();
        BindingSource table = new BindingSource();
        public account loginAccount;
        public thongtinadmin()
        {
            InitializeComponent();
            dtgvthucan.DataSource = foodList;
            dtgvtaikhoan.DataSource = accountList;
            dtgvdm.DataSource = category;
            dataGridView1.DataSource = table;
            loadlistbydate(dateTimePicker1.Value, dateTimePicker2.Value);
            loadListFood();
            loadCategory(comboBox1);
            LoadAccount();
            foodbinding();
            categoryBinding();
            AddAccountBinding();
            loadlistCategory();
            loadTableList();
            tableBinding();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvthucan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        void loadlistbydate(DateTime checkin, DateTime checkout)
        {
            dtgvdoanhthu.DataSource = BillDAO.Instance.getListByDate(checkin, checkout);
        }

        private void btthongke_Click(object sender, EventArgs e)
        {
            loadlistbydate(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        void loadListFood()
        {

            foodList.DataSource = foodDAO.Instance.getlistfoodabc();

        }

        private void btxem_Click(object sender, EventArgs e)
        {
            loadListFood();
           
        }
        public void foodbinding()
        {
            loadListFood();
            textBox1.DataBindings.Add(new Binding("Text", dtgvthucan.DataSource, "name", true, DataSourceUpdateMode.Never));
            txid.DataBindings.Add(new Binding("Text", dtgvthucan.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("value", dtgvthucan.DataSource, "price", true, DataSourceUpdateMode.Never));
        }
        public void categoryBinding()
        {
            tbiddm.DataBindings.Add(new Binding("text", dtgvdm.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbtendm.DataBindings.Add(new Binding("text", dtgvdm.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        public void tableBinding()
        {
            tbbanan.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbtenbanan.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "name", true, DataSourceUpdateMode.Never));
            cbbtrangthai.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "status", true, DataSourceUpdateMode.Never));
        }
        void loadCategory(ComboBox cb)
        {
            cb.DataSource = categoryDAO.Instance.getlistcategory();
            cb.DisplayMember = "name";
        }

        private void txid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvthucan.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvthucan.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    category cateogory = categoryDAO.Instance.getCategoryByID(id);

                    comboBox1.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (category item in comboBox1.Items)
                    {
                        if (item.Id == cateogory.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    comboBox1.SelectedIndex = index;
                }
            }
            catch
            {

            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int idcategory = (comboBox1.SelectedItem as category).Id;
            float price = (float)numericUpDown1.Value;
            if(foodDAO.Instance.insertFood(name,idcategory,price))
            {
                MessageBox.Show("Thêm món thành công");
                loadListFood();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm món");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int categoryID = (comboBox1.SelectedItem as category).Id;
            float price = (float)numericUpDown1.Value;
            int id = Convert.ToInt32(txid.Text);

            if (foodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                loadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txid.Text);

            if (foodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                loadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void bttim_Click(object sender, EventArgs e)
        {
           foodList.DataSource=searchFoodByName(tbtim.Text);
        }
        List<food> searchFoodByName(string name)
        {
            List<food> list = foodDAO.Instance.searchFood(name);
            return list;
        }
        void AddAccountBinding()
        {
           textBox3.DataBindings.Add(new Binding("Text", dtgvtaikhoan.DataSource, "UserName", true, DataSourceUpdateMode.Never));
           textBox2.DataBindings.Add(new Binding("Text", dtgvtaikhoan.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown2.DataBindings.Add(new Binding("value",dtgvtaikhoan.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void addAccount(string name,string display,int type)
        {
            if(AccountDAO.Instance.insertAccount(name,display,type))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            LoadAccount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string display = textBox2.Text;
            int type = (int)numericUpDown2.Value;
            addAccount(name, display, type);
        }
        void updateAccount(string name,string display,int type)
        {
            if(AccountDAO.Instance.UpdateAccount(name,display,type))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            LoadAccount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string display = textBox2.Text;
            int type = (int)numericUpDown2.Value;
            updateAccount(name, display, type);
        }
        void deleteAccount(string name)
        {
          /*  if(loginAccount.UserName==name)
            {
                MessageBox.Show("Tài khoản đang hoạt động không thể xóa");
                return;
            }*/
            
            if (AccountDAO.Instance.DeleteAccount(name))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhật thất bại");
            }
            LoadAccount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            deleteAccount(name);
        }
        void resetPass(string name)
        {
            if (AccountDAO.Instance.resetPassword(name))
            {
                MessageBox.Show("Reset thành công");
            }
            else
            {
                MessageBox.Show("Reset thất bại");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            resetPass(name);
        }

        private void btxemdm_Click(object sender, EventArgs e)
        {
            loadlistCategory();
        }
        void loadlistCategory()
        {
            category.DataSource = categoryDAO.Instance.getlistcategoryabc();
        }

        private void btthemdm_Click(object sender, EventArgs e)
        {
            string name = tbtendm.Text;
            if(categoryDAO.Instance.insertCategory(name))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadlistCategory();
           
        }

        private void btxoadm_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbiddm.Text);

            if (categoryDAO.Instance.DeleteFood(ID))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            loadlistCategory();
            loadListFood();

        }

        private void btsuadm_Click(object sender, EventArgs e)
        {
            string name = tbtendm.Text;
            int ID = Convert.ToInt32(tbiddm.Text);
            if (categoryDAO.Instance.UpdateCategory(ID,name))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            loadlistCategory();
            loadListFood();
        }

        private void btxemba_Click(object sender, EventArgs e)
        {
            loadTableList();
        }
        void loadTableList()
        {
           table.DataSource= tableDAO.Instance.loadTableabc();
        }

        private void bthemba_Click(object sender, EventArgs e)
        {
            string name = tbtenbanan.Text;
            if (tableDAO.Instance.insertTable(name))
            {
                MessageBox.Show("Thêm thành công");
                loadTableList();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadTableList();
        }

        private void btsuaba_Click(object sender, EventArgs e)
        {
            string name = tbtenbanan.Text;
            int id = Convert.ToInt32(tbbanan.Text);
            if (tableDAO.Instance.UpdateTable(name,id))
            {
                MessageBox.Show("Cập nhật thành công");
                loadTableList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btxoaba_Click(object sender, EventArgs e)
        {
            int id= Convert.ToInt32(tbbanan.Text);
            if(tableDAO.Instance.deleteTable(id))
            {
                MessageBox.Show("Cập nhật thành công");
                loadTableList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            loadTableList();
        }
    } 
}
