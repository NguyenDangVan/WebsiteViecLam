using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDNTimViec_Click(object sender, EventArgs e)
    {
        Response.Redirect("NguoiTimViec/DangNhapNguoiTimViec.aspx");
    }
    protected void btnDNTuyenDung_Click(object sender, EventArgs e)
    {
        Response.Redirect("NhaTuyenDung/DangNhapNhaTuyenDung.aspx");
    }
}