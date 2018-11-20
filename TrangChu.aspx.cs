using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TrangChu : System.Web.UI.Page
{
    
    ViecLam vieclam= new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadViecLam();
    }
    private void LoadViecLam()
    {
        grvTrangChu_DSViecLam.DataSource = vieclam.ViecLamHot();
        grvTrangChu_DSViecLam.DataBind();
    }
}