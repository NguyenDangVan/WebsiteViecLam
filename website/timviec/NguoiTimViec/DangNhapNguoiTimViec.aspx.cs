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

namespace timviec.NguoiTimViec
{
    public partial class DangNhapNguoiTimViec : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        clsEncrypt encrypt = new clsEncrypt();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtEmail_NguoiTimViec.Text = "";
            txtMKNguoiTimViec.Text = "";
        }

        protected void btnDNNguoiTimViec_Click(object sender, EventArgs e)
        {
            string matkhau = encrypt.GetMD5(txtMKNguoiTimViec.Text);
            var kq = (from n in data.UngViens
                      where (n.Email == txtEmail_NguoiTimViec.Text.Trim() && n.MatKhau == matkhau)
                      select n).FirstOrDefault();
            if (kq != null)
            {
                Session.SetCurrent_NguoiTimViec(kq, kq);
                string returnUrl = Request.QueryString["returnUrl"];
                if(!string.IsNullOrEmpty(returnUrl))
                    Response.Redirect(returnUrl);
                else
                    Response.Redirect("NguoiTimViec.aspx");
            }
            else
                Response.Write("<script> alert('Đăng nhập không thành công.')</script>");
        }
    }
}