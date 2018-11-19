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
    public class DangKyBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();

        //dang ky cong viec
        public void LuuDangKy(int id_cvungvien, int idvieclam, DateTime ngayungtuyen, bool trangthai)
        {
            DangKy dk = new DangKy();
            dk.ID_CV = id_cvungvien;
            dk.ID_ViecLam = idvieclam;
            dk.NgayXem = null;
            dk.NgayUngTuyen = ngayungtuyen;
            dk.TrangThai = trangthai;
            data.DangKies.InsertOnSubmit(dk);
            data.SubmitChanges();
        }

        //xoa
        public void XoaDangKy(int iddangky)
        {
            var kq = (from n in data.DangKies
                      select n).Single(p => p.ID_DangKy == iddangky);
            data.DangKies.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }

        //cap nhat
        public void CapNhatDK(int id, DateTime ngayxem, bool trangthai)
        {
            var kq = data.DangKies.Single(p => p.ID_DangKy == id);
            kq.NgayXem = ngayxem;
            kq.TrangThai = trangthai;
            data.SubmitChanges();
        }
    }
}
