using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for KinhNghiemBLL
/// </summary>
public class KinhNghiemBLL
{
    Data data = new Data();
    public void LuuKinhNghiem(string tenkn)
    {
        string sql = "INSERT INTO KinhNghiem(TenKinhNghiem) VALUES (N'" + tenkn + "')";
        data.NowR(sql);
    }
    public void SuaKinhNghiem(int idkn, string tenkn)
    {
        string sql = "Update KinhNghiem Set TenKinhNghiem = N'" + tenkn + "' Where ID_KinhNghiem = '" + idkn + "'";
        data.NowR(sql);
    }
    public void XoaKinhNghiem(int idkn)
    {
        string sql = "Delete from KinhNghiem where ID_KinhNghiem = '" + idkn + "'";
        data.NowR(sql);
    }
    public KinhNghiemDTO Get_KinhNghiem(int idkn)
    {
        KinhNghiemDTO kn = new KinhNghiemDTO();
        try
        {
            string kq = "Select * From KinhNghiem Where ID_KinhNghiem = '" + idkn + "'";
            kn.TenKinhNghiem = data.GetTable(kq).Rows[0]["TenKinhNghiem"].ToString();
            kn.ID_KinhNghiem = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_KinhNghiem"]);
            return kn;
        }
        catch
        {
            return kn;
        }
    }
    public DataTable DsKinhNghiem()
    {
        string rowquery = "SELECT * FROM KinhNghiem";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public KinhNghiemBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}