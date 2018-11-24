using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViecLamMienBac : System.Web.UI.Page
{
    private ViecLam vl = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadViecLamMB();
        }
    }
    private void LoadViecLamMB()
    {
        grvVLMienBac_DSViecLam.DataSource = vl.ViecLamMB();
        grvVLMienBac_DSViecLam.DataBind();
    }
    protected void grvVLMienBac_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvVLMienBac_DSViecLam.PageIndex = e.NewPageIndex;
        grvVLMienBac_DSViecLam.DataBind();
        LoadViecLamMB();
    }
    protected void grvVLMienBac_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lbtVLMienBac_DSViecLam")
            {
                Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception)
        { }
    }
}