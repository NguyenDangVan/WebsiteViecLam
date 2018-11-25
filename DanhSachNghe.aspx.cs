using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhSachNghe : System.Web.UI.Page
{
    Data data = new Data();
    NganhNghe nn = new NganhNghe();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DSNghe();
        }
    }
    private void DSNghe()
    {
        string str = "";
        DataTable dt = new DataTable();
        dt = nn.DsNganhNghe();
        str += "<ul>";
        foreach (DataRow rows in dt.Rows)
        {

            str += "<li><a href='ChiTietNghe.aspx?IDNghe=" + rows[0] + "'>" + rows[1].ToString() + "</a></li>";

        }
        str += "</ul>";
        DanhSachNghe_DSNghe.InnerHtml = str;
    }
}