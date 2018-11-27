using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViecLamMienNam : System.Web.UI.Page
{
    private ViecLam vl = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadViecLamMN();
        }
    }
    private void LoadViecLamMN()
    {
        grvVLMienNam_DSViecLam.DataSource = vl.ViecLamMN();
        grvVLMienNam_DSViecLam.DataBind();
    }
    protected void grvVLMienNam_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvVLMienNam_DSViecLam.PageIndex = e.NewPageIndex;
        grvVLMienNam_DSViecLam.DataBind();
        LoadViecLamMN();
    }

    protected void grvVLMienNam_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lbtVLMienNam_DSViecLam")
            {
                Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception)
        { }
    }
}