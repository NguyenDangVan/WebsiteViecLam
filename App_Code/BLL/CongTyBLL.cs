using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for CongTyBLL
/// </summary>
public class CongTyBLL
{
    Data data = new Data();
    public DataTable DsCongTy()
    {
        string rowquery = "SELECT top 5 * FROM CongTy order by ID_CongTy desc";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public void LuuCongTy(CongTy ct)
    {
        string sql = "INSERT INTO CongTy(TenCongTy, TenDangNhap, MatKhau, DiaChi, QuyMo, SDT, Mota, NguoiDaiDien, Email, ID_ThanhPho) "
            + "VALUES (N'" + ct.TenCongTy + "', '"+ ct.TenDangNhap +"', '" + ct.MatKhau + "', N'" + ct.DiaChi + "', N'"+ ct.QuyMo +"','"+ ct.SDT +"',N'"+ ct.MoTa +"', N'"+ ct.NguoiDaiDien +"', '"+ ct.Email + "', '" + ct.ID_ThanhPho + "')";
        data.NowR(sql);
    }
    public void CapNhatCongTy(int id, string tencongty, string diachi, int thanhpho, string sdt, string mota, string quymo, string email, string nguoidaidien)
    {
        string sql = "Update CongTy Set TenCongTy = N'" + tencongty + "', DiaChi = N'" + diachi + "', "
            + "ID_ThanhPho = '" + thanhpho + "', SDT = N'" + sdt + "', MoTa = N'" + mota + "', QuyMo = N'" + quymo + "', Email = N'" + email + "', NguoiDaiDien = N'" + nguoidaidien + "' where ID_CongTy = '"+ id +"' ";
        data.NowR(sql);
    }
    public CongTy Get_CongTy(string tendangnhap)
    {
        CongTy ct = new CongTy();
        try
        {
            string kq = "Select * From CongTy Where TenDangNhap = '" + tendangnhap + "'";
            DataTable mytable = new DataTable();
            //UngVienDTO ct = new UngVienDTO();
            ct.ID_CongTy = Convert.ToInt32(data.GetTable(kq).Rows[0][0]);
            ct.TenCongTy = data.GetTable(kq).Rows[0][1].ToString();
            ct.TenDangNhap = data.GetTable(kq).Rows[0][2].ToString();
            ct.MatKhau = data.GetTable(kq).Rows[0][3].ToString();
            ct.DiaChi = data.GetTable(kq).Rows[0][4].ToString();
            ct.QuyMo = data.GetTable(kq).Rows[0][5].ToString();
            ct.SDT = data.GetTable(kq).Rows[0][6].ToString();
            ct.MoTa = data.GetTable(kq).Rows[0][8].ToString();
            ct.NguoiDaiDien = data.GetTable(kq).Rows[0][9].ToString();
            ct.Email = data.GetTable(kq).Rows[0][10].ToString();
            ct.ID_ThanhPho = Convert.ToInt32(data.GetTable(kq).Rows[0][11]);

            return ct;
        }
        catch
        {
            return ct;
        }
    }
    public bool KiemTraTenDangNhapCT(string tendangnhap)
    {
        string kq = "SELECT * FROM CongTy";
        DataTable mytable = new DataTable();
        mytable = data.GetTable(kq);
        foreach (DataRow row in mytable.Rows)
        {
            if (row["TenDangNhap"].ToString() == tendangnhap)
                return false;
            else
                return true;
        }
        return true;
    }
	public CongTyBLL()
	{
	}
}