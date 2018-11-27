using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ViTriBLL
/// </summary>
public class ViTriBLL
{
    Data data = new Data();
    public void LuuViTri(string tenvt)
    {
        string sql = "INSERT INTO ViTri(TenViTri) VALUES (N'" + tenvt + "')";
        data.NowR(sql);
    }
    public void SuaViTri(int idvt, string tenvt)
    {
        string sql = "Update ViTri Set TenViTri = N'" + tenvt + "' Where ID_ViTri = '" + idvt + "'";
        data.NowR(sql);
    }
    public void XoaViTri(int idvt)
    {
        string sql = "Delete from ViTri where ID_ViTri = '" + idvt + "'";
        data.NowR(sql);
    }
    public ViTriDTO Get_ViTri(int idvt)
    {
        ViTriDTO vt = new ViTriDTO();
        try
        {
            string kq = "Select * From ViTri Where ID_ViTri = '" + idvt + "'";
            vt.TenViTri = data.GetTable(kq).Rows[0]["TenViTri"].ToString();
            vt.ID_ViTri = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_ViTri"]);
            return vt;
        }
        catch
        {
            return vt;
        }
    }
    public DataTable DsViTri()
    {
        string rowquery = "SELECT * FROM ViTri";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public ViTriBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}