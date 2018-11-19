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
    public partial class NhaTuyenDungXemHoSo : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private CV_UngVienBLL cv = new CV_UngVienBLL();
        private int ID_NguoiTimViec { get; set; }
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
            if (!Page.IsPostBack)
            {
                NTDXemHoSo();
            }
        }

        //danh sach nha tuyen dung xem ho so
        private void NTDXemHoSo()
        {
            UngVien id = Session.GetID_NguoiTimViec();
            ID_NguoiTimViec = id.ID_UngVien;
            var kq = (from a in data.DangKies
                      join b in data.TinViecLams
                      on a.ID_ViecLam equals b.ID_ViecLam
                      join c in data.CongTies
                      on b.ID_CongTy equals c.ID_CongTy
                      join d in data.CV_UngViens
                      on a.ID_CV equals d.ID_CV
                      where (a.TrangThai == true && d.ID_CV == cv.LayID_CV(ID_NguoiTimViec))
                      select new
                      {
                          c.TenCongTy,
                          a.NgayXem
                      }).Distinct();
            grvNTDXemHS_DSNTD.DataSource = kq;
            grvNTDXemHS_DSNTD.DataBind();
        }

        protected void lnkNTDXemHS_TuHoSo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
        }

        protected void lnkNTDXemHS_TaiKhoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
        }

        protected void lnkNTDXemHS_ViecLamUngTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/ViecLamDaUngTuyen.aspx");
        }

        protected void lnkNTDXemHS_NhaTuyenDungXemHoSo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NguoiTimViec/NhaTuyenDungXemHoSo.aspx");
        }
    }
}