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
    public partial class ViecLamMienNam : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadViecLamMN();
            }
        }

        //danh sach viec lam mien nam
        private void LoadViecLamMN()
        {
            var kq = from a in data.TinViecLams
                     join b in data.CongTies
                     on a.ID_CongTy equals b.ID_CongTy
                     join c in data.ThanhPhos
                     on b.ID_ThanhPho equals c.ID_ThanhPho
                     where (a.TrangThai == true && a.NgayHetHan > DateTime.Now && c.ID_Vung == 3)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenThanhPho,
                         a.MucLuong,
                         a.NgayHetHan
                     };
            kq = kq.OrderByDescending(p => p.ID_ViecLam);
            grvVLMienNam_DSViecLam.DataSource = kq;
            grvVLMienNam_DSViecLam.DataBind();
        }
        
        protected void grvVLMienNam_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVLMienNam_DSViecLam.PageIndex = e.NewPageIndex;
            grvVLMienNam_DSViecLam.DataBind();
            LoadViecLamMN();
        }

        protected void grvVLMienNam_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtVLMienNam_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }
    }
}