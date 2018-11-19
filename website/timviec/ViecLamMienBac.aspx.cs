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
    public partial class ViecLamMienBac : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private TinViecLamBLL vieclam = new TinViecLamBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadViecLamMB();
            }
        }

        //danh sach viec lam mien bac
        private void LoadViecLamMB()
        {
            var kq = from a in data.TinViecLams
                     join b in data.CongTies
                     on a.ID_CongTy equals b.ID_CongTy
                     join c in data.ThanhPhos
                     on b.ID_ThanhPho equals c.ID_ThanhPho
                     where (a.TrangThai == true && a.NgayHetHan > DateTime.Now && c.ID_Vung == 1)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenThanhPho,
                         a.MucLuong,
                         a.NgayHetHan
                     };
            kq = kq.OrderByDescending(p => p.ID_ViecLam);
            grvVLMienBac_DSViecLam.DataSource = kq;
            grvVLMienBac_DSViecLam.DataBind();
        }

        protected void grvVLMienBac_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVLMienBac_DSViecLam.PageIndex = e.NewPageIndex;
            grvVLMienBac_DSViecLam.DataBind();
            LoadViecLamMB();
        }

        protected void grvVLMienBac_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtVLMienBac_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }
    }
}