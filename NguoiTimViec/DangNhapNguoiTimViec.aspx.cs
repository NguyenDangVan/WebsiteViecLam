using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.SessionState;

public partial class NguoiTimViec_DangNhapNguoiTimViec : System.Web.UI.Page
{
    clsEncrypt encrypt = new clsEncrypt();
    Data data1 = new Data();
    //TimViecDBDataContext data = new TimViecDBDataContext();
    UngVienBLL ungvienbll = new UngVienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDNNguoiTimViec_Click(object sender, EventArgs e)
    {
        string matkhau = encrypt.GetMD5(txtMKNguoiTimViec.Text);
        bool kq1 = ungvienbll.TimUngVien(txtEmail_NguoiTimViec.Text.Trim().ToString());
        //ungviendto = ungvienbll.
        if (kq1 != false)
        {
            UngVienDTO current_uv = new UngVienDTO();
            current_uv = ungvienbll.Get_UngVien(txtEmail_NguoiTimViec.Text.Trim().ToString());
            Session["UngVien"] = current_uv;
            Session["TenUV"] = current_uv.HoTen;
            Session["IDUngVien"] = current_uv.ID_UngVien;
            string returnUrl = Request.QueryString["returnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
                Response.Redirect(returnUrl);
            else
                Response.Redirect("NguoiTimViec.aspx");
            Response.Write("<script> alert('Đăng nhập thành công.')</script>");
        }
        else
            Response.Write("<script> alert('Đăng nhập không thành công.')</script>");
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        txtEmail_NguoiTimViec.Text = "";
        txtMKNguoiTimViec.Text = "";
    }
}