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
        public QLNS()
        {
            InitializeComponent();
           /* ImageList imageList1 = new ImageList();
            imageList1.Images.Add("key1", Image.FromFile(@"E:\STUDY\MTA\3_Third_Year\TheSecond\Thực tập nhóm\Tuan 1\New_QLNS\QLNS\QLNS\Resources\19.png"));
            imageList1.Images.Add("key2", Image.FromFile(@"E:\STUDY\MTA\3_Third_Year\TheSecond\Thực tập nhóm\Tuan 1\New_QLNS\QLNS\QLNS\Resources\20.png"));
            imageList1.Images.Add("key3", Image.FromFile(@"E:\STUDY\MTA\3_Third_Year\TheSecond\Thực tập nhóm\Tuan 1\New_QLNS\QLNS\QLNS\Resources\1.png"));
            imageList1.Images.Add("key4", Image.FromFile(@"E:\STUDY\MTA\3_Third_Year\TheSecond\Thực tập nhóm\Tuan 1\New_QLNS\QLNS\QLNS\Resources\16.png"));
           
            //initialize the tab control
            TabControl tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ImageList = imageList1;
            tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            this.Controls.Add(tabControl1);
            */
        }

        private void QLNS_Load(object sender, EventArgs e)
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
    }
}
