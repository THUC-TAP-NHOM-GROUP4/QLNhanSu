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
        DataAccess da = new DataAccess();
        NhanSu nv = new NhanSu();
        private void btnSua_Click(object sender, EventArgs e)
        {

            txtma.Enabled = true;
            // if (txtten.Text == "" || txtsocmnd.Text == "" || txtmaluong.Text == "" || txtemali.Text == "" || txtdienthoai.Text == "" || txtdiachi.Text == "")
            //   MessageBox.Show("Vui lòng xem lại có thể bạn chưa chọn đối tượng");
            //  else
            // {
            //    if (txtten.Text != "" || txtsocmnd.Text != "" || txtmaluong.Text != "" || txtemali.Text != "" || txtdienthoai.Text != "" || txtdiachi.Text != "")
            //    {
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
            control.Sua(nv.ma, nv.ten, nv.diachi, nv.ngaysinh, nv.gioitinh, nv.socmnd, nv.dienthoai, nv.email, nv.maChucVu, nv.maluong, nv.maphongban, nv.maTDHV);
            MessageBox.Show("Thành công");
            //   }
            //  else
            //     MessageBox.Show("Vui lòng xem lại");
            //  }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
      
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            txtma.Enabled = true;
            // if (txtten.Text == "" || txtsocmnd.Text == "" || txtmaluong.Text == "" || txtemali.Text == "" || txtdienthoai.Text == "" || txtdiachi.Text == "")
            //   MessageBox.Show("Vui lòng xem lại có thể bạn chưa chọn đối tượng");
            //  else
            // {
            //    if (txtten.Text != "" || txtsocmnd.Text != "" || txtmaluong.Text != "" || txtemali.Text != "" || txtdienthoai.Text != "" || txtdiachi.Text != "")
            //    {
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
            control.Sua(nv.ma, nv.ten, nv.diachi, nv.ngaysinh, nv.gioitinh, nv.socmnd, nv.dienthoai, nv.email, nv.maChucVu, nv.maluong, nv.maphongban, nv.maTDHV);
            MessageBox.Show("Thành công");
            //   }
            //  else
            //     MessageBox.Show("Vui lòng xem lại");
            //  }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            QLNS fr = new QLNS();
            fr.Show();
        }
    }
}
