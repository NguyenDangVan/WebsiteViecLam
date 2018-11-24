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