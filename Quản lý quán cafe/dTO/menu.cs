using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dTO
{
    public class menu
    {   
        public menu (string foodname,int cout,float price,float total=0 )
        {
            this.FoodName = foodname;
            this.Cout = cout;
            this.Price = price;
            this.Total = total;
        }

        public menu(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.Cout = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Total = (float)Convert.ToDouble(row["totalPrice"]);
        }
        private string foodName;
        private int cout;
        private float price;
        private float total;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Cout { get => cout; set => cout = value; }
        public float Price { get => price; set => price = value; }
        public float Total { get => total; set => total = value; }
    }
}
