using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViecLam
/// </summary>
public class ViecLamDTO
{
	public ViecLamDTO()
	{
		
	}
    public int ID_ViecLam { get; set; }
    public string TieuDeViecLam { get; set; }
    public string MoTa { get; set; }
    public int ID_NganhNghe { get; set; }
    public int ID_ViTri { get; set; }
    public string GioiTinh { get; set; }
    public string YeuCauKyNang { get; set; }
    public string ThoiGianThuViec { get; set; }
    public int KinhNghiem { get; set; }
    public int TrinhDo { get; set; }
    public string MucLuong { get; set; }
    public string NgayDang { get; set; }
    public string NgayHethan { get; set; }
    public bool TrangThai { get; set; }
    public int ID_CongTy { get; set; }
    public int SoLuong { get; set; }
    public string YeuCauHoSo { get; set; }
}