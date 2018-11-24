using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TimKiemNhanh : System.Web.UI.Page
{
    Data data = new Data();
    ViecLam vl = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TimKiemNhanhViecLam();
        }
    }
    protected void grvTimKiemNhanh_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTimKiemNhanh_DSViecLam.PageIndex = e.NewPageIndex;
        grvTimKiemNhanh_DSViecLam.DataBind();
        TimKiemNhanhViecLam();
    }

    protected void grvTimKiemNhanh_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lbtChiTietTimKiemNhanh_DSViecLam")
            {
                Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception )
        { }
    }
    private void TimKiemNhanhViecLam()
    {
        int nganhnghe = Convert.ToInt32(Request.QueryString["IDNganhNghe"]);
        int thanhpho = Convert.ToInt32(Request.QueryString["IDThanhPho"]);
        int trinhdo = Convert.ToInt32(Request.QueryString["IDTrinhDo"]);
        int vitri = Convert.ToInt32(Request.QueryString["IDViTri"]);
        int kinhnghiem = Convert.ToInt32(Request.QueryString["IDKinhNghiem"]);
        if (nganhnghe != 0 && thanhpho != 0 && trinhdo != 0 && vitri != 0 && kinhnghiem != 0)
        {
            grvTimKiemNhanh_DSViecLam.DataSource = vl.TimKiemNhanhVL(1, nganhnghe, thanhpho, trinhdo, vitri, kinhnghiem);
            grvTimKiemNhanh_DSViecLam.DataBind();
        }
        if (grvTimKiemNhanh_DSViecLam.DataSource == null)
        {
            lblTimKiemNhanh_ThongBao.Text = "Kết quả bạn tìm kiếm không tồn tại";
            lblTimKiemNhanh_ThongBao.Visible = true;
        }
    }
}