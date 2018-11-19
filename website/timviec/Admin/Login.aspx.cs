using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using DAL;
using BLL;

namespace timviec.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdm_DangNhap_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != null && txtPassword.Text.Trim() != null)
            {
                var kq = (from n in data.TaiKhoans
                          where (n.TenDangNhap == txtUser.Text.Trim() && n.MatKhau == txtPassword.Text.Trim())
                          select n).FirstOrDefault();
                if (kq != null)
                {
                    Session.SetCurrent_Admin(kq);
                    string returnUrl = Request.QueryString["returnUrl"];
                    if (!string.IsNullOrEmpty(returnUrl))
                        Response.Redirect(returnUrl);
                    else
                        Response.Redirect("Admin.aspx");
                }
            }
            else
                Response.Write("<script> alert('Chưa nhập đầy đủ thông tin.')</script>");
        }

        protected void btnAdm_Huy_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUser.Text = "";
        }
    }
}