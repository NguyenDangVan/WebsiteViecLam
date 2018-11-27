using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_NhaTuyenDung : System.Web.UI.Page
{
    ThanhPho tp = new ThanhPho();
    CongTyBLL ctbll = new CongTyBLL();
    public int CurrentID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ThongTinCongTy.Visible = true;
        SuaThongTinCongTy.Visible = false;
        if (!Page.IsPostBack)
        {
            LoadThanhPho();
            EnableTextBox(false);
        }
        string tendangnhap = (string)Session["TenDangNhap"];
        CongTy ct = new CongTy();
        ct = ctbll.Get_CongTy(tendangnhap);
        if (ct != null)
        {
            CurrentID = ct.ID_CongTy;
            lblNTD_DiaChi.Text = ct.DiaChi;
            lblNTD_Email.Text = ct.Email;
            lblNTD_MoTa.Text = ct.MoTa;
            lblNTD_NguoiDaiDien.Text = ct.NguoiDaiDien;
            lblNTD_SDT.Text = ct.SDT;
            lblNTD_TenCongTy.Text = ct.TenCongTy;
            
            lblNTD_QuyMo.Text = ct.QuyMo;
        }
    }
    private void LoadThanhPho()
    {
        ddlNTD_ThanhPho.DataSource = tp.LoadDuLieu();
        ddlNTD_ThanhPho.DataTextField = "TenThanhPho";
        ddlNTD_ThanhPho.DataValueField = "ID_ThanhPho";
        ddlNTD_ThanhPho.DataBind();
    }
    private void EnableTextBox(bool status)
    {
        txtNTD_DiaChi.Enabled = status;
        txtNTD_Email.Enabled = status;
        txtNTD_MoTa.Enabled = status;
        txtNTD_NguoiDaiDien.Enabled = status;
        txtNTD_SDT.Enabled = status;
        txtNTD_TenCongTy.Enabled = status;
        ddlNTD_QuyMo.Enabled = status;
        ddlNTD_ThanhPho.Enabled = status;
    }
    protected void btnNTD_CapNhat_Click(object sender, EventArgs e)
    {
        EnableTextBox(true);
        SuaThongTinCongTy.Visible = true;
        ThongTinCongTy.Visible = false;
        string tendangnhap = (string)Session["TenDangNhap"];
        CongTy ct = new CongTy();
        ct = ctbll.Get_CongTy(tendangnhap);
        if (ct != null)
        {
            CurrentID = ct.ID_CongTy;
            txtNTD_DiaChi.Text = ct.DiaChi;
            txtNTD_Email.Text = ct.Email;
            txtNTD_MoTa.Text = ct.MoTa;
            txtNTD_NguoiDaiDien.Text = ct.NguoiDaiDien;
            txtNTD_SDT.Text = ct.SDT;
            txtNTD_TenCongTy.Text = ct.TenCongTy;
            ddlNTD_QuyMo.SelectedValue = ct.QuyMo.ToString();
            ddlNTD_ThanhPho.SelectedValue = ct.ID_ThanhPho.ToString();
        }
    }
    protected void btnNTD_DongY_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentID = (int)Session["IDCongTy"];
            ctbll.CapNhatCongTy(CurrentID, txtNTD_TenCongTy.Text, txtNTD_DiaChi.Text, Convert.ToInt32(ddlNTD_ThanhPho.SelectedValue.ToString()), txtNTD_SDT.Text,
                    txtNTD_MoTa.Text, ddlNTD_QuyMo.SelectedItem.ToString(), txtNTD_Email.Text, txtNTD_NguoiDaiDien.Text );
            ThongTinCongTy.Visible = true;
            SuaThongTinCongTy.Visible = false;
            Response.Redirect("~/NhaTuyenDung/NhaTuyenDung.aspx");
            Response.Write("<script> alert('Cập nhật thành công.')</script>");
            
        }
        catch (Exception)
        {
            Response.Write("<script> alert('Cập nhật không thành công.')</script>");
        }
    }
    protected void btnNTD_Huy_Click(object sender, EventArgs e)
    {
        EnableTextBox(false);
    }
    protected void lnkTD_TimKiemUV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
    }
    protected void lnkTD_ThemViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
    }
    protected void lnkTD_DSCongViec_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
    }
    protected void lnkTD_UngVienDaUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
    }
}