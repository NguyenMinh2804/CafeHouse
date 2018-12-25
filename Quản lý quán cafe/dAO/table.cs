using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    class tableDAO
    {
        private static tableDAO instance;

        internal static tableDAO Instance
        {
            get { if (instance == null) instance = new tableDAO();return tableDAO.instance; }
            private set { tableDAO.instance = value; }
        }
        private tableDAO()
        {

        }
        public static int widt = 90;
        public static int height = 90;
        public List<table> loadTable()
        {
            List<table> tableList = new List<table>();
            DataTable data = dataProvider.Instance.ExecuteQuery("exec  USP_GetTableList");
            foreach(DataRow item in data.Rows)
            {
                table table = new table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<table> loadTableabc()
        {
            List<table> tableList = new List<table>();
            DataTable data = dataProvider.Instance.ExecuteQuery("select * from tablefood");
            foreach (DataRow item in data.Rows)
            {
                table table = new table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool insertTable(string name)
        {
            string query = string.Format("insert into tablefood(name,status) values (N'{0}',N'Trống')", name);
            int result = dataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(string name,int id)
        {
            string query = string.Format("UPDATE tablefood SET name = N'{0}' WHERE id = {1}", name, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteTable(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete billinfo from bill,billinfo where bill.id=billinfo.idbill and idtable= " + id);
            BillDAO.Instance.deteleBillTable(id);
            string query = string.Format("delete tablefood where id = "+id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
      
    }
}
