using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NguoiTimViec_ViecLamDaUngTuyen : System.Web.UI.Page
{
    CV_UngVienBLL cv_uv = new CV_UngVienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViecLamUngTuyen();
        }
    }
    private void ViecLamUngTuyen()
    {
        try
        {
            if(Session["IDUngVien"] != null)
            {
                int CurrentID = (int)Session["IDUngVien"];
                grvNTDXemHS_DSNTD.DataSource = cv_uv.ViecLamDaUngTuyen(CurrentID);
                grvNTDXemHS_DSNTD.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void lnkVLDaUngTuyen_TuHoSo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
    }
    protected void lnkVLDaUngTuyen_TaiKhoan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
    }
    protected void lnkVLDaUngTuyen_ViecLamUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/ViecLamDaUngTuyen.aspx");
    }
    protected void lnkVLDaUngTuyen_NhaTuyenDungXemHoSo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NhaTuyenDungXemHoSo.aspx");
    }
}