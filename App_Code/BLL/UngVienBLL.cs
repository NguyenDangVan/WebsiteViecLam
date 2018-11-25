using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for UngVienBLL
/// </summary>
public class UngVienBLL
{
    Data data = new Data();
    public void LuuUngVien(UngVienDTO uv)
    {
        string sql = "INSERT INTO UngVien(HoTen, MatKhau, DiaChi, NgaySinh, GioiTinh, Email, SDT, ID_ThanhPho) " 
            + "VALUES (N'" + uv.HoTen + "', '"+ uv.MatKhau +"', N'"+ uv.DiaChi +"', '"+ uv.NgaySinh +"', N'"+ uv.GioiTinh +"', '"+ uv.Email +"', '"+ uv.SDT +"', '"+ uv.ID_ThanhPho +"')";
        data.NowR(sql);
    }

    public UngVienDTO Get_UngVien(string email)
    {
        UngVienDTO uv = new UngVienDTO();
        try
        {
            string kq = "Select * From UngVien Where Email = '" + email + "'";
            uv.ID_UngVien = Convert.ToInt32(data.GetTable(kq).Rows[0][0]);
            uv.HoTen = data.GetTable(kq).Rows[0][1].ToString();
            uv.DiaChi = data.GetTable(kq).Rows[0][3].ToString();
            uv.NgaySinh = data.GetTable(kq).Rows[0][4].ToString();
            uv.Email = data.GetTable(kq).Rows[0][6].ToString();
            uv.GioiTinh = data.GetTable(kq).Rows[0][5].ToString();
            uv.SDT = data.GetTable(kq).Rows[0][7].ToString();

            return uv;
        }
        catch
        {
            return uv;
        } 
    }
    public bool TimUngVien(string email)
    {
        string kq = "Select * From UngVien Where Email = '"+ email +"' ";
        DataTable mytable = new DataTable();
        mytable = data.GetTable(kq);
        if (mytable != null)
            return true;
        else
            return false;
    }
    public bool KiemTraEmail(string email)
    {
        string kq = "SELECT * FROM UngVien";
        DataTable mytable = new DataTable();
        mytable = data.GetTable(kq);
        foreach (DataRow row in mytable.Rows)
        {
            if (row["Email"].ToString() == email)
                return false;
            else
                return true;
        }
        return true;
    }
	public UngVienBLL()
	{

	}
}