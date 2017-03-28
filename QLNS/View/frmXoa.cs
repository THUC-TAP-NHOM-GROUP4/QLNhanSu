using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.Controller;
using QLNS.Model;

namespace QLNS.View
{
    public partial class frmXoa : Form
    {
        public frmXoa()
        {
            InitializeComponent();
        }

        private string str;
        Controllers control = new Controllers();
        public frmXoa(string s)
        {
            InitializeComponent();
            this.str = s;
        }

        DataAccess da = new DataAccess();
        NhanSu nv = new NhanSu();

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtma.Enabled = true;
           
            nv.ma = txtma.Text;
            nv.ten = txtten.Text.ToString().Trim();
            nv.ngaysinh = DateTime.Parse(dtpngaysinh.Value.ToShortDateString());
            if (rdbnam.Checked)
                nv.gioitinh = 1;
            else nv.gioitinh = 0;
            nv.diachi = txtdiachi.Text.ToString().Trim();
            nv.socmnd = txtsocmnd.Text.ToString().Trim();
            nv.dienthoai = txtdienthoai.Text.ToString().Trim();
            nv.email = txtemali.Text.ToString().Trim();
            nv.maChucVu = cbbmachucvu.Text;
            nv.maluong = cbbmaluong.Text;
            nv.maphongban = cbbmaphongban.Text;
            nv.maTDHV = cbbmatdhv.Text;
            control.Xoa(nv.ma);
            MessageBox.Show("Thành công");
        }

        private void frmXoa_Load(object sender, EventArgs e)
        {
            string[] str1 = str.Split('_');
            txtma.Text = str1[0];
            txtten.Text = str1[1];
            if (str[2].ToString() == "1")
                rdbnam.Checked = true;
            else rbdnu.Checked = true;
            txtdiachi.Text = str1[4];
            txtsocmnd.Text = str1[5];
            txtdienthoai.Text = str1[6];
            txtemali.Text = str1[7];
            cbbmachucvu.Text = str1[8];
            cbbmaluong.Text = str1[9];
            cbbmaphongban.Text = str1[10];
            cbbmatdhv.Text = str1[11];
            cbbmachucvu.DataSource = control.Convert(da.Query("select ma from ChucVu"));
            cbbmaluong.DataSource = control.Convert(da.Query("select ma from Luong"));
            cbbmatdhv.DataSource = control.Convert(da.Query("select ma from TrinhDoHocVan"));
            cbbmaphongban.DataSource = control.Convert(da.Query("select ma from PhongBan"));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            QLNS fr = new QLNS();
            fr.Show();
        }
    }
}
