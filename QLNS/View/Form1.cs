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
using QLNS.Controller;
using QLNS.Model;

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
            imageList1.Images.Add("key1", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\19.png"));
            imageList1.Images.Add("key2", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\20.png"));
            imageList1.Images.Add("key3", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\1.png"));
            imageList1.Images.Add("key4", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\QLNhanSu\QLNS\Resources\16.png"));

            //initialize the tab control
            TabControl tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ImageList = imageList1;
            tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            this.Controls.Add(tabControl1);
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

            dtgDSNV.DataSource = control.getListNhanVien();
            LoadDtgDSNV();

        }
        private void LoadDtgDSNV()
        {
            //dtgDSNV


            dtgDSNV.Columns["ma"].HeaderText = "Mã";
            dtgDSNV.Columns["ten"].HeaderText = "Họ và Tên";
            dtgDSNV.Columns["ngaysinh"].HeaderText = "Ngày Sinh";
            dtgDSNV.Columns["gioitinh"].HeaderText = "Giới Tính";
            dtgDSNV.Columns["diachi"].HeaderText = "Địa Chỉ";
            dtgDSNV.Columns["socmnd"].HeaderText = "Số CMND";
            dtgDSNV.Columns["dienthoai"].HeaderText = "Điện Thoại";
            dtgDSNV.Columns["email"].HeaderText = "Email";
            dtgDSNV.Columns["maChucVu"].HeaderText = "Chức Vụ";
            dtgDSNV.Columns["maluong"].HeaderText = "Lương";
            dtgDSNV.Columns["maphongban"].HeaderText = "Phòng Ban";
            dtgDSNV.Columns["maTDHV"].HeaderText = "TDHV";

            dtgDSNV.Columns["ma"].Width = 60;
            dtgDSNV.Columns["ten"].Width = 150;
            dtgDSNV.Columns["socmnd"].Width = 100;
            dtgDSNV.Columns["email"].Width = 150;
            dtgDSNV.Columns["gioitinh"].Width = 70;
            dtgDSNV.Columns["ngaysinh"].Width = 70;

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
            frmdangnhap fr = new frmdangnhap();
            fr.ShowDialog();
            tabControl_Chung.Enabled = true;
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

        private void lblTroGiup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_Chung.SelectTab(tpHDSuDung);
        }
      
        private void btnTT_DangNhap_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        NhanSu nv = new NhanSu();
      
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                control.Xoa(nv.ma);
                MessageBox.Show("Đã Xóa Thành Công!");
                dgvNhanSu.DataSource = da.Query("select *from NhanVien");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Không Thể Xóa");
            }
        }

        private void tpHDSuDung_Click(object sender, EventArgs e)
        {

        }

        private void tvStile_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nName = e.Node;
            string webPage = "";
            webPage = (string)nName.Tag;
            if (webPage != "")
            {
                wbStile.Navigate(webPage);
            }
        }

   

        private void pbTT_DoiMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void cbbPhongBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            dtgDSNV.Refresh();

            string str = cbbPhongBan.SelectedItem.ToString();
            dtgDSNV.DataSource = control.getListNhanVienPB(str);
            LoadDtgDSNV();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
           
            dtgDSNV.DataSource = control.getListNhanVienMa(txtMaNV.Text);
            LoadDtgDSNV();
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
           
            dtgDSNV.DataSource = control.getListNhanVienTen(txtTenNV.Text);
            LoadDtgDSNV();
        }

        private void chBChon_CheckedChanged(object sender, EventArgs e)
        {
            cbbPhongBan.Enabled = true;

        }

        private void dtgDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaNV_Click(object sender, EventArgs e)
        {
            chBChon.Enabled = false;
            cbbPhongBan.Enabled = false;
        }

        private void txtTenNV_Click(object sender, EventArgs e)
        {
            chBChon.Enabled = false;
            txtTenNV.Enabled = false;
        }

        private void dtgDSNV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow row = new DataGridViewRow();
            row = dtgDSNV.Rows[e.RowIndex];
            try
            {

                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();

                txtDC.Text = row.Cells[4].Value.ToString();
                txCMND.Text = row.Cells[5].Value.ToString();
                txtDienThoai.Text = row.Cells[6].Value.ToString();
                txtEmail.Text = row.Cells[7].Value.ToString();
                txtLuong.Text = row.Cells[9].Value.ToString();
                txtChucVu.Text = row.Cells[8].Value.ToString();
                txtPhongBan.Text = row.Cells[10].Value.ToString();
                txtTrinhDo.Text = row.Cells[11].Value.ToString();

                dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "0")

                    rdbNu.Checked = true;

                else
                    rdbNam.Checked = true;



            }
            catch (Exception)
            {

            }
        }

        private void btnTT_DangNhap_Click_2(object sender, EventArgs e)
        {

        }

        private void pbTT_DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void pbTT_DoiMatKhau_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTT_DoiMatKhau_Click_1(object sender, EventArgs e)
        {

        }

        private void pbTT_Thoat_Click(object sender, EventArgs e)
        {

        }

        private void btnTT_Thoat_Click_1(object sender, EventArgs e)
        {

        }
    }
}
