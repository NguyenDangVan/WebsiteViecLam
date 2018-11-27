using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_UngVienDaUngTuyen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTimUV_OK_Click(object sender, EventArgs e)
    {

    }
    private void LoadDSUVUngTuyen()
    { }
    protected void grvUVUngTuyen_DSUVUngTuyen_RowCommand(object sender, GridViewCommandEventArgs e)
    { }
    protected void grvUVUngTuyen_DSUVUngTuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUVUngTuyen_DSUVUngTuyen.PageIndex = e.NewPageIndex;
        grvUVUngTuyen_DSUVUngTuyen.DataBind();
        LoadDSUVUngTuyen();
    }
    protected void lnkUVUngTuyen_TimKiemUV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
    }
    protected void lnkUVUngTuyen_ThemViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
    }
    protected void lnkUVUngTuyen_DSViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
    }
    protected void lnkUVUngTuyen_UngVienDaUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
    }
}