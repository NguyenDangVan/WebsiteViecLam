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

namespace timviec
{
    public partial class ChiTietViecLam : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public int ID_NguoiTimViec { get; set; }
        private DangKyBLL dk = new DangKyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChiTietViecLamTheoMa();
            }
            if (Session.GetName_NhaTuyenDung() != null)
            {
                btnCTVL_NopHoSo.Visible = false;
            }
        }

        //load chi tiet viec lam
        private void ChiTietViecLamTheoMa()
        {
            int id = Convert.ToInt32(Request.QueryString["IDViecLam"]);
            var kq = (from a in data.TinViecLams
                      join b in data.CongTies
                      on a.ID_CongTy equals b.ID_CongTy
                      join c in data.ThanhPhos
                      on b.ID_ThanhPho equals c.ID_ThanhPho
                      join d in data.TrinhDos
                      on a.ID_TrinhDo equals d.ID_TrinhDo
                      join m in data.KinhNghiems
                      on a.ID_KinhNghiem equals m.ID_KinhNghiem
                      join n in data.NganhNghes
                      on a.ID_NganhNghe equals n.ID_NganhNghe
                      join h in data.ViTriUngTuyens
                      on a.ID_ViTri equals h.ID_ViTri
                      where (a.ID_ViecLam == id)
                      select new
                      {
                          a.TieuDeViecLam,
                          a.NgayDang,
                          b.TenCongTy,
                          b.DiaChi,
                          a.SoLuong,
                          a.ThoiGianThuViec,
                          d.TenTrinhDo,
                          a.GioiTinh,
                          m.TenKinhNghiem,
                          a.MucLuong,
                          h.TenViTri,
                          n.TenNganhNghe,
                          c.TenThanhPho,
                          a.MoTa,
                          a.YeuCauKyNang,
                          a.YeuCauHoSo,
                          a.NgayHetHan
                      }).SingleOrDefault();
            lblCTVL_TenViecLam.Text = kq.TieuDeViecLam;
            lblCTVL_NgayDang.Text = "<b>Ngày đăng:</b> " + String.Format("{0:d}", kq.NgayDang);
            lblCTVL_TenCTy.Text = "<b>" + kq.TenCongTy + "</b>";
            lblCTVL_DiaChiCTy.Text = "<b>Địa chỉ:</b> " + kq.DiaChi;
            lblCTVL_SoLuong.Text = kq.SoLuong.ToString();
            lblCTVL_ThuViec.Text = kq.ThoiGianThuViec;
            lblCTVL_TrinhDo.Text = kq.TenTrinhDo;
            lblCTVL_GioiTinh.Text = kq.GioiTinh;
            lblCTVL_KinhNghiem.Text = kq.TenKinhNghiem;
            lblCTVL_MucLuong.Text = kq.MucLuong;
            lblCTVL_ViTri.Text = kq.TenViTri;
            lblCTVL_NganhNghe.Text = kq.TenNganhNghe;
            lblCTVL_ThanhPho.Text = kq.TenThanhPho;
            lblCTVL_MoTa.Text = kq.MoTa;
            lblCTVL_yeuCauKyNang.Text = kq.YeuCauKyNang;
            lblCTVL_HoSo.Text = kq.YeuCauHoSo;
            lblCTVL_NgayHetHan.Text = String.Format("{0:d}", kq.NgayHetHan);
        }

        protected void btnCTVL_NopHoSo_Click(object sender, EventArgs e)
        {
            try
            {               
                if (Session.GetName_NguoiTimViec() == null)
                {
                    //Response.Write("<script> alert('Bạn chưa đăng nhập.')</script>");
                    Response.Redirect("~/NguoiTimViec/DangNhapNguoiTimViec.aspx?returnUrl=" + Request.Url.PathAndQuery);
                }
                else
                {
                    UngVien id = Session.GetID_NguoiTimViec();
                    ID_NguoiTimViec = id.ID_UngVien;
                    var kq = (from n in data.CV_UngViens
                              where (n.ID_UngVien == Convert.ToInt32(ID_NguoiTimViec))
                              select new { n.ID_CV }).SingleOrDefault();
                    int id_cv = kq.ID_CV;
                    //if(id_cv==null)
                    //    Response.Write("<script> alert('Bạn chưa tạo hồ sơ.')</script>");
                    //else
                    int idvl = Convert.ToInt32(Request.QueryString["IDViecLam"]);
                    dk.LuuDangKy(id_cv, idvl, DateTime.Now, false);
                    Response.Write("<script> alert('Nộp hồ sơ thành công.')</script>");
                }

            }
            catch (Exception ex)
            { }
        }
    }
}