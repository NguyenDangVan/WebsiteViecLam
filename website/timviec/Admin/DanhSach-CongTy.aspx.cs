using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;
using BLL;

namespace timviec.Admin
{
    public partial class DanhSach_CongTy : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCongTy();
            }
        }

        //load công ty
        public void LoadCongTy()
        {
            var kq = from n in data.CongTies
                     join m in data.ThanhPhos
                     on n.ID_ThanhPho equals m.ID_ThanhPho
                     select new
                     {
                         n.ID_CongTy,
                         n.TenCongTy,
                         n.DiaChi,
                         m.TenThanhPho,
                         n.QuyMo,
                         n.SDT,
                         n.Website,
                         n.NguoiDaiDien,
                         n.Email,
                     };
            grvDS_CongTy.DataSource = kq;
            grvDS_CongTy.DataBind();
        }

        //protected void grvDS_UngVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
            
        //}

        protected void btnCT_TimCT_Click(object sender, EventArgs e)
        {
            var kq = from n in data.CongTies
                     join m in data.ThanhPhos
                     on n.ID_ThanhPho equals m.ID_ThanhPho
                     where (n.TenCongTy.Contains(txtCT_TenCT.Text))
                     select new
                     {
                         n.ID_CongTy,
                         n.TenCongTy,
                         n.DiaChi,
                         m.TenThanhPho,
                         n.QuyMo,
                         n.SDT,
                         n.Website,
                         n.MoTa,
                         n.NguoiDaiDien,
                         n.Email,
                     };
            grvDS_CongTy.DataSource = kq;
            grvDS_CongTy.DataBind();
        }

        protected void grvDS_CongTy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDS_CongTy.PageIndex = e.NewPageIndex;
            grvDS_CongTy.DataBind();
            LoadCongTy();
        }
    }
}