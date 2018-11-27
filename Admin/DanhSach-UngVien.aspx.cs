using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DanhSach_UngVien : System.Web.UI.Page
{
    UngVienBLL uv = new UngVienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadUngVien();
        }
    }
    public void LoadUngVien()
    {
        grvDS_UngVien.DataSource = uv.LoadUngVien();
        grvDS_UngVien.DataBind();
    }
    protected void btnUV_TimUV_Click(object sender, EventArgs e)
    {
        grvDS_UngVien.DataSource = uv.Tim(txtUV_TenUV.Text.Trim());
        grvDS_UngVien.DataBind();
    }
    protected void grvDS_UngVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadUngVien();
        grvDS_UngVien.PageIndex = e.NewPageIndex;
        grvDS_UngVien.DataBind();
    }
}