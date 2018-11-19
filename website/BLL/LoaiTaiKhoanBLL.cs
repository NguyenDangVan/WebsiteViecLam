using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using DAL;

namespace BLL
{
    public class LoaiTaiKhoanBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        //danh sach loại tài khoản
        public List<LoaiTaiKhoan> dsLoaiTK()
        {
            var kq = from n in data.LoaiTaiKhoans
                     select n;
            return kq.ToList<LoaiTaiKhoan>();
        }
        //Lưu loại tài khoản
        public void LuuLoaiTK(string tenloai)
        {
            LoaiTaiKhoan loaitk = new LoaiTaiKhoan();
            loaitk.TenLoai = tenloai;
            data.LoaiTaiKhoans.InsertOnSubmit(loaitk);
            data.SubmitChanges();
        }
    }
}
