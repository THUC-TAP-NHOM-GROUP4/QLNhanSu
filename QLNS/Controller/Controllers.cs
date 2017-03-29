using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.Controller;
using QLNS.View;

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
            DataTable table = da.Query("select ten from ChucVu");
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
            //DataTable table = da.Query("Select *from NhanVien");
            DataTable table = da.Query("select nv.ma, nv.ten, nv.ngaysinh, nv.gioitinh, nv.diachi,nv.socmnd, nv.dienthoai,  "
                       + " nv.email, cv.ten as chucvu, pb.ten as phongban, nv.maluong, tdhv.ten as TDHV from NhanVien nv "
                       + " inner join ChucVu cv on nv.maChucVu = cv.ma inner join PhongBan pb on nv.maphongban = pb.ma "
                       + " inner join TrinhDoHocVan tdhv on tdhv.ma = nv.maTDHV");
            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NhanSu[] list = new NhanSu[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getNhanVien(table.Rows[i]);
                //list[i].gioitinh = (bool)table.Rows[0]["gioitinh"];
            }
            return list;
        }
        public NhanSu[] getListNhanVienPB(string str)
        {
            DataTable table = da.Query("select *from NhanVien where maphongban=(select ma from PhongBan where ten=N'" + str + "')");
            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NhanSu[] list = new NhanSu[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getNhanVienTK(table.Rows[i]);

            }
            return list;
        }
        public NhanSu[] getListNhanVienTen(string str)
        {
            DataTable table = da.Query("select *from NhanVien where ten like '" + str + "%'");
            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NhanSu[] list = new NhanSu[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getNhanVienTK(table.Rows[i]);

            }
            return list;
        }
        public NhanSu[] getListNhanVienMa(string str)
        {
            DataTable table = da.Query("select *from NhanVien where ma like'" + str + "%'");
            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NhanSu[] list = new NhanSu[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getNhanVienTK(table.Rows[i]);

            }
            return list;
        }
        public NhanSu getNhanVienTK(DataRow row)
        {
            NhanSu nv = new NhanSu();
            nv.ma = row["ma"].ToString().Trim();
            nv.ten = row["ten"].ToString().Trim();
            int gt = 1;
            if (int.TryParse(row["gioitinh"].ToString().Trim(), out gt))
            {
                nv.gioitinh = gt;
            }
            DateTime ns = new DateTime();
            if (DateTime.TryParse(row["ngaysinh"].ToString().Trim(), out ns))
            {
                nv.ngaysinh = ns;
            }
            nv.diachi = row["diachi"].ToString().Trim();
            nv.socmnd = row["socmnd"].ToString().Trim();
            nv.dienthoai = row["dienthoai"].ToString().Trim();
            nv.email = row["email"].ToString().Trim();
            nv.maChucVu = row["machucvu"].ToString().Trim();
            nv.maluong = row["maluong"].ToString().Trim();
            nv.maphongban = row["maphongban"].ToString().Trim();
            nv.maTDHV = row["maTDHV"].ToString().Trim();

            return nv;
        }
        public NhanSu getNhanVien(DataRow row)
        {
            NhanSu nv = new NhanSu();
            nv.ma = row["ma"].ToString().Trim();
            nv.ten = row["ten"].ToString().Trim();
            int gt = 1;
            if (int.TryParse(row["gioitinh"].ToString().Trim(), out gt))
            {
                nv.gioitinh = gt;
            }
            DateTime ns = new DateTime();
            if (DateTime.TryParse(row["ngaysinh"].ToString().Trim(), out ns)){
                nv.ngaysinh = ns;
            }
            nv.diachi = row["diachi"].ToString().Trim();
            nv.socmnd = row["socmnd"].ToString().Trim();
            nv.dienthoai = row["dienthoai"].ToString().Trim();
            nv.email = row["email"].ToString().Trim();
            nv.maChucVu = row["chucvu"].ToString().Trim();
            nv.maluong = row["maluong"].ToString().Trim();
            nv.maphongban = row["phongban"].ToString().Trim();
            nv.maTDHV = row["TDHV"].ToString().Trim();

            return nv;
        }
        public void Sua(string ma, string ten, string diachi, DateTime ngaysinh, int gioitinh, string socmnd, string dienthoai, string email, string machucvu, string maluong, string maphongban, string matdhv)
        {
            da.NonQuery("Update NhanVien set ten=N'"+ ten + "', diachi =N'"+ diachi
                + "',ngaysinh='"+ ngaysinh + "', gioitinh='"
                + gioitinh + "', socmnd='" + socmnd + "', dienthoai='"+ dienthoai + "',email='" + email
                + "', maChucVu='"+ machucvu + "',maluong='"+ maluong
                + "',maphongban='"+ maphongban + "',matdhv='"+ matdhv + "' where ma ='"+ ma + "'");
        }

        public void Xoa(string ma)
        {
            da.NonQuery("Delete from NhanVien where ma = '" + ma + "' ");
        }
        public bool Them(NhanSu nv)
        {

            SqlParameter[] para =
                       {
                new SqlParameter("ten", nv.ten),
                new SqlParameter("ngaysinh", nv.ngaysinh),
                new SqlParameter("gioitinh", nv.gioitinh),
                new SqlParameter("diachi", nv.diachi),
                new SqlParameter("socmnd", nv.socmnd),
                new SqlParameter("dienthoai", nv.dienthoai),
                new SqlParameter("email", nv.email),
                new SqlParameter("maChucVu", getCode(nv.maChucVu, "ten",  "chucvu" )),
                new SqlParameter("maluong", nv.maluong),
                new SqlParameter("maphongban", getCode( nv.maphongban, "ten", "phongban")),
                new SqlParameter("maTDHV", getCode( nv.maTDHV,"ten", "TrinhDoHocVan")),
            };
            da.Query("proc_insertNV", para);
            return true;
        }
        private String getMa(string ten, string ma)
        {
            DataTable table = da.Query("select ma from " + "chucvu where ten= N'" + ma + "'");
            int n = table.Rows.Count;
            if (n == 0) return "";
            else return table.Rows[0]["ma"].ToString().Trim();
        }
        public String getCode(String key, String typeKey, String tableName)
        {
            DataTable table = da.Query("select ma from " + tableName + " where " + typeKey + " = N'" + key + "'"); ;
            int n = table.Rows.Count;
            if (n == 0) return "";
            else return table.Rows[0]["ma"].ToString().Trim();
        }
        public List<object> Convert(DataTable dt)
        {
            List<Object> lst = new List<object>();
            foreach (DataRow dr in dt.Rows)
                foreach (DataColumn dc in dt.Columns)
                    lst.Add(dr[dc]);
            return lst;
        }
    }
}

