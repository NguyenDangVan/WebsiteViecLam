using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_DangNhapNhaTuyenDung : System.Web.UI.Page
{
    clsEncrypt encrypt = new clsEncrypt();
    CongTyBLL ctbll = new CongTyBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCT_DangNhap_Click(object sender, EventArgs e)
    {
        string matkhau = encrypt.GetMD5(txtCT_MatKhau.Text);
        var kq = ctbll.KiemTraTenDangNhapCT(txtCT_TenDangNhap.Text.Trim());
        if (kq == true)
        {
            //Session.SetCurrent_NhaTuyenDung(kq, kq);
            CongTy current_ct = new CongTy();
            current_ct = ctbll.Get_CongTy(txtCT_TenDangNhap.Text.Trim());
            Session["NhaTuyenDung"] = current_ct;
            Session["TenDangNhap"] = current_ct.TenDangNhap;
            Session["TenCongTy"] = current_ct.TenCongTy;
            Session["IDCongTy"] = current_ct.ID_CongTy;
            string returnUrl = Request.QueryString["returnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
                Response.Redirect(returnUrl);
            else
                Response.Redirect("NhaTuyenDung.aspx");
        }
        else
            Response.Write("<script> alert('Đăng nhập không thành công.')</script>");
    }
    protected void btnCT_Huy_Click(object sender, EventArgs e)
    {
        txtCT_MatKhau.Text = "";
        txtCT_TenDangNhap.Text = "";
    }
}