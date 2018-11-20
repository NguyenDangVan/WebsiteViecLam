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
    //string hoten, string matkhau, string diachi, int thanhpho, DateTime ngaysinh, string gioitinh, string email, string sdt
    public void LuuUngVien(UngVien uv)
    {
        string sql = "INSERT INTO UngVien(HoTen, MatKhau, DiaChi, NgaySinh, GioiTinh, Email, SDT, ID_ThanhPho) " 
            + "VALUES (N'" + uv.HoTen + "', '"+ uv.MatKhau +"', N'"+ uv.DiaChi +"', '"+ uv.NgaySinh +"', N'"+ uv.GioiTinh +"', '"+ uv.Email +"', '"+ uv.SDT +"', '"+ uv.ID_ThanhPho +"')";
        data.NowR(sql);
        
        //UngVien uv = new UngVien();
        //uv.HoTen = hoten;
        //uv.MatKhau = matkhau;
        //uv.DiaChi = diachi;
        //uv.ID_ThanhPho = thanhpho;
        //uv.NgaySinh = ngaysinh;
        //uv.GioiTinh = gioitinh;
        //uv.Email = email;
        //uv.SDT = sdt;
    }
    public bool TimUngVien(string email, string matkhau)
    {
        string kq = "Select * From UngVien Where Email = '"+ email +"' and MatKhau = '"+ matkhau +"'";
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
        //DataColumn col = mytable.Columns[6];
        //int countRow = mytable.Rows.Count;
        //for (int iRow = 0; iRow < countRow; iRow++)
        //{
        //    string cell = mytable.Rows[iRow][6].ToString();
        //    if (cell == email)
        //    { return false; }
        //    else
        //    {return true;}
        //}
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