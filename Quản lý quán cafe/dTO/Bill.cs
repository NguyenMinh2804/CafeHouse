using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dTO
{
    public class Bill
    {
        public Bill(int id,DateTime checkin, DateTime checkout, int status)
        {
            this.ID = id;
            this.DateCheckIn = checkin;
            this.DateCheckOut = checkout;
            this.status = status;
        } 
        public Bill (DataRow row)
        {
            this.ID = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row ["dateCheckIn"];
            var dateCheckTemp = row["dateCheckOut"];
            if(dateCheckTemp.ToString() !="")
            {
                this.DateCheckOut = (DateTime?)dateCheckTemp;
            }
            this.Status = (int) row["status"];
        }
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
