using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.Linq;
using DAL;

namespace BLL
{
    public class CV_UngVienBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        //Luu hồ sơ của các ứng viên.
        public void LuuCVUngVien(int idUngVien, string tieuDe, int idNganhNghe, string kyNang, int idViTri, int idTrinhDo, 
                                    int idKinhNghiem, string ngoaiNgu, string mucLuong, string bangCap, bool trangThai)
        {
            CV_UngVien cv = new CV_UngVien();
            cv.ID_UngVien = idUngVien;
            cv.TieuDe = tieuDe;
            cv.ID_NganhNghe = idNganhNghe;
            cv.KyNang = kyNang;
            cv.ID_ViTri = idViTri;
            cv.ID_TrinhDo = idTrinhDo;
            cv.ID_KinhNghiem = idKinhNghiem;
            cv.NgoaiNgu = ngoaiNgu;
            cv.MucLuong = mucLuong;
            cv.BangCap = bangCap;
            cv.TrangThai = trangThai;
            data.CV_UngViens.InsertOnSubmit(cv);
            data.SubmitChanges();
        }

        //cap nhat cv ung vien
        public void CapNhatCV(int id, string tieude, int nganhnghe, string kynang, int vitri, int trinhdo, int kinhnghiem, string ngoaingu, string mucluong, string bangcap)
        {
            var kq = data.CV_UngViens.Single(p => p.ID_CV == id);
            kq.TieuDe = tieude;
            kq.ID_NganhNghe = nganhnghe;
            kq.KyNang = kynang;
            kq.ID_ViTri = vitri;
            kq.ID_TrinhDo = trinhdo;
            kq.ID_KinhNghiem = kinhnghiem;
            kq.NgoaiNgu = ngoaingu;
            kq.MucLuong = mucluong;
            kq.BangCap = bangcap;
            data.SubmitChanges();
        }

        //xoa cv cua ung vien
        public void XoaCV(int id)
        {
            var kq = (from n in data.CV_UngViens
                      select n).Single(p => p.ID_CV == id);
            data.CV_UngViens.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }

        //lay ID_CV theo ID_UngVien
        public int LayID_CV(int idungvien)
        {
            var kq = (from n in data.CV_UngViens
                      where (n.ID_UngVien == idungvien)
                      select new { n.ID_CV }).SingleOrDefault();
            int id_cv = kq.ID_CV;
            return id_cv;
        }
    }
}
