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
    public partial class DanhSach_CV : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUngVien();
            }
        }

        //load ung vien
        public void LoadUngVien()
        {
            var kq = from n in data.UngViens
                     join m in data.ThanhPhos
                     on n.ID_ThanhPho equals m.ID_ThanhPho
                     select new 
                     { 
                         n.ID_UngVien, 
                         n.HoTen, n.DiaChi, 
                         m.TenThanhPho, 
                         n.NgaySinh, 
                         n.GioiTinh, 
                         n.Email, 
                         n.SDT 
                     };
            grvDS_UngVien.DataSource = kq;
            grvDS_UngVien.DataBind();
        }

        protected void grvDS_UngVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadUngVien();
            grvDS_UngVien.PageIndex = e.NewPageIndex;
            grvDS_UngVien.DataBind();
        }

        protected void btnUV_TimUV_Click(object sender, EventArgs e)
        {
            var kq = from n in data.UngViens
                     join m in data.ThanhPhos
                     on n.ID_ThanhPho equals m.ID_ThanhPho
                     where (n.HoTen.Contains(txtUV_TenUV.Text))
                     select new
                     {
                         n.ID_UngVien,
                         n.HoTen,
                         n.DiaChi,
                         m.TenThanhPho,
                         n.NgaySinh,
                         n.GioiTinh,
                         n.Email,
                         n.SDT
                     };
            grvDS_UngVien.DataSource = kq;
            grvDS_UngVien.DataBind();
        }
    }
}