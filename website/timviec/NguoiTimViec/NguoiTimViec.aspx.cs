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
    public partial class NguoiTimViec : System.Web.UI.Page
    {
        public string CurrentName { get; set; }
        public int CurrentID { get; set; }

        TimViecDBDataContext data = new TimViecDBDataContext();

        nganhNghe nn = new nganhNghe();
        clsViTriLamViec vt = new clsViTriLamViec();
        clsTrinhDo td = new clsTrinhDo();
        clsKinhNghiem kn = new clsKinhNghiem();
        CV_UngVienBLL cv = new CV_UngVienBLL();

        protected override void OnInit(EventArgs e)
        {
            if (Session.GetName_NguoiTimViec() == null)
            {
                Response.Redirect("DangNhapNguoiTimViec.aspx?returnUrl=" + Request.Url.PathAndQuery);
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UngVien ten = Session.GetName_NguoiTimViec();
            UngVien id = Session.GetID_NguoiTimViec();
            CurrentID = id.ID_UngVien;
            string gioitinh = "";
            UV_HoSoUngVien.Visible = false;
            //var kq = from n in data.UngViens
            //         where (n.ID_UngVien == Convert.ToInt32(id))
            //         select n;
            if (ten != null)
            {
                CurrentName = ten.HoTen;
                CurrentID = id.ID_UngVien;
                lblHoTen.Text = CurrentName;
                lblDiaChi.Text = ten.DiaChi;
                lblEmail.Text = ten.Email;
                lblGioiTinh.Text = gioitinh;
                lblNgaySinh.Text = Convert.ToString(String.Format("{0:d}", ten.NgaySinh));
                lblSDT.Text = ten.SDT;
            }
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
            ddlUV_NganhNghe.DataSource = nn.dsNganhNghe();
            ddlUV_NganhNghe.DataTextField = "TenNganhNghe";
            ddlUV_NganhNghe.DataValueField = "ID_NganhNghe";
            ddlUV_NganhNghe.DataBind();
        }

        protected void LoadViTri()
        {
            ddlUV_ViTri.DataSource = vt.dsViTri();
            ddlUV_ViTri.DataTextField = "TenViTri";
            ddlUV_ViTri.DataValueField = "ID_ViTri";
            ddlUV_ViTri.DataBind();
        }

        protected void LoadTrinhDo()
        {
            ddlUV_TrinhDo.DataSource = td.dsTrinhDo();
            ddlUV_TrinhDo.DataTextField = "TenTrinhDo";
            ddlUV_TrinhDo.DataValueField = "ID_TrinhDo";
            ddlUV_TrinhDo.DataBind();
        }

        protected void LoadKinhNghiem()
        {
            ddlUV_KinhNghiem.DataSource = kn.dsKinhNghiem();
            ddlUV_KinhNghiem.DataTextField = "TenKinhNghiem";
            ddlUV_KinhNghiem.DataValueField = "ID_KinhNghiem";
            ddlUV_KinhNghiem.DataBind();
        }

        private void ClearTextBox()
        {
            txtUV_BangCap.Text = "";
            txtUV_KyNang.Text = "";
            txtUV_NgoaiNgu.Text = "";
            txtUV_TieuDe.Text = "";
        }

        protected void btnUV_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                UngVien id = Session.GetID_NguoiTimViec();
                CurrentID = id.ID_UngVien;
                cv.LuuCVUngVien(CurrentID, txtUV_TieuDe.Text, Convert.ToInt32(ddlUV_NganhNghe.SelectedValue.ToString()), txtUV_KyNang.Text, Convert.ToInt32(ddlUV_ViTri.SelectedValue.ToString()),
                                Convert.ToInt32(ddlUV_TrinhDo.SelectedValue.ToString()), Convert.ToInt32(ddlUV_KinhNghiem.SelectedValue.ToString()), txtUV_NgoaiNgu.Text,
                                ddlUV_MucLuong.SelectedItem.ToString(), txtUV_BangCap.Text, false);
                Response.Write("<script> alert('Lưu thành công.')</script>");
                ClearTextBox();
            }
            catch (Exception ex)
            { }
        }

        protected void btnUV_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                UngVien id = Session.GetID_NguoiTimViec();
                CurrentID = id.ID_UngVien;
                var kq = from n in data.CV_UngViens
                         where (n.ID_UngVien == CurrentID)
                         select n;
                foreach (var s in kq)
                    lblID_CVUngVien.Text = s.ID_CV.ToString();
                cv.CapNhatCV(Convert.ToInt32(lblID_CVUngVien.Text), txtUV_TieuDe.Text, Convert.ToInt32(ddlUV_NganhNghe.SelectedValue.ToString()), txtUV_KyNang.Text,
                             Convert.ToInt32(ddlUV_ViTri.SelectedValue.ToString()), Convert.ToInt32(ddlUV_TrinhDo.SelectedValue.ToString()), Convert.ToInt32(ddlUV_KinhNghiem.SelectedValue.ToString()),
                             txtUV_NgoaiNgu.Text, ddlUV_MucLuong.SelectedValue.ToString(), txtUV_BangCap.Text);
                Response.Write("<script> alert('Cập nhật thành công.')</script>");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnUV_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                UngVien id = Session.GetID_NguoiTimViec();
                CurrentID = id.ID_UngVien;
                var kq = from n in data.CV_UngViens
                         where (n.ID_UngVien == CurrentID)
                         select n;
                foreach (var s in kq)
                    lblID_CVUngVien.Text = s.ID_CV.ToString();
                cv.XoaCV(Convert.ToInt32(lblID_CVUngVien.Text));
                Response.Write("<script> alert('Xóa thành công.')</script>");
                UV_HoSoUngVien.Visible = false;
            }
            catch (Exception ex)
            { }
        }

        protected void btnUV_XemCV_Click(object sender, EventArgs e)
        {
            UV_HoSoUngVien.Visible = true;
            try
            {
                UngVien ten = Session.GetName_NguoiTimViec();
                UngVien id = Session.GetID_NguoiTimViec();
                CurrentID = id.ID_UngVien;
                var query = (from n in data.CV_UngViens
                             where (n.ID_UngVien == CurrentID)
                             select n);
                //if (query == null)
                //{
                //    ClearTextBox();
                //    btnUV_Luu.Visible = true;
                //}
                //else
                //{
                foreach (var s in query)
                {
                    if (s.ID_UngVien != null)
                    {
                        if (s.TrangThai == false)
                        {
                            btnUV_Luu.Visible = true;
                            lblThongBao.Text = "Chưa kích hoạt";
                        }
                        else
                        {
                            lblThongBao.Text = "Đã kích hoạt";
                            lblID_CVUngVien.Text = s.ID_CV.ToString();
                            txtUV_TieuDe.Text = s.TieuDe;
                            ddlUV_NganhNghe.SelectedValue = s.ID_NganhNghe.ToString();
                            ddlUV_ViTri.SelectedValue = s.ID_ViTri.ToString();
                            ddlUV_TrinhDo.SelectedValue = s.ID_TrinhDo.ToString();
                            ddlUV_KinhNghiem.SelectedValue = s.ID_KinhNghiem.ToString();
                            txtUV_KyNang.Text = s.KyNang;
                            txtUV_NgoaiNgu.Text = s.NgoaiNgu;
                            ddlUV_MucLuong.SelectedValue = s.MucLuong.ToString();
                            txtUV_BangCap.Text = s.BangCap;
                        }
                        btnUV_Luu.Visible = false;
                    }
                    else
                    {
                        ClearTextBox();
                        btnUV_Luu.Visible = true;
                    }
                }
                //}
            }
            catch (Exception ex)
            { }
        }

        protected void lnkTuHoSo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
        }

        protected void lnkTaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
        }

        protected void lnkViecLamUngTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/ViecLamDaUngTuyen.aspx");
        }

        protected void lnkNhaTuyenDungXemHoSo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NhaTuyenDungXemHoSo.aspx");
        }
    }
}