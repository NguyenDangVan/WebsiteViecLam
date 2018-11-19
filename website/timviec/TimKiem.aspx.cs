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
    public partial class TimKiem : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private TinViecLamBLL vieclam = new TinViecLamBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TimKiemDSViecLam();
            }
        }

        //ket qua tim kiem
        private void TimKiemDSViecLam()
        {
            int nghe = Convert.ToInt32(Request.QueryString["IDNghe"]);
            int thanhpho = Convert.ToInt32(Request.QueryString["IdTP"]);
            if (nghe != 0 && thanhpho != 0)
            {
                var kq = from a in data.TinViecLams
                         join b in data.CongTies
                         on a.ID_CongTy equals b.ID_CongTy
                         join c in data.ThanhPhos
                         on b.ID_ThanhPho equals c.ID_ThanhPho
                         where (a.TrangThai == true && a.ID_NganhNghe == nghe && c.ID_ThanhPho == thanhpho)
                         select new
                         {
                             a.ID_ViecLam,
                             a.TieuDeViecLam,
                             c.TenThanhPho,
                             a.MucLuong,
                             a.NgayHetHan
                         };
                grvTimKiem_DSViecLam.DataSource = kq;
                grvTimKiem_DSViecLam.DataBind();
            }

        }

        protected void grvTimKiem_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTimKiem_DSViecLam.PageIndex = e.NewPageIndex;
            grvTimKiem_DSViecLam.DataBind();
            TimKiemDSViecLam();
        }

        protected void grvTimKiem_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtChiTietTimKiem_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }
    }
}