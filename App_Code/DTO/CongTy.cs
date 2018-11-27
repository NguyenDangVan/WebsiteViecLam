using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CongTy
/// </summary>
public class CongTy
{
	public CongTy()
	{
	}

    public int ID_CongTy { get; set; }
    public string TenCongTy { get; set; }
    public string TenDangNhap { get; set; }
    public string MatKhau { get; set; }
    public string DiaChi { get; set; }
    public string QuyMo { get; set; }
    public string SDT { get; set; }
    public string MoTa { get; set; }
    public string NguoiDaiDien { get; set; }
    public string Email { get; set; }
    public int ID_ThanhPho { get; set; }
}