﻿using System;
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