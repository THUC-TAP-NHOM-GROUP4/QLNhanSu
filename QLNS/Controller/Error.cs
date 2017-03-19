using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLNS.Controller
{
    enum Loi
    {
        trong,
        saikieu,
        kitungan
    };
    class Error
    {
        public int Trong(string ten, string diachi, string quequan, DateTime ngaysinh, string socmnd, string dienthoai, string email, string loainv, string machucvu, string maluong, string maphongban, string matdhv)
        {
            if (ten == null || diachi == null || quequan == null || ngaysinh == null || socmnd == null || dienthoai == null || email == null || loainv == null || machucvu == null || maluong == null || maphongban == null || matdhv == null)
                return 0;
            else return 1;
        }
        public int Kitu(string ten)
        {
            if (ten.Length < 8)
                return 0;
            else return 1;
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

    }
}
