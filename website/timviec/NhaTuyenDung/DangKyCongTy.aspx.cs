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
    public partial class DangKyCongTy : System.Web.UI.Page
    {
        thanhPho tp = new thanhPho();
        clsEncrypt encrypt = new clsEncrypt();
        CongTyBLL ct = new CongTyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlThanhPho.DataSource = tp.dsThanhPho();
                ddlThanhPho.DataTextField = "TenThanhPho";
                ddlThanhPho.DataValueField = "ID_ThanhPho";
                ddlThanhPho.DataBind();
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        protected void btnDangKyCongTy_Click(object sender, EventArgs e)
        {
            string mahoaMK = encrypt.GetMD5(txtMKCongTy.Text);
            int thanhpho = Convert.ToInt32(ddlThanhPho.SelectedValue.ToString());
            if (ct.KiemTraTenDangNhapCT(txtTenDNCongTy.Text) == false)
            {
                Response.Write("<script> alert('Tên đăng nhập đã tồn tại vui lòng chọn tên khác.')</script>");
                txtTenDNCongTy.Text = "";
                txtTenDNCongTy.Focus();
            }
            else
            {
                ct.LuuCongTy(txtTenCongTy.Text, txtTenDNCongTy.Text, mahoaMK, txtDiaChiCongTy.Text, ddlQuyMo.SelectedValue,
                            txtSDTCongTy.Text, txtWebsite.Text, txtMoTa.Text, txtNguoiDaiDien.Text, txtEmail.Text, thanhpho);
                Response.Write("<script> alert('Đăng ký thành công.')</script>");
                ClearTextBox();
            }
        }
        //Xóa textbox
        private void ClearTextBox()
        {
            txtDiaChiCongTy.Text = "";
            txtEmail.Text = "";
            txtMKCongTy.Text = "";
            txtMoTa.Text = "";
            txtNguoiDaiDien.Text = "";
            txtSDTCongTy.Text = "";
            txtTenCongTy.Text = "";
            txtTenDNCongTy.Text = "";
            txtWebsite.Text = "";
        }

    }
}