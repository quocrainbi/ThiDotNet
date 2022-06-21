using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiDotNet.DTO
{
    public class Category
    {
        public Category(int id, string name,int isdelete)
        {
            this.ID = id;
            this.Name = name;
            this.Isdelete = isdelete;
        }

        public Category(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Isdelete = (int)row["isdelete"];
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int isdelete;
        public int Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }
    }
}
