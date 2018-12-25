using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class foodDAO
    {
        private static foodDAO instance;

        public static foodDAO Instance
        {
            get { if (instance == null) instance = new foodDAO(); return foodDAO.instance; }
            private set { foodDAO.instance = value; }

        }
        private foodDAO() { }
        public List<food> getlistfood(int id)
        {
            List<food> list = new List<food>();
            string query = "select * from Food where idCategory = " + id;

            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                food food = new food(item);
                list.Add(food);
            }
            return list;

        }
        public List<food> getlistfoodabc()
        {
            List<food> list = new List<food>();
            string query = "select * from Food";

            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                food food = new food(item);
                list.Add(food);
            }
            return list;

        }

        public List<food> searchFood(string name)
        {

            List<food> list = new List<food>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                food food = new food(item);
                list.Add(food);
            }
            return list;
        }
        public bool insertFood(string name,int id,float price)
        {
            string query = string.Format("insert into food(name,idCategory,price) values (N'{0}',{1},{2} )", name, id, price);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result >0;
        }
        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.deleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void deletefoodByIDCategory(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete food where idcategory= " + id);
        }
    }
}
