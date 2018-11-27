using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CV_UngVien
/// </summary>
public class CV_UngVienDTO
{
    public CV_UngVienDTO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ID_CV { get; set; }
    public int ID_UngVien { get; set; }
    public string TieuDe { get; set; }
    public int ID_NganhNghe { get; set; }
    public string KyNang { get; set; }
    public int ID_ViTri { get; set; }
    public int ID_TrinhDo { get; set; }
    public int ID_KinhNghiem { get; set; }
    public string NgoaiNgu { get; set; }
    public string MucLuong { get; set; }
    public string BangCap { get; set; }
    public int TrangThai { get; set; }
}