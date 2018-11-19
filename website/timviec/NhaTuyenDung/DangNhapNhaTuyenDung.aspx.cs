using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data;
using DAL;
using BLL;

namespace timviec.NhaTuyenDung
{
    public partial class DangNhapNhaTuyenDung : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        clsEncrypt encrypt = new clsEncrypt();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCT_Huy_Click(object sender, EventArgs e)
        {
            txtCT_MatKhau.Text = "";
            txtCT_TenDangNhap.Text = "";
        }

        protected void btnCT_DangNhap_Click(object sender, EventArgs e)
        {
            string matkhau = encrypt.GetMD5(txtCT_MatKhau.Text);
            var kq = (from n in data.CongTies
                      where (n.TenDangNhap == txtCT_TenDangNhap.Text.Trim() && n.MatKhau == matkhau)
                      select n).FirstOrDefault();
            if (kq != null)
            {
                Session.SetCurrent_NhaTuyenDung(kq, kq);
                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                    Response.Redirect(returnUrl);
                else
                    Response.Redirect("NhaTuyenDung.aspx");
            }
            else
                Response.Write("<script> alert('Đăng nhập không thành công.')</script>");
        }

    }
}