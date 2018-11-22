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