using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for NganhNghe
/// </summary>
public class NganhNghe
{
    Data data = new Data();
    public void LuuNganh(string tennganh)
    {
        string sql = "INSERT INTO NganhNghe(TenNganhNghe) VALUES (N'" + tennganh +"')";
        data.NowR(sql);
    }
    public NganhNgheDTO Get_NganhNghe(int idNganh)
    {
        NganhNgheDTO nn = new NganhNgheDTO();
        try
        {
            string kq = "Select * From NganhNghe Where ID_NganhNghe = '" + idNganh + "'";
            nn.TenNganhNghe = data.GetTable(kq).Rows[0]["TenNganhNghe"].ToString();
            nn.ID_NganhNghe = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_NganhNghe"]);
            return nn;
        }
        catch
        {
            return nn;
        }
    }
    public void SuaNganhNghe(int idNganh, string tenNganh)
    {
        string sql = "Update NganhNghe Set TenNganhNghe = N'"+ tenNganh +"' Where ID_NganhNghe = '"+ idNganh +"'";
        data.NowR(sql);
    }
    public void XoaNganh(int idNganh)
    {
        string sql = "Delete from NganhNghe where ID_NganhNghe = '" + idNganh + "'";
        data.NowR(sql);
    }
    public DataTable DsNganhNgheHot()
    {
        string rowquery = "SELECT top 5 * FROM NganhNghe order by ID_NganhNghe desc";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public DataTable DsNganhNghe()
    {
        string rowquery = "SELECT * FROM NganhNghe";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public NganhNghe()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}