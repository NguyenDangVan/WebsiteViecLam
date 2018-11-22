using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtDefault_User_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UngVien"] != null)
            {
                Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
            }
            //if (Session.GetName_NhaTuyenDung() != null)
            //{
            //    Response.Redirect("~/NhaTuyenDung/NhaTuyenDung.aspx");
            //}
        }
        catch (Exception)
        { }
    }
    protected void lbtDefault_ThoatUser_Click(object sender, EventArgs e)
    {
        Session.Remove("UngVien");
        Response.Redirect("../TrangChu.aspx");
    }
}
