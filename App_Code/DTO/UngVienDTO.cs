using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UngVien
/// </summary>
public class UngVienDTO
{
    public UngVienDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID_UngVien { get; set; }
    public string HoTen{ get; set; }
    public string MatKhau { get; set; }
    public string DiaChi{ get; set; }
    public string NgaySinh { get; set; }
    public string GioiTinh { get; set; }
    public string Email { get; set; }
    public string SDT { get; set; }
    public int ID_ThanhPho{ get; set; }
}