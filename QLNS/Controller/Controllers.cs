﻿using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}

