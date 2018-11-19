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
    public partial class UngVienDaUngTuyen : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        //private string Name_TenCongTy { get; set; }
        private int ID_CongTy { get; set; }
        private DangKyBLL dk = new DangKyBLL();

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
                LoadDSUVUngTuyen();
                UVUngTuyen_ChiTiet.Visible = false;
            }
        }

        //load ds ung vien da ung tuyen
        private void LoadDSUVUngTuyen()
        {
            CongTy id = Session.GetID_NhaTuyenDung();
            ID_CongTy = id.ID_CongTy;
            var kq = from a in data.DangKies
                     join b in data.TinViecLams
                     on a.ID_ViecLam equals b.ID_ViecLam
                     join c in data.CongTies
                     on b.ID_CongTy equals c.ID_CongTy
                     join d in data.CV_UngViens
                     on a.ID_CV equals d.ID_CV
                     join f in data.TrinhDos
                     on d.ID_TrinhDo equals f.ID_TrinhDo
                     join g in data.KinhNghiems
                     on d.ID_KinhNghiem equals g.ID_KinhNghiem
                     join h in data.ViTriUngTuyens
                     on d.ID_ViTri equals h.ID_ViTri
                     join k in data.UngViens
                     on d.ID_UngVien equals k.ID_UngVien
                     where (b.ID_CongTy == Convert.ToInt32(ID_CongTy))
                     select new
                     {
                         a.ID_DangKy,
                         k.HoTen,
                         b.TieuDeViecLam,
                         a.NgayUngTuyen,
                         g.TenKinhNghiem
                     };
            grvUVUngTuyen_DSUVUngTuyen.DataSource = kq;
            grvUVUngTuyen_DSUVUngTuyen.DataBind();
        }

        protected void grvUVUngTuyen_DSUVUngTuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUVUngTuyen_DSUVUngTuyen.PageIndex = e.NewPageIndex;
            grvUVUngTuyen_DSUVUngTuyen.DataBind();
            LoadDSUVUngTuyen();
        }

        protected void grvUVUngTuyen_DSUVUngTuyen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtXem_UVUngTuyen_DSUVUngTuyen")
                {
                    var kq = (from a in data.DangKies
                              join b in data.TinViecLams
                              on a.ID_ViecLam equals b.ID_ViecLam
                              join c in data.CongTies
                              on b.ID_CongTy equals c.ID_CongTy
                              join d in data.CV_UngViens
                              on a.ID_CV equals d.ID_CV
                              join f in data.TrinhDos
                              on d.ID_TrinhDo equals f.ID_TrinhDo
                              join g in data.KinhNghiems
                              on d.ID_KinhNghiem equals g.ID_KinhNghiem
                              join h in data.ViTriUngTuyens
                              on d.ID_ViTri equals h.ID_ViTri
                              join k in data.UngViens
                              on d.ID_UngVien equals k.ID_UngVien
                              where (a.ID_DangKy == Convert.ToInt32(e.CommandArgument.ToString()))
                              select new
                              {
                                  a.ID_DangKy,
                                  k.HoTen,
                                  k.NgaySinh,
                                  k.GioiTinh,
                                  k.DiaChi,
                                  k.Email,
                                  k.SDT,
                                  d.TieuDe,
                                  h.TenViTri,
                                  f.TenTrinhDo,
                                  g.TenKinhNghiem,
                                  b.YeuCauKyNang,
                                  d.KyNang,
                                  d.NgoaiNgu,
                                  d.MucLuong,
                                  d.BangCap,
                                  b.TieuDeViecLam,
                              }).SingleOrDefault();
                    //day du lieu xuong textbox
                    lblUVUngTuyen_TieuDeVieclam.Text = kq.TieuDeViecLam;
                    txtUVUngTuyen_HoTen.Text = kq.HoTen;
                    txtUVUngTuyen_NgaySinh.Text = String.Format("{0:d}", kq.NgaySinh);
                    txtUVUngTuyen_GioiTinh.Text = kq.GioiTinh;
                    txtUVUngTuyen_DiaChi.Text = kq.DiaChi;
                    txtUVUngTuyen_Email.Text = kq.Email;
                    txtUVUngTuyen_SDT.Text = kq.SDT;
                    txtUVUngTuyen_TieuDe.Text = kq.TieuDe;
                    txtUVUngTuyen_ViTri.Text = kq.TenViTri;
                    txtUVUngTuyen_TrinhDo.Text = kq.TenTrinhDo;
                    txtUVUngTuyen_KinhNghiem.Text = kq.TenKinhNghiem;
                    txtUVUngTuyen_YeuCauKyNang.Text = kq.YeuCauKyNang;
                    txtUVUngTuyen_KyNang.Text = kq.KyNang;
                    txtUVUngTuyen_NgoaiNgu.Text = kq.NgoaiNgu;
                    txtUVUngTuyen_MucLuong.Text = kq.MucLuong;
                    txtUVUngTuyen_BangCap.Text = kq.BangCap;

                    UVUngTuyen_ChiTiet.Visible = true;
                    //cap nhat them ngay xem va trang thai vao bang dang ky
                    dk.CapNhatDK(int.Parse(e.CommandArgument.ToString()), DateTime.Now, true);
                }
                if (e.CommandName == "lbtXoa_UVUngTuyen_DSUVUngTuyen")
                {
                    int id = int.Parse(e.CommandArgument.ToString());
                    dk.XoaDangKy(id);
                    LoadDSUVUngTuyen();
                    //UVUngTuyen_ChiTiet.Visible = false;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void lnkUVUngTuyen_TimKiemUV_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
        }

        protected void lnkUVUngTuyen_ThemViecLam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
        }

        protected void lnkUVUngTuyen_DSViecLam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
        }

        protected void lnkUVUngTuyen_UngVienDaUngTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
        }

        protected void btnTimUV_OK_Click(object sender, EventArgs e)
        {
            UVUngTuyen_ChiTiet.Visible = false;
        }
    }
}