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