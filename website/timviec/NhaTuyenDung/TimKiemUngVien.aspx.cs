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
    public partial class TimKiemUngVien : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private nganhNghe nn = new nganhNghe();
        private thanhPho tp = new thanhPho();
        private clsTrinhDo td = new clsTrinhDo();
        private clsKinhNghiem kn = new clsKinhNghiem();
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
                LoadUV();
                loadKinhNghiem();
                loadNganhNghe();
                loadThanhPho();
                loadTrinhDo();
            }
            TimUV_ChiTietUngVien.Visible = false;
        }

        private void loadNganhNghe()
        {
            ddlTimUV_NganhNghe.DataSource = nn.dsNganhNghe();
            ddlTimUV_NganhNghe.DataValueField = "ID_NganhNghe";
            ddlTimUV_NganhNghe.DataTextField = "TenNganhNghe";
            ddlTimUV_NganhNghe.DataBind();
        }

        private void loadThanhPho()
        {
            ddlTimUV_ThanhPho.DataSource = tp.dsThanhPho();
            ddlTimUV_ThanhPho.DataValueField = "ID_ThanhPho";
            ddlTimUV_ThanhPho.DataTextField = "TenThanhPho";
            ddlTimUV_ThanhPho.DataBind();
        }

        private void loadTrinhDo()
        {
            ddlTimUV_TrinhDo.DataSource = td.dsTrinhDo();
            ddlTimUV_TrinhDo.DataValueField = "ID_TrinhDo";
            ddlTimUV_TrinhDo.DataTextField = "TenTrinhDo";
            ddlTimUV_TrinhDo.DataBind();
        }

        private void loadKinhNghiem()
        {
            ddlTimUV_KinhNghiem.DataSource = kn.dsKinhNghiem();
            ddlTimUV_KinhNghiem.DataValueField = "ID_KinhNghiem";
            ddlTimUV_KinhNghiem.DataTextField = "TenKinhNghiem";
            ddlTimUV_KinhNghiem.DataBind();
        }

        // load ds ung viên
        private void LoadUV()
        {
            var kq = from m in data.CV_UngViens
                     join n in data.UngViens
                     on m.ID_UngVien equals n.ID_UngVien
                     join h in data.NganhNghes
                     on m.ID_NganhNghe equals h.ID_NganhNghe
                     join k in data.ThanhPhos
                     on n.ID_ThanhPho equals k.ID_ThanhPho
                     join l in data.KinhNghiems
                     on m.ID_KinhNghiem equals l.ID_KinhNghiem
                     where (m.TrangThai == true)
                     select new
                     {
                         m.ID_CV,
                         n.HoTen,
                         h.TenNganhNghe,
                         m.TieuDe,
                         k.TenThanhPho,
                         l.TenKinhNghiem
                     };
            grvTimUV_DSUngVien.DataSource = kq;
            grvTimUV_DSUngVien.DataBind();
        }

        protected void grvTimUV_DSUngVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTimUV_DSUngVien.PageIndex = e.NewPageIndex;
            grvTimUV_DSUngVien.DataBind();
            LoadUV();
        }

        protected void grvTimUV_DSUngVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtTimUV_DSUngVien")
                {
                    var kq = (from a in data.CV_UngViens
                              join b in data.UngViens
                              on a.ID_UngVien equals b.ID_UngVien
                              join c in data.NganhNghes
                              on a.ID_NganhNghe equals c.ID_NganhNghe
                              join d in data.ViTriUngTuyens
                              on a.ID_ViTri equals d.ID_ViTri
                              join f in data.TrinhDos
                              on a.ID_TrinhDo equals f.ID_TrinhDo
                              join g in data.KinhNghiems
                              on a.ID_KinhNghiem equals g.ID_KinhNghiem
                              where (a.ID_CV == int.Parse(e.CommandArgument.ToString()))
                              select new
                              {
                                  b.HoTen,
                                  b.NgaySinh,
                                  b.GioiTinh,
                                  b.DiaChi,
                                  b.Email,
                                  b.SDT,
                                  a.TieuDe,
                                  c.TenNganhNghe,
                                  d.TenViTri,
                                  f.TenTrinhDo,
                                  g.TenKinhNghiem,
                                  a.KyNang,
                                  a.NgoaiNgu,
                                  a.MucLuong,
                                  a.BangCap
                              }).SingleOrDefault();
                    //load du lieu xuong textbox
                    txtTimUV_HoTen.Text = kq.HoTen;
                    txtTimUV_NgaySinh.Text = String.Format("{0:d}", kq.NgaySinh);
                    txtTimUV_GioiTinh.Text = kq.GioiTinh;
                    txtTimUV_DiaChi.Text = kq.DiaChi;
                    txtTimUV_Email.Text = kq.Email;
                    txtTimUV_SDT.Text = kq.SDT;
                    txtTimUV_TieuDe.Text = kq.TieuDe;
                    txtTimUV_NganhNghe.Text = kq.TenNganhNghe;
                    txtTimUV_ViTri.Text = kq.TenViTri;
                    txtTimUV_TrinhDo.Text = kq.TenTrinhDo;
                    txtTimUV_KinhNghiem.Text = kq.TenKinhNghiem;
                    txtTimUV_KyNang.Text = kq.KyNang;
                    txtTimUV_NgoaiNgu.Text = kq.NgoaiNgu;
                    txtTimUV_MucLuong.Text = kq.MucLuong;
                    txtTimUV_BangCap.Text = kq.BangCap;
                    //hien thong tin
                    TimUV_ChiTietUngVien.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void btnTimUV_OK_Click(object sender, EventArgs e)
        {
            TimUV_ChiTietUngVien.Visible = false;
        }

        protected void btnTimUV_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int manghe = Convert.ToInt32(ddlTimUV_NganhNghe.SelectedValue);
                int matp = Convert.ToInt32(ddlTimUV_ThanhPho.SelectedValue);
                int matd = Convert.ToInt32(ddlTimUV_TrinhDo.SelectedValue);
                int makn = Convert.ToInt32(ddlTimUV_KinhNghiem.SelectedValue);
                var kq = from m in data.CV_UngViens
                         join n in data.UngViens
                         on m.ID_UngVien equals n.ID_UngVien
                         join h in data.NganhNghes
                         on m.ID_NganhNghe equals h.ID_NganhNghe
                         join k in data.ThanhPhos
                         on n.ID_ThanhPho equals k.ID_ThanhPho
                         join l in data.KinhNghiems
                         on m.ID_KinhNghiem equals l.ID_KinhNghiem
                         where (m.TrangThai == true && m.ID_NganhNghe == manghe && n.ID_ThanhPho == matp && m.ID_TrinhDo == matd && m.ID_KinhNghiem == makn)
                         select new
                         {
                             m.ID_CV,
                             n.HoTen,
                             h.TenNganhNghe,
                             m.TieuDe,
                             k.TenThanhPho,
                             l.TenKinhNghiem
                         };
                grvTimUV_DSUngVien.DataSource = kq;
                grvTimUV_DSUngVien.DataBind();
            }
            catch (Exception ex)
            { }
        }

        protected void lnkTimUV_TimKiemUV_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
        }

        protected void lnkTimUV_ThemViecLam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
        }

        protected void lnkTimUV_DSViecLam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
        }

        protected void lnkTimUV_UngVienDaUngTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
        }
    }
}