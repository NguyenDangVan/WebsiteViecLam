using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_DangKyCongTy : System.Web.UI.Page
{
    CongTyBLL congty = new CongTyBLL();
    clsEncrypt encrypt = new clsEncrypt();
    ThanhPho tp = new ThanhPho();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlThanhPho.DataSource = tp.LoadDuLieu();
            ddlThanhPho.DataTextField = "TenThanhPho";
            ddlThanhPho.DataValueField = "ID_ThanhPho";
            ddlThanhPho.DataBind();
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
    }
    protected void btnDangKyCongTy_Click(object sender, EventArgs e)
    {
        CongTy ct = new CongTy();
        string mahoaMK = encrypt.GetMD5(txtMKCongTy.Text);
        int thanhpho = Convert.ToInt32(ddlThanhPho.SelectedValue.ToString());
        if (congty.KiemTraTenDangNhapCT(txtTenDNCongTy.Text) == false)
        {
            Response.Write("<script> alert('Tên đăng nhập đã tồn tại vui lòng chọn tên khác.')</script>");
            txtTenDNCongTy.Text = "";
            txtTenDNCongTy.Focus();
        }
        else
        {
            ct.TenCongTy = txtTenCongTy.Text;
            ct.TenDangNhap = txtTenDNCongTy.Text;
            ct.MatKhau = mahoaMK;
            ct.DiaChi = txtDiaChiCongTy.Text;
            ct.QuyMo = ddlQuyMo.SelectedValue;
            ct.SDT = txtSDTCongTy.Text;
            ct.MoTa = txtMoTa.Text;
            ct.NguoiDaiDien = txtNguoiDaiDien.Text;
            ct.Email = txtEmail.Text;
            ct.ID_ThanhPho = thanhpho;
            try 
            {
                congty.LuuCongTy(ct);
                Response.Write("<script> alert('Đăng ký thành công.')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script> alert('Đăng ký không thành công.')</script>");
            }
            
            ClearTextBox();
        }
    }
}