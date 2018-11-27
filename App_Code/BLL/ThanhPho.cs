using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ThanhPho
/// </summary>
public class ThanhPho
{
    Data data = new Data();
    public void LuuTP(string tentp, int idvung)
    {
        string sql = "INSERT INTO ThanhPho(TenThanhPho, ID_Vung) VALUES (N'" + tentp + "', '"+ idvung + "')";
        data.NowR(sql);
    }
    public void SuaThanhPho(int idtp, string tenTP, int idvung)
    {
        string sql = "Update ThanhPho Set TenThanhPho = N'" + tenTP + "' ID_Vung = '"+ idvung +"' Where ID_ThanhPho = '" + idtp + "'";
        data.NowR(sql);
    }
    public void XoaThanhPho(int idtp)
    {
        string sql = "Delete from ThanhPho where ID_ThanhPho = '" + idtp + "'";
        data.NowR(sql);
    }
    public ThanhPhoDTO Get_ThanhPho(int idtp)
    {
        ThanhPhoDTO tp = new ThanhPhoDTO();
        try
        {
            string kq = "Select * From ThanhPho Where ID_ThanhPho = '" + idtp + "'";
            tp.TenThanhPho = data.GetTable(kq).Rows[0]["TenThanhPho"].ToString();
            tp.ID_ThanhPho = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_ThanhPho"]);
            tp.ID_VungMien = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_Vung"]);
            return tp;
        }
        catch
        {
            return tp;
        }
    }
    public DataTable LoadDuLieu()
    {
        string rowquery = "Select * from ThanhPho";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    //public List<ThanhPho> dsThanhPho()
    //{
    //    var kq = from n in data.ThanhPhos
    //             select n;
    //    return kq.ToList<ThanhPho>();
    //}
	public ThanhPho()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}