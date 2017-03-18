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

namespace QLNS
{
    public partial class QLNS : Form
    {
        Controllers control = new Controllers();
        frmAdd add;
        public QLNS()
        {
            InitializeComponent();

            ImageList imageList1 = new ImageList();
            imageList1.Images.Add("key1", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\huong\QLNhanSu\QLNS\Resources\19.png"));
            imageList1.Images.Add("key2", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\huong\QLNhanSu\QLNS\Resources\20.png"));
            imageList1.Images.Add("key3", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\huong\QLNhanSu\QLNS\Resources\1.png"));
            imageList1.Images.Add("key4", Image.FromFile(@"E:\HOC_KY_6\ThucTapNhom\PROJECT\huong\QLNhanSu\QLNS\Resources\16.png"));
        
            ////initialize the tab control
            //TabControl tabControl1 = new TabControl();
            //tabControl1.Dock = DockStyle.Fill;
            //tabControl1.ImageList = imageList1;
            //tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            //tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            //this.Controls.Add(tabControl1);
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
            dgvNhanSu.Columns["maChucVu"].HeaderText = "Mã Chức vụ";
            dgvNhanSu.Columns["maluong"].HeaderText = "Mã lương";
            dgvNhanSu.Columns["maphongban"].HeaderText = "Mã phòng ban";
            dgvNhanSu.Columns["maTDHV"].HeaderText = "Mã TDHV";

            dgvNhanSu.Columns["ma"].Width = 60;
            dgvNhanSu.Columns["ten"].Width = 150;
            dgvNhanSu.Columns["socmnd"].Width = 100;
            dgvNhanSu.Columns["email"].Width = 150;
            dgvNhanSu.Columns["gioitinh"].Width = 70;
            dgvNhanSu.Columns["ngaysinh"].Width = 70;

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
            add = new frmAdd(this);
            add.ShowDialog();
        }
    }
}
