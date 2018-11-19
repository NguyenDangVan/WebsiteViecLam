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
    public partial class TimKiemNhanh : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TimKiemNhanhViecLam();
            }
        }

        protected void grvTimKiemNhanh_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTimKiemNhanh_DSViecLam.PageIndex = e.NewPageIndex;
            grvTimKiemNhanh_DSViecLam.DataBind();
            TimKiemNhanhViecLam();
        }

        protected void grvTimKiemNhanh_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtChiTietTimKiemNhanh_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }

        //danh sach viec lam tim kiem nhanh
        private void TimKiemNhanhViecLam()
        {
            int nganhnghe = Convert.ToInt32(Request.QueryString["IDNganhNghe"]);
            int thanhpho = Convert.ToInt32(Request.QueryString["IDThanhPho"]);
            int trinhdo = Convert.ToInt32(Request.QueryString["IDTrinhDo"]);
            int vitri = Convert.ToInt32(Request.QueryString["IDViTri"]);
            int kinhnghiem = Convert.ToInt32(Request.QueryString["IDKinhNghiem"]);
            if (nganhnghe != 0 && thanhpho != 0 && trinhdo != 0 && vitri != 0 && kinhnghiem != 0)
            {
                var kq = from a in data.TinViecLams
                         join b in data.CongTies
                         on a.ID_CongTy equals b.ID_CongTy
                         join c in data.ThanhPhos
                         on b.ID_ThanhPho equals c.ID_ThanhPho
                         where (a.TrangThai == true && a.ID_NganhNghe == nganhnghe && c.ID_ThanhPho == thanhpho && a.ID_TrinhDo == trinhdo && a.ID_ViTri == vitri && a.ID_KinhNghiem == kinhnghiem)
                         select new
                         {
                             a.ID_ViecLam,
                             a.TieuDeViecLam,
                             c.TenThanhPho,
                             a.MucLuong,
                             a.NgayHetHan
                         };
                grvTimKiemNhanh_DSViecLam.DataSource = kq;
                grvTimKiemNhanh_DSViecLam.DataBind();
            }
        }
    }
}