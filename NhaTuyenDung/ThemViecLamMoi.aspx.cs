using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaTuyenDung_ThemViecLamMoi : System.Web.UI.Page
{
    NganhNghe nghe = new NganhNghe();
    ViTriBLL vitri = new ViTriBLL();
    TrinhDoBLL trinhdo = new TrinhDoBLL();
    KinhNghiemBLL kinhnghiem = new KinhNghiemBLL();
    ViecLam vieclam = new ViecLam();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadNganhNghe();
            LoadViTri();
            LoadTrinhDo();
            LoadKinhNghiem();
        }
    }
    protected void LoadNganhNghe()
    {
        ddlVL_NganhNghe.DataSource = nghe.DsNganhNghe();
        ddlVL_NganhNghe.DataTextField = "TenNganhNghe";
        ddlVL_NganhNghe.DataValueField = "ID_NganhNghe";
        ddlVL_NganhNghe.DataBind();
    }
    protected void LoadViTri()
    {
        ddlVL_ViTri.DataSource = vitri.DsViTri();
        ddlVL_ViTri.DataTextField = "TenViTri";
        ddlVL_ViTri.DataValueField = "ID_ViTri";
        ddlVL_ViTri.DataBind();
    }
    protected void LoadTrinhDo()
    {
        ddlVL_TrinhDo.DataSource = trinhdo.DsTrinhDo();
        ddlVL_TrinhDo.DataTextField = "TenTrinhDo";
        ddlVL_TrinhDo.DataValueField = "ID_TrinhDo";
        ddlVL_TrinhDo.DataBind();
    }
    protected void LoadKinhNghiem()
    {
        ddlVL_KinhNghiem.DataSource = kinhnghiem.DsKinhNghiem();
        ddlVL_KinhNghiem.DataTextField = "TenKinhNghiem";
        ddlVL_KinhNghiem.DataValueField = "ID_KinhNghiem";
        ddlVL_KinhNghiem.DataBind();
    }
    private void ClearTextBox()
    {
        txtVL_HoSo.Text = "";
        txtVL_MoTa.Text = "";
        txtVL_NgayHetHan.Text = "";
        txtVL_SoLuong.Text = "";
        txtVL_TenVieclam.Text = "";
        txtVL_YeuCau.Text = "";
    }
    protected void btnVL_Luu_Click(object sender, EventArgs e)
    {
        //CongTy tenct = Session.GetName_NhaTuyenDung();
        //CongTy idct = Session.GetID_NhaTuyenDung();
        //CurrentID_Company = idct.ID_CongTy;
        try
        {
            if (Session["IDCongTy"] != null)
            {
                int CurrentID_Company = (int)Session["IDCongTy"];
                DateTime ngayhethan = Convert.ToDateTime(txtVL_NgayHetHan.Text.ToString());

                string gioitinh = ddlVL_GioiTinh.SelectedItem.ToString();
                string thuviec = ddlVL_ThuViec.SelectedItem.ToString();
                string luong = ddlVL_MucLuong.SelectedItem.ToString();
                int soluong = Convert.ToInt32(txtVL_SoLuong.Text);
                try
                {

                    if (ngayhethan > DateTime.Now)
                    {

                        vieclam.LuuViecLam(txtVL_TenVieclam.Text, txtVL_MoTa.Text, int.Parse(ddlVL_NganhNghe.SelectedValue.ToString()), int.Parse(ddlVL_ViTri.SelectedValue.ToString()),
                                            gioitinh, txtVL_YeuCau.Text, thuviec, int.Parse(ddlVL_KinhNghiem.SelectedValue.ToString()), int.Parse(ddlVL_TrinhDo.SelectedValue.ToString()),
                                            luong, String.Format("{0:MM-dd-yyyy}", DateTime.Now), String.Format("{0:MM-dd-yyyy}", ngayhethan), 0, CurrentID_Company, soluong, txtVL_HoSo.Text);
                        Response.Write("<script> alert('Thêm công việc thành công.')</script>");
                        ClearTextBox();
                    }
                    else
                        Response.Write("<script> alert('Ngày hết hạn phải lớn hơn ngày đăng.')</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script> alert('Thêm công việc thất bại.')</script>");
                }
            }
            else
            {
                Response.Redirect("~/DangNhap.aspx");
                Response.Write("<script> alert('Bạn chưa đăng nhâp.')</script>");
            }
        }
        catch
        {

        }
    }
    protected void btnVL_Huy_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void lnkVL_TimKiemUV_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
    }

    protected void lnkVL_ThemViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
    }

    protected void lnkVL_UngVienDaUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
    }

    protected void lnkVL_DSViecLam_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
    }
}