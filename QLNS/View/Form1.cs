using QLNS.Controller;
using QLNS.View;
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
    public partial class QLNS : Form
    {
        Controllers control = new Controllers();
        frmAdd frm_Add;
        public QLNS()
        {
            InitializeComponent();

            ImageList imageList1 = new ImageList();
            //imageList1.Images.Add("key1", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\19.png"));
            //imageList1.Images.Add("key2", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\20.png"));
            //imageList1.Images.Add("key3", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\1.png"));
            //imageList1.Images.Add("key4", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\16.png"));
        
            ////initialize the tab control
            //TabControl tabControl1 = new TabControl();
            //tabControl1.Dock = DockStyle.Fill;
            //tabControl1.ImageList = imageList1;
            //tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            //tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            //this.Controls.Add(tabControl1);
        }
        public void update_FormMain()
        {
            dgvNhanSu.DataSource = control.getListNhanVien();
        }
        private void QLNS_Load(object sender, EventArgs e)
        {
            dgvNhanSu.DataSource = control.getListNhanVien();
            dgvNhanSu.Columns["ma"].HeaderText = "Mã";
            dgvNhanSu.Columns["ten"].HeaderText = "Họ tên";
            dgvNhanSu.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgvNhanSu.Columns["gioitinh"].HeaderText = "Giới tính";
            dgvNhanSu.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvNhanSu.Columns["socmnd"].HeaderText = "CMND";
            dgvNhanSu.Columns["dienthoai"].HeaderText = "Điện thoại";
            dgvNhanSu.Columns["email"].HeaderText = "Email";
            dgvNhanSu.Columns["maChucVu"].HeaderText = "Chức vụ";
            dgvNhanSu.Columns["maluong"].HeaderText = "Mức Lương";
            dgvNhanSu.Columns["maphongban"].HeaderText = "Phòng ban";
            dgvNhanSu.Columns["maTDHV"].HeaderText = "TDHV";

            dgvNhanSu.Columns["ma"].Width = 60;
            dgvNhanSu.Columns["ten"].Width = 150;
            dgvNhanSu.Columns["socmnd"].Width = 100;
            dgvNhanSu.Columns["email"].Width = 150;
            dgvNhanSu.Columns["gioitinh"].Width = 50;
            dgvNhanSu.Columns["ngaysinh"].Width = 100;
            dgvNhanSu.Columns["maChucVu"].Width = 150;
            dgvNhanSu.Columns["maphongban"].Width = 150;
            dgvNhanSu.Columns["diachi"].Width = 200;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chBChon_Click(object sender, EventArgs e)
        {
            cbbPhongBan.Enabled = true;
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frm_Add = new frmAdd(this);
            frm_Add.ShowDialog();
            update_FormMain();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            tabControl_Chung.SelectTab(tpTrangChu);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tabControl_Chung.SelectTab(tpTimKiem);
        }

        private void btnTT_DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnTT_DoiMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void btnTT_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbdanhsach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_Chung.SelectTab(tpDSNhanVien);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_Chung.SelectTab(tpTimKiem);
        }

        private void lbhuongdan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_Chung.SelectTab(tpHDSuDung);
        }

        private void lblLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_Chung.SelectTab(tpLienHe);
        }
        
        frmUpdate update;
        DataAccess da = new DataAccess();
        private void btnSua_Click(object sender, EventArgs e)
        {
            string s = dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[0].Value.ToString() + "_"
            + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[1].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[2].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[3].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[4].Value.ToString() + "_"
             + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[5].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[6].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[7].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[8].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[10].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[10].Value.ToString() + "_"
              + dgvNhanSu.Rows[dgvNhanSu.CurrentRow.Index].Cells[11].Value.ToString();
            update = new frmUpdate(s);
            update.ShowDialog();
            dgvNhanSu.DataSource = da.Query("select *from NhanVien");
        }

        private void dgvNhanSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void btnTT_DangNhap_Click_1(object sender, EventArgs e)
        {
            frmdangnhap fr = new frmdangnhap();
            fr.ShowDialog();
            tabControl_Chung.Enabled = true;
        }
    }
}
