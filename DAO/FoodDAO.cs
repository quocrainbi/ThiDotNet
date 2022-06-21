using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiDotNet.DTO;

namespace ThiDotNet.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "USP_GetFoodListById @id ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {id});

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public List<Food> LoadFood()
        {
            List<Food> list = new List<Food>();

            string query = "USP_GetFoodList";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public bool AddFood(string name, int idcategory, int price)
        {
            string query = String.Format("insert into Food values (N'{0}',{1},{2},0)", name, idcategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(int idfood, int idcate, string name, int price)
        {

            string query = String.Format("update Food set name = N'{0}', idCategory = {1} , price = {2}  where id = {3} ", name, idcate, price, idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int idfood)
        {

            string query = String.Format("update Food set isdelete =1 where id = "+idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Food> SearchFoodtByName(string Name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("select * from Food where dbo.GetUnsignString(Name) like '%'+ dbo.GetUnsignString('{0}') + '%' and isdelete = 0", Name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}
