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
    public partial class DanhSachViecLam : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private string Name_TenCongTy { get; set; }
        private int ID_CongTy { get; set; }
        nganhNghe nnghe = new nganhNghe();
        clsViTriLamViec vitrilv = new clsViTriLamViec();
        clsTrinhDo tdo = new clsTrinhDo();
        clsKinhNghiem knghiem = new clsKinhNghiem();
        TinViecLamBLL vieclam = new TinViecLamBLL();
        protected override void OnInit(EventArgs e)
        {
            if (Session.GetName_NhaTuyenDung() == null)
            {
                Response.Redirect("DangNhapNhaTuyenDung.aspx?returnUrl=" + Request.Url.PathAndQuery);
            }
            base.OnInit(e);
        }

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

        //load danh sach viec lam
        private void LoadDSViecLam()
        {
            CongTy id = Session.GetID_NhaTuyenDung();
            ID_CongTy = id.ID_CongTy;
            var kq = from a in data.TinViecLams
                     join b in data.NganhNghes
                     on a.ID_NganhNghe equals b.ID_NganhNghe
                     join c in data.CongTies
                     on a.ID_CongTy equals c.ID_CongTy
                     join d in data.ThanhPhos
                     on c.ID_ThanhPho equals d.ID_ThanhPho
                     where (a.ID_CongTy == Convert.ToInt32(ID_CongTy))
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         b.TenNganhNghe,
                         d.TenThanhPho,
                         a.NgayDang,
                         a.NgayHetHan,
                         a.TrangThai
                     };
            grvDSVL_DSViecLam.DataSource = kq;
            grvDSVL_DSViecLam.DataBind();
        }

        protected void LoadNganhNghe()
        {
            ddlDSVL_NganhNghe.DataSource = nnghe.dsNganhNghe();
            ddlDSVL_NganhNghe.DataTextField = "TenNganhNghe";
            ddlDSVL_NganhNghe.DataValueField = "ID_NganhNghe";
            ddlDSVL_NganhNghe.DataBind();
        }

        protected void LoadViTri()
        {
            ddlDSVL_ViTri.DataSource = vitrilv.dsViTri();
            ddlDSVL_ViTri.DataTextField = "TenViTri";
            ddlDSVL_ViTri.DataValueField = "ID_ViTri";
            ddlDSVL_ViTri.DataBind();
        }

        protected void LoadTrinhDo()
        {
            ddlDSVL_TrinhDo.DataSource = tdo.dsTrinhDo();
            ddlDSVL_TrinhDo.DataTextField = "TenTrinhDo";
            ddlDSVL_TrinhDo.DataValueField = "ID_TrinhDo";
            ddlDSVL_TrinhDo.DataBind();
        }

        protected void LoadKinhNghiem()
        {
            ddlDSVL_KinhNghiem.DataSource = knghiem.dsKinhNghiem();
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

        protected void btnDSVL_Huy_Click(object sender, EventArgs e)
        {
            SuaDSVieclam.Visible = false;
            ClearTextBox();
        }

        protected void grvDSVL_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnEditDSVL_DSViecLam")
                {
                    var kq = (from n in data.TinViecLams
                              where (n.ID_ViecLam == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    lblDSVL_IDVL.Text = kq.ID_ViecLam.ToString();
                    txtDSVL_TenVieclam.Text = kq.TieuDeViecLam;
                    ddlDSVL_NganhNghe.SelectedValue = kq.ID_NganhNghe.ToString();
                    ddlDSVL_ViTri.SelectedValue = kq.ID_ViTri.ToString();
                    ddlDSVL_TrinhDo.SelectedValue = kq.ID_TrinhDo.ToString();
                    ddlDSVL_KinhNghiem.SelectedValue = kq.ID_KinhNghiem.ToString();
                    ddlDSVL_GioiTinh.SelectedValue = kq.GioiTinh.ToString();
                    txtDSVL_SoLuong.Text = kq.SoLuong.ToString();
                    txtDSVL_MoTa.Text = kq.MoTa;
                    txtDSVL_YeuCau.Text = kq.YeuCauKyNang;
                    ddlDSVL_ThuViec.SelectedValue = kq.ThoiGianThuViec.ToString();
                    ddlDSVL_MucLuong.SelectedValue = kq.MucLuong.ToString();
                    txtDSVL_HoSo.Text = kq.YeuCauHoSo;
                    txtDSVL_NgayHetHan.Text = kq.NgayHetHan.ToString();
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
            catch (Exception ex)
            { }
        }

        protected void grvDSVL_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadDSViecLam();
            grvDSVL_DSViecLam.PageIndex = e.NewPageIndex;
            grvDSVL_DSViecLam.DataBind();
        }

        protected void btnDSVL_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblDSVL_IDVL.Text);
                vieclam.CapNhapViecLam(id, txtDSVL_TenVieclam.Text, txtDSVL_MoTa.Text, int.Parse(ddlDSVL_NganhNghe.SelectedValue.ToString()), int.Parse(ddlDSVL_ViTri.SelectedValue.ToString()),
                                        ddlDSVL_GioiTinh.SelectedItem.ToString(), txtDSVL_YeuCau.Text, ddlDSVL_ThuViec.SelectedItem.ToString(), int.Parse(ddlDSVL_KinhNghiem.SelectedValue.ToString()),
                                        int.Parse(ddlDSVL_TrinhDo.SelectedValue.ToString()), ddlDSVL_MucLuong.SelectedItem.ToString(), Convert.ToDateTime(txtDSVL_NgayHetHan.Text), false,
                                        int.Parse(txtDSVL_SoLuong.Text), txtDSVL_HoSo.Text);
                LoadDSViecLam();
                SuaDSVieclam.Visible = false;
            }
            catch (Exception ex)
            { }
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
}