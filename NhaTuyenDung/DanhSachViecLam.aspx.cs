using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NhaTuyenDung_DanhSachViecLam : System.Web.UI.Page
{
    NganhNghe nghe = new NganhNghe();
    ViTriBLL vitri = new ViTriBLL();
    TrinhDoBLL trinhdo = new TrinhDoBLL();
    KinhNghiemBLL kinhnghiem = new KinhNghiemBLL();
    ViecLam vieclam = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        SuaDSVieclam.Visible = false;
        if (!Page.IsPostBack)
        {
            LoadNganhNghe();
            LoadViTri();
            LoadTrinhDo();
            LoadKinhNghiem();
            LoadDSViecLam();
        }
    }
    private void LoadDSViecLam()
    {
        if(Session["IDCongTy"] != null)
        {
            int idct = (int)Session["IDCongTy"];
            grvDSVL_DSViecLam.DataSource = vieclam.DsViecLam_CT(idct);
            grvDSVL_DSViecLam.DataBind();
        }
        
    }
    protected void LoadNganhNghe()
    {
        ddlDSVL_NganhNghe.DataSource = nghe.DsNganhNghe();
        ddlDSVL_NganhNghe.DataTextField = "TenNganhNghe";
        ddlDSVL_NganhNghe.DataValueField = "ID_NganhNghe";
        ddlDSVL_NganhNghe.DataBind();
    }
    protected void LoadViTri()
    {
        ddlDSVL_ViTri.DataSource = vitri.DsViTri();
        ddlDSVL_ViTri.DataTextField = "TenViTri";
        ddlDSVL_ViTri.DataValueField = "ID_ViTri";
        ddlDSVL_ViTri.DataBind();
    }
    protected void LoadTrinhDo()
    {
        ddlDSVL_TrinhDo.DataSource = trinhdo.DsTrinhDo();
        ddlDSVL_TrinhDo.DataTextField = "TenTrinhDo";
        ddlDSVL_TrinhDo.DataValueField = "ID_TrinhDo";
        ddlDSVL_TrinhDo.DataBind();
    }
    protected void LoadKinhNghiem()
    {
        ddlDSVL_KinhNghiem.DataSource = kinhnghiem.DsKinhNghiem();
        ddlDSVL_KinhNghiem.DataTextField = "TenKinhNghiem";
        ddlDSVL_KinhNghiem.DataValueField = "ID_KinhNghiem";
        ddlDSVL_KinhNghiem.DataBind();
    }
    private void ClearTextBox()
    {
        txtDSVL_HoSo.Text = "";
        txtDSVL_MoTa.Text = "";
        txtDSVL_NgayHetHan.Text = "";
        txtDSVL_SoLuong.Text = "";
        txtDSVL_TenVieclam.Text = "";
        txtDSVL_YeuCau.Text = "";
    }
    protected void grvDSVL_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEditDSVL_DSViecLam")
            {
                int idvieclam = int.Parse(e.CommandArgument.ToString());
                DataTable dt = new DataTable();
                dt = vieclam.DsViecLam(idvieclam);
                lblDSVL_IDVL.Text = dt.Rows[0]["ID_ViecLam"].ToString();
                txtDSVL_TenVieclam.Text = dt.Rows[0]["TieuDeViecLam"].ToString();
                ddlDSVL_NganhNghe.SelectedValue = dt.Rows[0]["ID_NganhNghe"].ToString();
                ddlDSVL_ViTri.SelectedValue = dt.Rows[0]["ID_ViTri"].ToString();
                ddlDSVL_TrinhDo.SelectedValue = dt.Rows[0]["ID_TrinhDo"].ToString();
                ddlDSVL_KinhNghiem.SelectedValue = dt.Rows[0]["ID_KinhNghiem"].ToString();
                ddlDSVL_GioiTinh.SelectedValue = dt.Rows[0]["GioiTinh"].ToString();
                txtDSVL_SoLuong.Text = dt.Rows[0]["SoLuong"].ToString();
                txtDSVL_MoTa.Text = dt.Rows[0]["MoTa"].ToString();
                txtDSVL_YeuCau.Text = dt.Rows[0]["YeuCauKyNang"].ToString();
                ddlDSVL_ThuViec.SelectedValue = dt.Rows[0]["ThoiGianThuViec"].ToString();
                ddlDSVL_MucLuong.SelectedValue = dt.Rows[0]["MucLuong"].ToString();
                txtDSVL_HoSo.Text = dt.Rows[0]["YeuCauHoSo"].ToString();
                txtDSVL_NgayHetHan.Text = dt.Rows[0]["NgayHetHan"].ToString();
                SuaDSVieclam.Visible = true;
            }
            if (e.CommandName == "btnDeleteDSVL_DSViecLam")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                vieclam.XoaViecLam(id);
                LoadDSViecLam();
                SuaDSVieclam.Visible = false;
            }
        }
        catch (Exception)
        { }
    }
    protected void grvDSVL_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //LoadDSViecLam();
        grvDSVL_DSViecLam.PageIndex = e.NewPageIndex;
        grvDSVL_DSViecLam.DataBind();
    }
    protected void btnDSVL_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(lblDSVL_IDVL.Text);
            vieclam.CapNhatViecLam(id, txtDSVL_TenVieclam.Text, txtDSVL_MoTa.Text, int.Parse(ddlDSVL_NganhNghe.SelectedValue.ToString()), int.Parse(ddlDSVL_ViTri.SelectedValue.ToString()),
                                    ddlDSVL_GioiTinh.SelectedItem.ToString(), txtDSVL_YeuCau.Text, ddlDSVL_ThuViec.SelectedItem.ToString(), int.Parse(ddlDSVL_KinhNghiem.SelectedValue.ToString()),
                                    int.Parse(ddlDSVL_TrinhDo.SelectedValue.ToString()), ddlDSVL_MucLuong.SelectedItem.ToString(), String.Format("{0:MM-dd-yyyy}", Convert.ToDateTime(txtDSVL_NgayHetHan.Text)), 0,
                                    int.Parse(txtDSVL_SoLuong.Text), txtDSVL_HoSo.Text);
            LoadDSViecLam();
            SuaDSVieclam.Visible = false;
        }
        catch (Exception ex)
        { }
    }
    protected void btnDSVL_Huy_Click(object sender, EventArgs e)
    {
        SuaDSVieclam.Visible = false;
        ClearTextBox();
    }
    protected void lnkDSVL_TimKiemUV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
    }
    protected void lnkDSVL_ThemViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
    }
    protected void lnkDSVL_DSViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
    }
    protected void lnkDSVL_UngVienDaUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
    }
}