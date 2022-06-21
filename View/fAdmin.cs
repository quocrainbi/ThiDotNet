using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThiDotNet.DAO;
using ThiDotNet.DTO;

namespace ThiDotNet.View
{
    public partial class fAdmin : Form
    {
        BindingSource BdAccount = new BindingSource();
        BindingSource BdFood = new BindingSource();
        BindingSource BdCategory = new BindingSource();
        BindingSource BdTableFood = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            LoadBindingDgv();
            Load();
            LoadBinding();
        }
        #region Method
        void Load()
        {
            LoadFood();
            LoadCategory();
            LoadTableFood();
            LoadAccount();
            LoadCbbCate();



        }
        void LoadBinding()
        {
            AddFoodBiding();
            AddCategoryBiding();
            AddTableBinding();
            AddAccountBinding();
        }
        void LoadBindingDgv()
        {
            dgvFood.DataSource = BdFood;
            dgvCategory.DataSource = BdCategory;
            dgvTable.DataSource = BdTableFood;
            dgvAccount.DataSource = BdAccount;
        }
        void AddFoodBiding()
        {
            txbFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbPriceFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void AddCategoryBiding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbNameTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            txbUserNameAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbPwdAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            txbDisplayNameAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txbTypeAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadFood()
        {
            BdFood.DataSource = FoodDAO.Instance.LoadFood();
            dgvFood.Columns["Isdelete"].Visible = false;
        }
        void LoadCategory()
        {
            BdCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            dgvCategory.Columns["Isdelete"].Visible = false;
        }
        void LoadTableFood()
        {
            BdTableFood.DataSource = TableDAO.Instance.LoadTableList();
            dgvTable.Columns["Isdelete"].Visible = false;
        }
        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkin, checkout);
        }
        void LoadAccount()
        {
            BdAccount.DataSource = AccountDAO.Instance.SelectAccount();
            dgvAccount.Columns["Isdelete"].Visible = false;
        }
        void LoadCbbCate()
        {
            cbCategoryAdmin.DataSource = CategoryDAO.Instance.GetListCategory();
            cbCategoryAdmin.DisplayMember = "Name";
        }

        #endregion
        #region EventFood
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbNameFood.Text;
            int categoryiD = (cbCategoryAdmin.SelectedItem as Category).ID;
            int price = Convert.ToInt32(txbPriceFood.Text);
            if (FoodDAO.Instance.AddFood(name, categoryiD, price))
            {
                MessageBox.Show("Thêm món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm món ăn không thành công ");
            }
            LoadFood();

        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txbFoodID.Text);
            string name = txbNameFood.Text;
            int price = Convert.ToInt32(txbPriceFood.Text);
            int categoryiD = (cbCategoryAdmin.SelectedItem as Category).ID;
            if (FoodDAO.Instance.UpdateFood(idfood, categoryiD, name, price))
            {
                MessageBox.Show("Cập nhật món ăn thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật món ăn không thành công ");
            }
            LoadFood();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.DeleteFood(idfood))
            {
                MessageBox.Show("Xóa món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa món ăn không thành công ");
            }
            LoadFood();
        }

        private void bntShowFood_Click(object sender, EventArgs e)
        {
            LoadFood();
        }
        private void bntSearchFood_Click(object sender, EventArgs e)
        {
            string name = txbSearchFood.Text;
            BdFood.DataSource = FoodDAO.Instance.SearchFoodtByName(name);
        }
        #endregion
        #region EventCategory
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbNameCategory.Text;

            if (CategoryDAO.Instance.AddCategory(name))
            {
                MessageBox.Show("Thêm danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm danh mục món ăn không thành công ");
            }
            LoadCategory();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.DeleteCategory(idcategory))
            {
                MessageBox.Show("Xóa danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa danh mục món ăn không thành công ");
            }
            LoadCategory();
            LoadFood();
            LoadCbbCate();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(txbCategoryID.Text);
            string name = txbNameCategory.Text;
            if (CategoryDAO.Instance.UpdateCategory(idcategory, name))
            {
                MessageBox.Show("Cập nhật danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật danh mục món ăn không thành công ");
            }
            LoadCategory();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            string name = txbSearchCategory.Text;
            BdCategory.DataSource = CategoryDAO.Instance.SearchCategoryByName(name);

        }
        #endregion
        #region Event Table
        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            string name = txbSearchTable.Text;
            BdTableFood.DataSource = TableDAO.Instance.SearchTableByName(name);
        }
        private void bntShowTable_Click(object sender, EventArgs e)
        {
            LoadTableFood();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbNameTable.Text;
            if (TableDAO.Instance.AddTable(name))
            {
                MessageBox.Show("Thêm bàn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm bàn không thành công ");
            }
            LoadTableFood();
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbTableID.Text);
            string name = txbNameTable.Text;
            if (TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Cập nhật bàn ăn thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật bàn ăn không thành công ");
            }
            LoadTableFood();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbTableID.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa bàn ăn không thành công ");
            }
            LoadTableFood();
        }
        #endregion
        #region Event Account 
        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
        private void bntResetPwdAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;
            if (AccountDAO.Instance.ResetAccount(username))
            {
                MessageBox.Show("Mật khẩu của tài khoản :" + username + "đã cập nhâp.(pwd:123@abc)");
            }
            else
            {
                MessageBox.Show("Cập nhập mật khẩu không thành công ");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công.");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản không thành công. ");
            }
            LoadAccount();
        }
        #endregion
        #region Event Static
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        #endregion

    }
}
