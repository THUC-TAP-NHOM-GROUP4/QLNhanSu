using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Controller
{
    class Controllers
    {
        DataAccess da = new DataAccess();
        public const int MAX = 100;
        public String[] getListDataPhongBan()
        {
            DataTable table = da.Query("select ten from PhongBan");
            int n = table.Rows.Count;
            if (n == 0)
            {
                return null;
            }
            String[] list = new String[MAX];
            for (int i = 0; i < n; i++)
            {
                list[i] = (table.Rows[i])["ten"].ToString();
            }
            return list;
        }
        public String[] getListDataLuong()
        {
            DataTable table = da.Query("select ma from Luong");
            int n = table.Rows.Count;
            if (n == 0)
            {
                return null;
            }
            String[] list = new String[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = (table.Rows[i])["ma"].ToString();
            }
            return list;
        }
        public String[] getListDataChucVu()
        {
            DataTable table = da.Query("select ten from PhongBan");
            int n = table.Rows.Count;
            if (n == 0)
            {
                return null;
            }
            String[] list = new String[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = (table.Rows[i])["ten"].ToString();
            }
            return list;
        }
        public String[] getListDataTDHV()
        {
            DataTable table = da.Query("select ten from TrinhDoHocVan");
            int n = table.Rows.Count;
            if (n == 0)
            {
                return null;
            }
            String[] list = new String[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = (table.Rows[i])["ten"].ToString();
            }
            return list;
        }

        public NhanSu[] getListNhanVien()
        {
            DataTable table = da.Query("Select *from NhanVien");
            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NhanSu[] list = new NhanSu[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getNhanVien(table.Rows[i]);
            }
            return list;
        }
        public NhanSu getNhanVien(DataRow row)
        {
            NhanSu nv = new NhanSu();
            nv.ma = row["ma"].ToString().Trim();
            nv.ten = row["ten"].ToString().Trim();
            DateTime ngaysinh;
            if (DateTime.TryParse(row["ngaysinh"].ToString(), out ngaysinh))
            {
                nv.ngaysinh = ngaysinh;
            }
            nv.gioitinh = true;
            nv.diachi = row["diachi"].ToString().Trim();
            nv.socmnd = row["socmnd"].ToString().Trim();
            nv.dienthoai = row["dienthoai"].ToString().Trim();
            nv.email = row["email"].ToString().Trim();
            nv.maChucVu = row["maChucVu"].ToString().Trim();
            nv.maluong = row["maluong"].ToString().Trim();
            nv.maphongban = row["maphongban"].ToString().Trim();
            nv.maTDHV = row["maTDHV"].ToString().Trim();

            return nv;
        }
    }
}

