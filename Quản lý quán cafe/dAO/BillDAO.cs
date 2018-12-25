using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO();return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        public int getBillID(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("select * from Bill where idTable =" + id + " and status=0");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void insertBill(int id)
        {
            dataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[]{id});
        }
        public int getMaxIDBill()
        {
            try
            {
                return (int)dataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void chekout(int id,float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1,totalPrice = " + totalPrice + " WHERE id = " + id;
            dataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable getListByDate(DateTime checkin, DateTime checkout)
        {
            return dataProvider.Instance.ExecuteQuery("exec USP_GETLISTBILLBYDate @checkIn , @checkOut", new object[] { checkin, checkout });
        }
        public void deteleBillTable(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete bill where idtable=" + id);
        }
    }
}
