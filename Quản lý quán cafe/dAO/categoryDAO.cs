using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class categoryDAO
    {
        private static categoryDAO instance;
        public static categoryDAO Instance
        {
            get { if (instance == null) instance = new categoryDAO(); return categoryDAO.instance; }
            private set { categoryDAO.instance = value; }
        }
        private categoryDAO() { }
        public List<category> getlistcategory()
        {
            List<category> list = new List<dTO.category>();
            string query = "select * from FoodCategory";
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category category = new category(item);
                list.Add(category);
            }
            return list;

        }
        public category getCategoryByID(int id)

        {
            category category = null;
            string query = "select * from FoodCategory where id= "+id;
            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new category(item);
                return category;
            }

            return category;
        }
        public List<category> getlistcategoryabc()
        {
            List<category> list = new List<category>();
            string query = "select * from foodcategory";

            DataTable data = dataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category category= new category(item);
                list.Add(category);
            }
            return list;

        }
        public bool insertCategory(string name)
        {
            string query = string.Format("insert into foodcategory(name) values (N'{0}')", name);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategory(int id,string name)
        {
            string query = string.Format("UPDATE foodcategory SET name = N'{0}'WHERE id = {1}", name, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete BillInfo from BillInfo,Food,FoodCategory where BillInfo.idFood=Food.id and Food.idCategory=FoodCategory.id and idCategory=" + id);
            foodDAO.Instance.deletefoodByIDCategory(id);

            string query = string.Format("Delete foodcategory where id = "+ id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
