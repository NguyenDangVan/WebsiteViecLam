using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CV_UngVienBLL
/// </summary>
public class CV_UngVienBLL
{
    Data data = new Data();
    public DataTable LoadCV()
    {
        string rowquery = " Select CV_UngVien.ID_CV, UngVien.HoTen, CV_UngVien.TieuDe, NganhNghe.TenNganhNghe, TrinhDo.TenTrinhDo, CV_UngVien.NgoaiNgu, CV_UngVien.MucLuong, CV_UngVien.BangCap"
                         +" from CV_UngVien inner join UngVien on CV_UngVien.ID_UngVien = UngVien.ID_UngVien"
                         +" inner join NganhNghe on NganhNghe.ID_NganhNghe = CV_UngVien.ID_NganhNghe"
                         +" inner join TrinhDo on TrinhDo.ID_TrinhDo = CV_UngVien.ID_TrinhDo"
                         +" Where CV_UngVien.TrangThai = 0";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable CV_ChuaDuyet(int idcv)
    {
        string rowquery = " Select CV_UngVien.ID_CV, UngVien.HoTen, CV_UngVien.TieuDe, NganhNghe.TenNganhNghe, CV_UngVien.KyNang,"
                         + " ViTri.TenViTri, TrinhDo.TenTrinhDo, KinhNghiem.TenKinhNghiem, CV_UngVien.NgoaiNgu, CV_UngVien.MucLuong, CV_UngVien.BangCap"
                         + " from CV_UngVien inner join UngVien on CV_UngVien.ID_UngVien = UngVien.ID_UngVien"
                         + " inner join NganhNghe on NganhNghe.ID_NganhNghe = CV_UngVien.ID_NganhNghe"
                         + " inner join TrinhDo on TrinhDo.ID_TrinhDo = CV_UngVien.ID_TrinhDo"
                         + " inner join ViTri on ViTri.ID_ViTri = CV_UngVien.ID_ViTri"
                         + " inner join KinhNghiem on KinhNghiem.ID_KinhNghiem = CV_UngVien.ID_KinhNghiem"
                         + " Where ID_CV = '"+ idcv +"'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public void LuuCVUngVien(CV_UngVienDTO cv, int id_ungvien)
    {
        string sql = "INSERT INTO CV_UngVien (ID_UngVien, TieuDe, ID_NganhNghe, KyNang, ID_ViTri, ID_TrinhDo, ID_Kinhnghiem, NgoaiNgu, MucLuong, BangCap, TrangThai) "
            + "VALUES ('" + id_ungvien + "', '" + cv.TieuDe + "', N'" + cv.ID_NganhNghe + "', '" + cv.KyNang + "', N'" + cv.ID_ViTri + "', '" + cv.ID_TrinhDo + "', '" + cv.ID_KinhNghiem + "', '" + cv.NgoaiNgu + "', '" + cv.MucLuong + "', '" + cv.BangCap + "', '" + cv.TrangThai + "')";
        data.NowR(sql);
    }
    public void XoaCV(int id_ungvien)
    {
        string sql = "DELETE FROM CV_UngVien WHERE ID_UngVien = '"+ id_ungvien +"'";
        data.NowR(sql);
    }
    public void CapNhatCV(int id, string tieude, int nganhnghe, string kynang, int vitri, int trinhdo, int kinhnghiem, string ngoaingu, string mucluong, string bangcap)
    {
        string sql = "Update CV_UngVien Set TieuDe = '" + tieude + "', ID_NganhNghe = '" + nganhnghe + "', "
            + "KyNang = N'" + kynang + "', ID_ViTri = '" + vitri + "', ID_KinhNghiem = '" + kinhnghiem + "', "
            + "NgoaiNgu = N'" + ngoaingu + "', MucLuong = '" + mucluong + "', BangCap = N'" + bangcap + "' ";
        data.NowR(sql);
    }
    public CV_UngVienDTO Get_CVUngVien(int id_UngVien)
    {
        CV_UngVienDTO cv = new CV_UngVienDTO();
        try
        {
            string kq = "Select * From CV_UngVien Where ID_UngVien = '" + id_UngVien + "' ";
            DataTable mytable = new DataTable();
            //UngVienDTO uv = new UngVienDTO();
            cv.ID_CV= Convert.ToInt32(data.GetTable(kq).Rows[0][0]);
            cv.TieuDe = data.GetTable(kq).Rows[0][2].ToString();
            cv.ID_NganhNghe = Convert.ToInt32(data.GetTable(kq).Rows[0][3]);
            cv.KyNang = data.GetTable(kq).Rows[0][4].ToString();
            cv.ID_ViTri = Convert.ToInt32(data.GetTable(kq).Rows[0][5]);
            cv.ID_TrinhDo = Convert.ToInt32(data.GetTable(kq).Rows[0][6]);
            cv.ID_KinhNghiem = Convert.ToInt32(data.GetTable(kq).Rows[0][7]);
            cv.NgoaiNgu = data.GetTable(kq).Rows[0][8].ToString();
            cv.MucLuong = data.GetTable(kq).Rows[0][9].ToString();
            cv.BangCap = data.GetTable(kq).Rows[0][10].ToString();
            cv.TrangThai = Convert.ToInt32(data.GetTable(kq).Rows[0][11]);

            return cv;
        }
        catch
        {
            return cv;
        }
    }
    public int LayID_CV(int id_ungvien)
    {
        string sql = "SELECT CV_UngVien.ID_CV FROM CV_UngVien WHERE ID_UngVien = '" + id_ungvien + "'";
        return Convert.ToInt32(data.GetTable(sql).Rows[0][0].ToString());
    }
    public DataTable ViecLamDaUngTuyen(int id_ungvien )
    {
        string rowquery = " SELECT DangKy.ID_DangKy, ViecLam.TieuDeViecLam, CongTy.TenCongTy, DangKy.NgayUngTuyen "
                         + " FROM DangKy "
                         + " INNER JOIN ViecLam ON DangKy.ID_ViecLam = ViecLam.ID_ViecLam "
                         + " INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                         + " INNER JOIN CV_UngVien ON DangKy.ID_CV = CV_UngVien.ID_CV "
                         + " WHERE DangKy.ID_CV = '"+ id_ungvien +"'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable NhaTuyenDungXemHoSo(int id_ungvien)
    {
        string rowquery = " SELECT CongTy.TenCongTy, DangKy.NgayXem "
                         + " FROM DangKy "
                         + " INNER JOIN ViecLam ON DangKy.ID_ViecLam = ViecLam.ID_ViecLam "
                         + " INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                         + " INNER JOIN CV_UngVien ON DangKy.ID_CV = CV_UngVien.ID_CV "
                         + " WHERE DangKy.ID_CV = '" + id_ungvien + "'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public CV_UngVienBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}