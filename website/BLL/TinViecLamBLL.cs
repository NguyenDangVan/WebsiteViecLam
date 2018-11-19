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
    public class TinViecLamBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<TinViecLam> dsViecLam()
        {
            var kq = from n in data.TinViecLams
                     select n;
            return kq.ToList<TinViecLam>();
        }

        //Luu viec lam
        public void LuuViecLam(string tieude, string mota, int idnghe, int idvitri, string gioitinh, string yeucaukynang, string thoigianthuviec, int idkinhnghiem, int idtrinhdo, 
                                string mucluong, DateTime ngaydang, DateTime ngayhethan, bool trangthai, int idcongty, int soluong, string yeucauhoso)
        {
            TinViecLam vieclam = new TinViecLam();
            vieclam.TieuDeViecLam = tieude;
            vieclam.MoTa = mota;
            vieclam.ID_NganhNghe = idnghe;
            vieclam.ID_ViTri = idvitri;
            vieclam.GioiTinh = gioitinh;
            vieclam.YeuCauKyNang = yeucaukynang;
            vieclam.ThoiGianThuViec = thoigianthuviec;
            vieclam.ID_KinhNghiem = idkinhnghiem;
            vieclam.ID_TrinhDo = idtrinhdo;
            vieclam.MucLuong = mucluong;
            vieclam.NgayDang = ngaydang;
            vieclam.NgayHetHan = ngayhethan;
            vieclam.TrangThai = trangthai;
            vieclam.ID_CongTy = idcongty;
            vieclam.SoLuong = soluong;
            vieclam.YeuCauHoSo = yeucauhoso;
            data.TinViecLams.InsertOnSubmit(vieclam);
            data.SubmitChanges();
        }

        //sua viec lam
        public void CapNhapViecLam(int id, string tieude, string mota, int idnghe, int idvitri, string gioitinh, string yeucaukynang, string thoigianthuviec, int idkinhnghiem, int idtrinhdo,
                                string mucluong, DateTime ngayhethan, bool trangthai, int soluong, string yeucauhoso)
        {
            var kq = data.TinViecLams.Single(p => p.ID_ViecLam == id);
            kq.TieuDeViecLam = tieude;
            kq.MoTa = mota;
            kq.ID_NganhNghe = idnghe;
            kq.ID_ViTri = idvitri;
            kq.GioiTinh = gioitinh;
            kq.YeuCauKyNang = yeucaukynang;
            kq.ThoiGianThuViec = thoigianthuviec;
            kq.ID_KinhNghiem = idkinhnghiem;
            kq.ID_TrinhDo = idtrinhdo;
            kq.MucLuong = mucluong;
            kq.NgayHetHan = ngayhethan;
            kq.TrangThai = trangthai;
            kq.SoLuong = soluong;
            kq.YeuCauHoSo = yeucauhoso;
            data.SubmitChanges();
        }

        //xoa viec lam
        public void XoaViecLam(int id)
        {
            var kq = (from n in data.TinViecLams
                      select n).Single(p => p.ID_ViecLam == id);
            data.TinViecLams.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }

        
    }
}
