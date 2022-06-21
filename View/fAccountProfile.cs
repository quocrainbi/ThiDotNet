using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThiDotNet.DTO;

namespace ThiDotNet.View
{
    public partial class fAccountProfile : Form
    {
        private Account _account;
        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }
        public fAccountProfile(Account account)
        {
            InitializeComponent();
            this.Account = account;
            Load();
        }
        void Load()
        {
            txbDisPlayName.Text = this.Account.displayName;
            txbNameLogin.Text = this.Account.userName;
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
