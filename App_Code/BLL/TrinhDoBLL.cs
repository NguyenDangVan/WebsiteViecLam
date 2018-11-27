using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TrinhDoDTO
/// </summary>
public class TrinhDoBLL
{
    Data data = new Data();
    public void LuuTrinhDo(string tentd)
    {
        string sql = "INSERT INTO TrinhDo(TenTrinhDo) VALUES (N'" + tentd + "')";
        data.NowR(sql);
    }
    public void SuaTrinhDo(int idtd, string tenTD)
    {
        string sql = "Update TrinhDo Set TenTrinhDo = N'" + tenTD + "' Where ID_TrinhDo = '" + idtd + "'";
        data.NowR(sql);
    }
    public void XoaTrinhDo(int idtd)
    {
        string sql = "Delete from TrinhDo where ID_TrinhDo = '" + idtd + "'";
        data.NowR(sql);
    }
    public TrinhDoDTO Get_TrinhDo(int idtd)
    {
        TrinhDoDTO td = new TrinhDoDTO();
        try
        {
            string kq = "Select * From TrinhDo Where ID_TrinhDo = '" + idtd + "'";
            td.TenTrinhDo = data.GetTable(kq).Rows[0]["TenTrinhDo"].ToString();
            td.ID_TrinhDo = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_TrinhDo"]);
            return td;
        }
        catch
        {
            return td;
        }
    }
    public DataTable DsTrinhDo()
    {
        string rowquery = "SELECT * FROM TrinhDo";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
	public TrinhDoBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}