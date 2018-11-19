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
    public partial class ViecLamMienTrung : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadViecLamMT();
            }
        }

        //danh sach viec lam mien trung
        private void LoadViecLamMT()
        {
            var kq = from a in data.TinViecLams
                     join b in data.CongTies
                     on a.ID_CongTy equals b.ID_CongTy
                     join c in data.ThanhPhos
                     on b.ID_ThanhPho equals c.ID_ThanhPho
                     where (a.TrangThai == true && a.NgayHetHan > DateTime.Now && c.ID_Vung == 2)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenThanhPho,
                         a.MucLuong,
                         a.NgayHetHan
                     };
            kq = kq.OrderByDescending(p => p.ID_ViecLam);
            grvVLMienTrung_DSViecLam.DataSource = kq;
            grvVLMienTrung_DSViecLam.DataBind();
        }

        protected void grvVLMienTrung_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVLMienTrung_DSViecLam.PageIndex = e.NewPageIndex;
            grvVLMienTrung_DSViecLam.DataBind();
            LoadViecLamMT();
        }

        protected void grvVLMienTrung_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtVLMienTrung_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }
    }
}