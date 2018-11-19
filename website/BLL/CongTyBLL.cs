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
    public class CongTyBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();

        //Lưu công ty
        public void LuuCongTy(string tencongty, string tendangnhap, string matkhau, string diachi, string quymo, string sdt, string website, string mota, string nguoidaidien, string email, int thanhpho)
        {
            CongTy cty = new CongTy();
            cty.TenCongTy = tencongty;
            cty.TenDangNhap = tendangnhap;
            cty.MatKhau = matkhau;
            cty.DiaChi = diachi;
            cty.QuyMo = quymo;
            cty.SDT = sdt;
            cty.Website = website;
            cty.MoTa = mota;
            cty.NguoiDaiDien = nguoidaidien;
            cty.Email = email;
            cty.ID_ThanhPho = thanhpho;
            data.CongTies.InsertOnSubmit(cty);
            data.SubmitChanges();
        }

        //kiem tra ten dang nhap
        public bool KiemTraTenDangNhapCT(string tendangnhap)
        {
            var kq = from n in data.CongTies
                     select n;
            foreach (var s in kq)
            {
                if (s.TenDangNhap == tendangnhap)
                    return false;
                else
                    return true;
            }
            return true;
        }

        //cap nhat cong ty
        public void CapNhat(int id, string tencongty, string diachi, string quymo, string sdt, string website, string mota, string nguoidaidien, string email, int idTP)
        {
            var kq = data.CongTies.Single(p => p.ID_CongTy == id);
            kq.TenCongTy = tencongty;
            kq.DiaChi = diachi;
            kq.QuyMo = quymo;
            kq.SDT = sdt;
            kq.Website = website;
            kq.MoTa = mota;
            kq.NguoiDaiDien = nguoidaidien;
            kq.Email = email;
            kq.ID_ThanhPho = idTP;
            data.SubmitChanges();
        }

    }
}
