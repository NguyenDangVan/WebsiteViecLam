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
    public partial class TrangChu : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        private TinViecLamBLL vieclam = new TinViecLamBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadNgheHot();
                LoadViecLam();
                LoadNhaTuyenDungMoiNhat();
            }
        }

        //load cac nghe moi nhat
        private void LoadNgheHot()
        {
            string str1 = "";
            string str2 = "";
            var kq = from n in data.NganhNghes
                     select n;
            kq = kq.OrderByDescending(p => p.ID_NganhNghe).Take(15);
            
            str1 += "<ul>";
            foreach (var s in kq)
            {

                str1 += "<li><a href='ChiTietNghe.aspx?IDNghe=" + s.ID_NganhNghe + "'>" + s.TenNganhNghe + "</a></li>";
                
            }
            str1 += "</ul>";
            TrangChu_DSNghe1.InnerHtml = str1;

            var a = from n in data.NganhNghes
                     select n;
            a = a.OrderByDescending(q => q.ID_NganhNghe).Skip(15).Take(15);
            str2 += "<ul>";
            foreach (var b in a)
            {

                str2 += "<li><a href='ChiTietNghe.aspx?IDNghe=" + b.ID_NganhNghe + "'>" + b.TenNganhNghe + "</a></li>";

            }
            str2 += "</ul>";
            TrangChu_DSNghe2.InnerHtml = str2;
        }

        //load danh sach nha tuyen dung moi nhat
        private void LoadNhaTuyenDungMoiNhat()
        {
            string congty = "";
            var kq = from n in data.CongTies
                     select n;
            kq = kq.OrderByDescending(p => p.ID_CongTy).Take(10);
            congty += "<ul>";
            foreach (var s in kq)
            {
                congty += "<li>" + s.TenCongTy + "</li>";
            }
            congty += "</ul>";
            TrangChu_NhaTuyenDungMoiNhat.InnerHtml = congty;
        }

        //danh sach viec lam
        private void LoadViecLam()
        {
            var kq = from a in data.TinViecLams
                     join b in data.CongTies
                     on a.ID_CongTy equals b.ID_CongTy
                     join c in data.ThanhPhos
                     on b.ID_ThanhPho equals c.ID_ThanhPho
                     where (a.TrangThai == true && a.NgayHetHan > DateTime.Now)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenThanhPho,
                         a.MucLuong,
                         a.NgayHetHan
                     };
            kq = kq.OrderByDescending(p => p.ID_ViecLam);
            grvTrangChu_DSViecLam.DataSource = kq;
            grvTrangChu_DSViecLam.DataBind();
        }

        protected void grvTrangChu_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTrangChu_DSViecLam.PageIndex = e.NewPageIndex;
            grvTrangChu_DSViecLam.DataBind();
            LoadViecLam();
        }

        protected void grvTrangChu_DSViecLam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "lbtChiTietTragChu_DSViecLam")
                {
                    Response.Redirect("ChiTietViecLam.aspx?IDViecLam=" + e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            { }
        }
    }
}