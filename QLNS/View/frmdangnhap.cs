using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.View
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }
        private string username = "Admin";
        private string password = "12345678";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (username.Equals(txtTenDN.Text) && password.Equals(txtpassword.Text))
            {
                MessageBox.Show("Thành công");
                this.Hide();
                QLNS fr = new QLNS();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại");
                txtpassword.Text = "";
                txtTenDN.Text = "";
            }
        }
    }
}
