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
	public ViecLam()
	{
		
	}
}