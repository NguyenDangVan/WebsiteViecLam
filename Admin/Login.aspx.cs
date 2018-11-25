using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    LoaiTaiKhoanBLL tk = new LoaiTaiKhoanBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdm_DangNhap_Click(object sender, EventArgs e)
    {
        if (txtUser.Text.Trim() != null && txtPassword.Text.Trim() != null)
        {
            bool kq = tk.KiemTraTK(txtUser.Text.Trim(), txtPassword.Text.Trim());
            //var kq = (from n in data.TaiKhoans
            //          where (n.TenDangNhap == txtUser.Text.Trim() && n.MatKhau == txtPassword.Text.Trim())
            //          select n).FirstOrDefault();
            if (kq == true)
            {
                //Session.SetCurrent_Admin(kq);
                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                    Response.Redirect(returnUrl);
                else
                    Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Write("<script> alert('Tên đăng nhập hoặc mật khẩu không đúng.')</script>");
                txtPassword.Text = "";
                txtUser.Text = "";
                txtUser.Focus();
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
    protected void lbtAdm_DangKyTaiKhoan_Click(object sender, EventArgs e)
    {
        
    }
}