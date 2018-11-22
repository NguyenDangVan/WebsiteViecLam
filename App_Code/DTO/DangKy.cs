using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DangKy
/// </summary>
public class DangKy
{
	public DangKy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID_DangKy { get; set; }
    public int ID_CV { get; set; }
    public int ID_ViecLam { get; set; }
    public string NgayXem { get; set; }
    public string NgatUngTuyen { get; set; }
    public bool TrangThai { get; set; }
}