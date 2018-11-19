using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DAL;
using BLL;

namespace timviec
{
    public static class SessionExt
    {
        //lấy tên của admin
        public static void SetCurrent_Admin(this HttpSessionState session, TaiKhoan hoten)
        {
            session["HoTen"] = hoten;
        }
        //trả tên của admin
        public static TaiKhoan GetName_Admin(this HttpSessionState session)
        {
            return session["HoTen"] as TaiKhoan;
        }
        //lay ten va ma cua ung vien vua dang nhap
        public static void SetCurrent_NguoiTimViec(this HttpSessionState session, UngVien tenungvien, UngVien maungvien)
        {
            session["TenUngVien"] = tenungvien;
            session["MaUngVien"] = maungvien;
        }
        //tra ve ten va ma cua ung vien
        public static UngVien GetName_NguoiTimViec(this HttpSessionState session)
        {
            return session["TenUngVien"] as UngVien;
        }
        public static UngVien GetID_NguoiTimViec(this HttpSessionState session)
        {
            return session["MaUngVien"] as UngVien;
        }
        //lay ten va ma cua nha tuyen dung vua dang nhap
        public static void SetCurrent_NhaTuyenDung(this HttpSessionState session, CongTy tencongty, CongTy macongty)
        {
            session["TenCongTy"] = tencongty;
            session["MaCongTy"] = macongty;
        }
        //tra ve ten va ma cua nha tuyen dung
        public static CongTy GetName_NhaTuyenDung(this HttpSessionState session)
        {
            return session["TenCongTy"] as CongTy;
        }
        public static CongTy GetID_NhaTuyenDung(this HttpSessionState session)
        {
            return session["MaCongTy"] as CongTy;
        }
    }
}