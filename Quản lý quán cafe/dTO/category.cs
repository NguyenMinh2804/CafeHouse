using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_quán_cafe.dTO
{
    public class category
    {
        public category(string name, int id)
        {
            this.Id = id;
            this.Name = name;
        }
        public category(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = (string)row["name"].ToString();
        }

        private string name;
        private int id;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
