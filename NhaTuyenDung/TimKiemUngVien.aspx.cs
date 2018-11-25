using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_TimKiemUngVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grvTimUV_DSUngVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTimUV_DSUngVien.PageIndex = e.NewPageIndex;
        grvTimUV_DSUngVien.DataBind();
        LoadUV();
    }
    protected void grvTimUV_DSUngVien_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void LoadUV()
    { }
    protected void btnTimUV_OK_Click(object sender, EventArgs e)
    {

    }

    protected void lnkTimUV_TimKiemUV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
    }

    protected void lnkTimUV_ThemViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
    }

    protected void lnkTimUV_DSViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
    }

    protected void lnkTimUV_UngVienDaUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
    }
    protected void btnTimUV_TimKiem_Click(object sender, EventArgs e)
    {

    }
}