using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ViecLam
/// </summary>
public class ViecLam
{
    Data data = new Data();
    public void LuuViecLam(string tieudevl, string mota, int nn, int vitri, string gioitinh, string yeucau, string timethuviec, int kinhnghiem, int trinhdo, string luong, string ngaydang, string ngayhethan, int trangthai, int id, int soluong, string hoso)
    {
        string sql = "INSERT INTO ViecLam(TieuDeViecLam, MoTa, ID_NganhNghe, ID_ViTri, GioiTinh, YeuCauKyNang, ThoiGianThuViec, ID_KinhNghiem, ID_TrinhDo, MucLuong, NgayDang, NgayHetHan, TrangThai, ID_CongTy, SoLuong, YeuCauHoSo) "
            + "VALUES (N'" + tieudevl + "', N'" + mota + "', '" + nn + "', '" + vitri + "', N'" + gioitinh + "', N'" + yeucau + "', N'" + timethuviec + "', "
            + "'" + kinhnghiem + "', '" + trinhdo + "', N'" + luong + "', N'" + ngaydang + "', N'" + ngayhethan + "', '" + trangthai + "', '" + id + "', '" + soluong + "', N'" + hoso + "')";
        data.NowR(sql);
    }
    public void CapNhatViecLam(int idvl, string tieudevl, string mota, int nn, int vitri, string gioitinh, string yeucau, string timethuviec, int kinhnghiem, int trinhdo, string luong, string ngayhethan, int trangthai, int soluong, string hoso)
    {
        string sql = "Update ViecLam Set TieuDeViecLam = N'" + tieudevl + "', MoTa = N'" + mota + "', ID_NganhNghe = '" + nn + "', ID_ViTri = '" + vitri + "', "
            + "GioiTinh = N'" + gioitinh + "', YeuCauKyNang = N'" + yeucau + "', ThoiGianThuViec = '" + timethuviec + "', ID_KinhNghiem = '" + kinhnghiem + "', "
            + "ID_TrinhDo = '" + trinhdo + "', MucLuong = N'" + luong + "', NgayHetHan = N'" + ngayhethan + "', TrangThai = '" + trangthai + "', SoLuong = '" + soluong + "', YeuCauHoSo = N'" + hoso + "' "
            + "Where ID_ViecLam = '"+ idvl +"'";
        data.NowR(sql);
    }
    public void XoaViecLam(int idvieclam)
    {
        string sql = "DELETE FROM ViecLam WHERE ID_ViecLam = '"+ idvieclam +"'";
        data.NowR(sql);
    }
    public DataTable DsViecLam(int idvieclam)
    {
        string sql = "SELECT * FROM ViecLam Where ID_ViecLam = '"+ idvieclam +"'";
        DataTable dt = new DataTable();
        dt = data.GetTable(sql);
        return dt;
    }
    public DataTable DsViecLam_CT(int id_congty)
    {
        string rowquery = "Select ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, NganhNghe.TenNganhNghe, ThanhPho.TenThanhPho, ViecLam.NgayDang, ViecLam.NgayHetHan, ViecLam.TrangThai"
                        + " from ViecLam inner join CongTy on ViecLam.ID_CongTy = CongTy.ID_CongTy"
                        + " inner join ThanhPho on CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho"
                        + " inner join Nganhnghe on ViecLam.ID_NganhNghe= NganhNghe.ID_NganhNghe"
                        + " where ViecLam.ID_CongTy = '" + id_congty + "'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable ViecLamHot()
    {
        string rowquery = "Select ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " from ViecLam inner join CongTy on ViecLam.ID_CongTy = CongTy.ID_CongTy"
                        + " inner join ThanhPho on CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho"
                        + " where TrangThai = 1 and NgayHetHan > GETDATE()";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable ViecLamMB()
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE ThanhPho.ID_Vung = 1 and ViecLam.TrangThai = 1 and NgayHetHan > GETDATE() "
                        + " ORDER BY NgayHetHan DESC";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable ViecLamMT()
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE ThanhPho.ID_Vung = 2 and ViecLam.TrangThai = 1 and NgayHetHan > GETDATE() "
                        + " ORDER BY NgayHetHan DESC";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable ViecLamMN()
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE ThanhPho.ID_Vung = 3 and ViecLam.TrangThai = 1 and NgayHetHan > GETDATE() "
                        + " ORDER BY NgayHetHan DESC";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public String[] ChiTietViecLam(int id_vieclam)
    {
        string rowquery = " SELECT ViecLam.TieuDeViecLam, ViecLam.NgayDang, CongTy.TenCongTy, CongTy.DiaChi, ViecLam.SoLuong, "
                        + " ViecLam.ThoiGianThuViec, TrinhDo.TenTrinhDo, KinhNghiem.TenKinhNghiem, ViTri.TenViTri,"
                        + " GioiTinh, MucLuong, NganhNghe.TenNganhNghe, ThanhPho.TenThanhPho, ViecLam.MoTa, ViecLam.YeuCauHoSo,"
                        + " ViecLam.YeuCauHoSo, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy"
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho"
                        + " INNER JOIN TrinhDo ON ViecLam.ID_TrinhDo = TrinhDo.ID_TrinhDo"
                        + " INNER JOIN KinhNghiem ON ViecLam.ID_KinhNghiem = KinhNghiem.ID_KinhNghiem"
                        + " INNER JOIN NganhNghe ON ViecLam.ID_NganhNghe = NganhNghe.ID_NganhNghe"
                        + " INNER JOIN ViTri ON ViecLam.ID_ViTri = ViTri.ID_ViTri"
                        + " WHERE ViecLam.ID_ViecLam = '"+ id_vieclam +"'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        String [] detailvl = new String [100];
        detailvl[0] = data.GetTable(rowquery).Rows[0][0].ToString();
        detailvl[1] = data.GetTable(rowquery).Rows[0][1].ToString();
        detailvl[2] = data.GetTable(rowquery).Rows[0][2].ToString();
        detailvl[3] = data.GetTable(rowquery).Rows[0][3].ToString();
        detailvl[4] = data.GetTable(rowquery).Rows[0][4].ToString();
        detailvl[5] = data.GetTable(rowquery).Rows[0][5].ToString();
        detailvl[6] = data.GetTable(rowquery).Rows[0][6].ToString();
        detailvl[7] = data.GetTable(rowquery).Rows[0][7].ToString();
        detailvl[8] = data.GetTable(rowquery).Rows[0][8].ToString();
        detailvl[9] = data.GetTable(rowquery).Rows[0][9].ToString();
        detailvl[10] = data.GetTable(rowquery).Rows[0][10].ToString();
        detailvl[11] = data.GetTable(rowquery).Rows[0][11].ToString();
        detailvl[12] = data.GetTable(rowquery).Rows[0][12].ToString();
        detailvl[13] = data.GetTable(rowquery).Rows[0][13].ToString();
        detailvl[14] = data.GetTable(rowquery).Rows[0][14].ToString();
        detailvl[15] = data.GetTable(rowquery).Rows[0][15].ToString();
        detailvl[16] = data.GetTable(rowquery).Rows[0][16].ToString();
        //return dt;
        return detailvl;
    }
    public DataTable TimKiemNhanhVL(int trangthai, int nganhnghe, int thanhpho, int trinhdo, int vitri, int kinhnghiem)
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE TrangThai = '"+ trangthai +"' and ViecLam.ID_NganhNghe = '"+ nganhnghe +"' and CongTy.ID_ThanhPho = '"+ thanhpho +"' "
                        + " and ViecLam.ID_TrinhDo = '"+ trinhdo +"' and ViecLam.ID_ViTri = '"+ vitri +"' and ViecLam.ID_KinhNghiem = '"+ kinhnghiem +"'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable TimKiem(int trangthai, int nganhnghe, int thanhpho)
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE TrangThai = '" + trangthai + "' and ViecLam.ID_NganhNghe = '" + nganhnghe + "' and CongTy.ID_ThanhPho = '" + thanhpho + "'";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable TimKiem_Text(int trangthai, string text)
    {
        string rowquery = " SELECT ViecLam.ID_ViecLam, ViecLam.TieuDeViecLam, ThanhPho.TenThanhPho, ViecLam.MucLuong, ViecLam.NgayHetHan"
                        + " FROM ViecLam INNER JOIN CongTy ON ViecLam.ID_CongTy = CongTy.ID_CongTy "
                        + " INNER JOIN ThanhPho ON CongTy.ID_ThanhPho = ThanhPho.ID_ThanhPho "
                        + " WHERE TrangThai = '" + trangthai + "' and (ViecLam.TieuDeViecLam LIKE N'%" + text + "%' or ThanhPho.TenThanhPho LIKE N'%" + text + "%')";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public ViecLam()
	{
		
	}
}