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