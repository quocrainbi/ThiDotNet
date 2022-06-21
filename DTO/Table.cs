using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiDotNet.DTO
{
    public class Table
    {
        public Table(int id, string name, string status,int isdelete)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Isdelete = isdelete;

        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
            this.Isdelete = (int)row["isdelete"];
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
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
