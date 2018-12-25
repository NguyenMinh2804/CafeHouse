using Quản_lý_quán_cafe.dTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

       public List<BillInfo > GetListBillInfo (int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo where idBill = " +id); 

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void insertBillInfo(int idBill,int idfood,int count)
        {
            dataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idfood, count });
        }
        public void deleteBillInfoByFoodID(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete billInfo where idfood = " + id);
        }
        public void deleteBillInfoByBillID(int id)
        {
            dataProvider.Instance.ExecuteQuery("delete billinfo where idbill=" + id);
        }
        
    }
}
