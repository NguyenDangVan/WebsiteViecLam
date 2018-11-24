using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViecLamMienTrung : System.Web.UI.Page
{
    private ViecLam vl = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadViecLamMT();
        }
    }
    private void LoadViecLamMT()
    {
        grvVLMienTrung_DSViecLam.DataSource = vl.ViecLamMT();
        grvVLMienTrung_DSViecLam.DataBind();
    }
    protected void grvVLMienTrung_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvVLMienTrung_DSViecLam.PageIndex = e.NewPageIndex;
        grvVLMienTrung_DSViecLam.DataBind();
        LoadViecLamMT();
    }

    protected void grvVLMienTrung_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lbtVLMienTrung_DSViecLam")
            {
                Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception)
        { }
    }
}