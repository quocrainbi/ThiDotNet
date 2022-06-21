using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiDotNet.DTO;

namespace ThiDotNet.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        public static int TableWidth = 120;
        public static int TableHeight = 120;
        private TableDAO()
        {

        }
        public List<Table>  LoadTableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach(DataRow row in data.Rows)
            {
                Table table = new Table(row);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public bool UpdateStatusTable(int IdTable,string Status)
        {
            string query = String.Format("update TableFood set status = N'{0}' where id ={1}", Status, IdTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Table> SearchTableByName(string name)
        {
            List<Table> list = new List<Table>();
            string query = string.Format("select * from TableFood where dbo.GetUnsignString(Name) like  '%' +  dbo.GetUnsignString('{0}') +'%' and isdelete=0", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
        public bool AddTable(string name)
        {
            string query = String.Format("insert into TableFood values (N'{0}',N'Trống',0)",  name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int idtable, string name)
        {

            string query = String.Format("update TableFood set  name = N'{0}' where id = {1} ", name, idtable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int idtable)
        {
            string query = String.Format("update TableFood set isdelete = 1 where id = {0} ", idtable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
