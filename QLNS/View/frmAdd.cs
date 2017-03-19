using QLNS.Controller;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmAdd : Form
    {
        Controllers control = new Controllers();
        Form form1 = new Form();
        public frmAdd(Form form1)
        {
            InitializeComponent();
            this.form1 = form1;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(checkAdd())
            {
                NhanSu nv = new NhanSu();
                nv.ten = txtten.Text.ToString().Trim();
                nv.ngaysinh = DateTime.Parse(dtpngaysinh.Value.ToShortDateString());
                if (rdbnam.Checked) nv.gioitinh = 1;
                else nv.gioitinh = 0;
                nv.diachi = txtdiachi.Text.ToString().Trim();
                nv.socmnd = txtsocmnd.Text.ToString().Trim();
                nv.dienthoai = txtdienthoai.Text.ToString().Trim();
                nv.email = txtemali.Text.ToString().Trim();
                nv.maChucVu = cbbmachucvu.SelectedValue.ToString().Trim();
                nv.maluong = cbbmaluong.SelectedValue.ToString().Trim();
                nv.maphongban = cbbmaphongban.SelectedValue.ToString().Trim();
                nv.maTDHV = cbbmatdhv.SelectedValue.ToString().Trim();

                if (control.Them(nv))
                {
                    this.Close();
                    this.form1.Visible = true;
                }
                
            }
        }    
        
        private void frmAdd_Load(object sender, EventArgs e)
        {
            cbbmachucvu.DataSource = control.getListDataChucVu();
            cbbmaluong.DataSource = control.getListDataLuong();
            cbbmatdhv.DataSource = control.getListDataTDHV();
            cbbmaphongban.DataSource = control.getListDataPhongBan();
        }
        private bool checkAdd()
        {
            if (txtten.Text.Trim().Equals(""))
            {
                erpTxtTen.SetError(txtten, "Phải nhập Họ tên ");
                return false;
            }
            erpTxtTen.Clear();
            if (txtdiachi.Text.Trim().Equals(""))
            {
                erpTxtDiaChi.SetError(txtdiachi, "Phải nhập địa chỉ");
                return false;
            }
            erpTxtDiaChi.Clear();
            if (txtsocmnd.Text.Trim().Equals(""))
            {
                erpSocmnd.SetError(txtsocmnd, "Phải nhập số CMND");
                return false;
            }
            erpSocmnd.Clear();
            if (txtdienthoai.Text.Trim().Equals(""))
            {
                erpDienThoai.SetError(txtdienthoai, "Phải nhập số điện thoại");
                return false;
            }
            erpDienThoai.Clear();
            return true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdd_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
