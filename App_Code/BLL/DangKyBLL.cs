using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DangKyBLL
/// </summary>
public class DangKyBLL
{
    Data data = new Data();
    public void LuuDangKy(int id_CV, int idvieclam, string ngayungtuyen, int trangthai)
    {
        string sql = "INSERT INTO DangKy(ID_CV, ID_ViecLam, NgayUngTuyen, TrangThai) "
            + "VALUES (N'" + id_CV + "', '" + idvieclam + "', N'" + ngayungtuyen + "', '" + trangthai + "')";
        data.NowR(sql);
    }
	public DangKyBLL()
	{
		
	}
}