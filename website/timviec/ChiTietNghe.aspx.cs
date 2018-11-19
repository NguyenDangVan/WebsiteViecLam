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
    public partial class ChiTietNghe : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViecLamTheoNghe();
            }
        }

        //danh sach viec lam theo nghe
        private void ViecLamTheoNghe()
        {
            int manghe = Convert.ToInt32(Request.QueryString["IDNghe"]);
            var kq = from a in data.TinViecLams
                     join b in data.CongTies
                     on a.ID_CongTy equals b.ID_CongTy
                     join c in data.ThanhPhos
                     on b.ID_ThanhPho equals c.ID_ThanhPho
                     join d in data.NganhNghes
                     on a.ID_NganhNghe equals d.ID_NganhNghe
                     where (a.TrangThai == true && a.ID_NganhNghe == manghe)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenThanhPho,
                         a.MucLuong,
                         a.NgayHetHan,
                         d.TenNganhNghe
                     };
            foreach (var s in kq)
            {
                lblChiTietNghe_TenNghe.Text = s.TenNganhNghe;
            }
            grvChiTietNghe_DSViecLam.DataSource = kq;
            grvChiTietNghe_DSViecLam.DataBind();
        }

        protected void grvChiTietNghe_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvChiTietNghe_DSViecLam.PageIndex = e.NewPageIndex;
            grvChiTietNghe_DSViecLam.DataBind();
            ViecLamTheoNghe();
        }

        protected void grvChiTietNghe_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtChiTietNghe_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }


    }
}