using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TimKiem : System.Web.UI.Page
{
    Data data = new Data();
    ViecLam vl = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TimKiemDSViecLam();
        }
    }
    protected void grvTimKiem_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTimKiem_DSViecLam.PageIndex = e.NewPageIndex;
        grvTimKiem_DSViecLam.DataBind();
        TimKiemDSViecLam();
    }

    protected void grvTimKiem_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lbtChiTietTimKiem_DSViecLam")
            {
                Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception)
        { }
    }
    private void TimKiemDSViecLam()
    {
        
        int nghe = Convert.ToInt32(Request.QueryString["IDNghe"]);
        int thanhpho = Convert.ToInt32(Request.QueryString["IdTP"]);
        string search = Request.QueryString["Search"];
        if(search == "")
        {
            if (nghe != 0 && thanhpho != 0)
            {
                try
                {
                    grvTimKiem_DSViecLam.DataSource = vl.TimKiem(1, nghe, thanhpho);
                    grvTimKiem_DSViecLam.DataBind();
                    vl.TimKiem(1, nghe, thanhpho).Rows[0][0].ToString();
                }

                catch
                {
                    lblTimKiem_ThongBao.Text = "Kết quả bạn tìm kiếm không tồn tại";
                    lblTimKiem_ThongBao.Visible = true;
                }
            }
        }
        else
        {
            try
            {
                grvTimKiem_DSViecLam.DataSource = vl.TimKiem_Text(1, search);
                grvTimKiem_DSViecLam.DataBind();
                vl.TimKiem_Text(1, search).Rows[0][0].ToString(); ;
            }
            catch
            {
                lblTimKiem_ThongBao.Text = "Kết quả bạn tìm kiếm không tồn tại";
                lblTimKiem_ThongBao.Visible = true;
            }
        }
    }
}