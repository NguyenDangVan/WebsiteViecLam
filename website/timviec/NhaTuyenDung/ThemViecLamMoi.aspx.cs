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
    public partial class ThemViecLamMoi : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public string CurrentName_Company { get; set; }
        public int CurrentID_Company { get; set; }
        nganhNghe nghe = new nganhNghe();
        clsViTriLamViec vitri = new clsViTriLamViec();
        clsTrinhDo trinhdo = new clsTrinhDo();
        clsKinhNghiem kinhnghiem = new clsKinhNghiem();
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
            ddlVL_NganhNghe.DataSource = nghe.dsNganhNghe();
            ddlVL_NganhNghe.DataTextField = "TenNganhNghe";
            ddlVL_NganhNghe.DataValueField = "ID_NganhNghe";
            ddlVL_NganhNghe.DataBind();
        }

        protected void LoadViTri()
        {
            ddlVL_ViTri.DataSource = vitri.dsViTri();
            ddlVL_ViTri.DataTextField = "TenViTri";
            ddlVL_ViTri.DataValueField = "ID_ViTri";
            ddlVL_ViTri.DataBind();
        }

        protected void LoadTrinhDo()
        {
            ddlVL_TrinhDo.DataSource = trinhdo.dsTrinhDo();
            ddlVL_TrinhDo.DataTextField = "TenTrinhDo";
            ddlVL_TrinhDo.DataValueField = "ID_TrinhDo";
            ddlVL_TrinhDo.DataBind();
        }

        protected void LoadKinhNghiem()
        {
            ddlVL_KinhNghiem.DataSource = kinhnghiem.dsKinhNghiem();
            ddlVL_KinhNghiem.DataTextField = "TenKinhNghiem";
            ddlVL_KinhNghiem.DataValueField = "ID_KinhNghiem";
            ddlVL_KinhNghiem.DataBind();
        }

        protected void btnVL_Huy_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        protected void btnVL_Luu_Click(object sender, EventArgs e)
        {
            CongTy tenct = Session.GetName_NhaTuyenDung();
            CongTy idct = Session.GetID_NhaTuyenDung();
            CurrentID_Company = idct.ID_CongTy;
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
                                        luong, DateTime.Now, ngayhethan, false, CurrentID_Company, soluong, txtVL_HoSo.Text);
                    Response.Write("<script> alert('Thêm công việc thành công.')</script>");
                    ClearTextBox();
                }
                else
                    Response.Write("<script> alert('Ngày hết hạn phải lớn hơn ngày đăng.')</script>");
            }
            catch (Exception ex)
            {

            }
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
}