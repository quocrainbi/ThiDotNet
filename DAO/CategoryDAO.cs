using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiDotNet.DTO;

namespace ThiDotNet.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from FoodCategory where isdelete = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public bool AddCategory(string name)
        {
            string query = String.Format("insert into FoodCategory values (N'{0}',0)", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Update FoodCategory set isdelete = 1 where id =" +id);
            return result > 0;
        }
        public bool UpdateCategory(int id, string name)
        {
            string query = String.Format("update FoodCategory set name = N'{0}' where id = {1} ", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Category> SearchCategoryByName(string Name)
        {
            List<Category> list = new List<Category>();
            string query = string.Format("select * from FoodCategory where dbo.GetUnsignString(Name) like '%'+ dbo.GetUnsignString('{0}') + '%' and isdelete = 0", Name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
    }
}
