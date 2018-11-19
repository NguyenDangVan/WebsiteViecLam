using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using DAL;

namespace BLL
{
    public class UngVienBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();

        //Lưu tài khoản ứng viên
        public void LuuUngVien(string hoten, string matkhau, string diachi, int thanhpho, DateTime ngaysinh, string gioitinh, string email, string sdt)
        {
            UngVien uv = new UngVien();
            uv.HoTen = hoten;
            uv.MatKhau = matkhau;
            uv.DiaChi = diachi;
            uv.ID_ThanhPho = thanhpho;
            uv.NgaySinh = ngaysinh;
            uv.GioiTinh = gioitinh;
            uv.Email = email;
            uv.SDT = sdt;
            data.UngViens.InsertOnSubmit(uv);
            data.SubmitChanges();
        }

        //kiem tra email
        public bool KiemTraEmail(string email)
        {
            var kq = from n in data.UngViens
                     select n;
            foreach (var s in kq)
            {
                if (s.Email == email)
                    return false;
                else
                    return true;
            }
            return true;
        }
        
    }
}
