using QLNS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.Model;
namespace QLNS.View
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }
        private string str;
        Controllers control = new Controllers();
        public frmUpdate(string s)
        {
            InitializeComponent();
            this.str = s;
        }
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            string[] str1 = str.Split('_');
            txtma.Text = str1[0];
            txtten.Text = str1[1];
            if (str[3].ToString() == "1")
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
            cbbmachucvu.DataSource = control.Convert(da.Query("select ten from ChucVu"));
            cbbmaluong.DataSource = control.Convert(da.Query("select luongcoban from Luong"));
            cbbmatdhv.DataSource = control.Convert(da.Query("select ten from TrinhDoHocVan"));
            cbbmaphongban.DataSource = control.Convert(da.Query("select ten from PhongBan"));
        }
        DataAccess da = new DataAccess();
        NhanSu nv = new NhanSu();
      
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
      
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            List<object> lst = new List<object>();
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
            
            lst = da.Convert(da.Query("select ma from Chucvu where ten=N'" + cbbmachucvu.Text + "'"));
            cbbmachucvu.Text = lst[0].ToString();
            lst = da.Convert(da.Query("select ma from Luong where luongcoban=N'" + cbbmaluong.Text + "'"));
            cbbmaluong.Text = lst[0].ToString();
            lst = da.Convert(da.Query("select ma from PhongBan where ten=N'" + cbbmaphongban.Text + "'"));
            cbbmaphongban.Text = lst[0].ToString();
            lst = da.Convert(da.Query("select ma from TrinhDoHocVan where ten=N'" + cbbmatdhv.Text + "'"));
            cbbmatdhv.Text = lst[0].ToString();

            nv.maChucVu = cbbmachucvu.Text;
            nv.maluong = cbbmaluong.Text;
            nv.maphongban = cbbmaphongban.Text;
            nv.maTDHV = cbbmatdhv.Text;
            control.Sua(nv.ma, nv.ten, nv.diachi, nv.ngaysinh, nv.gioitinh, nv.socmnd, nv.dienthoai, nv.email, nv.maChucVu, nv.maluong, nv.maphongban, nv.maTDHV);
            MessageBox.Show("Thành công");
            
            this.Close();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            QLNS fr = new QLNS();
            fr.Show();
        }

      
    }
}
