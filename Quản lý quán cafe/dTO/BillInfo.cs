﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dTO
{
    public class BillInfo
    {
        public BillInfo(int id,int idBill, int idFood,int count)
        {
            this.ID = id;
            this.IDBill = idBill;
            this.IDFood = idFood;
            this.Count = count;
        }
        public BillInfo (DataRow row)
        {
            this.ID =(int)row ["id"];
            this.IDBill =(int)row ["idBill"];
            this.IDFood = (int) row ["idFood"];
            this.Count = (int) row ["count"];
        }
        private int iD;
        private int iDBill;
        private int iDFood;
        private int count;
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int Count { get => count; set => count = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
