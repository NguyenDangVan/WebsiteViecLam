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
	public ViecLam()
	{
		
	}
}