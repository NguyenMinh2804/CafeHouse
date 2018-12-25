using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class menuDAO
    {
        private static menuDAO instance;

        public static menuDAO Instance
        {
            get { if (instance == null) instance = new menuDAO(); return menuDAO.instance; }
            private set { menuDAO.instance = value; }
       
        }
        private menuDAO() { }
        public List<menu> getListMenu(int id)
        {
            List<menu> listMenu = new List<menu>();

            string query = "SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = " + id;
            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                menu menu = new menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
