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