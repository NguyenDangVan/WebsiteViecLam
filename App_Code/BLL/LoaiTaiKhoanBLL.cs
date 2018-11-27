using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LoaiTaiKhoan
/// </summary>
public class LoaiTaiKhoanBLL
{
    Data data = new Data();
    public bool KiemTraTK(string tendangnhap, string matkhau)
    {
        string kq = "SELECT * FROM TaiKhoan";
        DataTable mytable = new DataTable();
        mytable = data.GetTable(kq);
        bool a = false;
        foreach (DataRow row in mytable.Rows)
        {
            if (row["TenDangNhap"].ToString() == tendangnhap && row["MatKhau"].ToString() == matkhau)
                a = false;
            else
                a = true;
        }
        return a;
    }
	public LoaiTaiKhoanBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}