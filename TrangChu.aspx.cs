using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TrangChu : System.Web.UI.Page
{
    
    ViecLam vieclam= new ViecLam();
    CongTyBLL ctbll = new CongTyBLL();
    NganhNghe nn = new NganhNghe();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNgheHot();
        LoadViecLam();
        LoadNhaTuyenDungMoiNhat();
    }
    private void LoadViecLam()
    {
        grvTrangChu_DSViecLam.DataSource = vieclam.ViecLamHot();
        grvTrangChu_DSViecLam.DataBind();
    }
    protected void grvTrangChu_DSViecLam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTrangChu_DSViecLam.PageIndex = e.NewPageIndex;
        grvTrangChu_DSViecLam.DataBind();
        LoadViecLam();
    }
    private void LoadNgheHot()
    {
        string str1 = "";
        string str2 = "";
        DataTable dt = new DataTable();
        dt = nn.DsNganhNgheHot();
        str1 += "<ul>";
        foreach (DataRow s in dt.Rows)
        {

            str1 += "<li><a href='ChiTietNghe.aspx?IDNghe=" + s[0] + "'>" + s[1].ToString() + "</a></li>";

        }
        str1 += "</ul>";
        TrangChu_DSNghe1.InnerHtml = str1;

        //var a = from n in data.NganhNghes
        //        select n;
        //a = a.OrderByDescending(q => q.ID_NganhNghe).Skip(15).Take(15);
        //str2 += "<ul>";
        //foreach (var b in a)
        //{

        //    str2 += "<li><a href='ChiTietNghe.aspx?IDNghe=" + b.ID_NganhNghe + "'>" + b.TenNganhNghe + "</a></li>";

        //}
        //str2 += "</ul>";
        //TrangChu_DSNghe2.InnerHtml = str2;
    }
    private void LoadNhaTuyenDungMoiNhat()
    {
        string congty = "";
        DataTable dt = ctbll.DsCongTy();
        ctbll.DsCongTy();
        //var kq = from n in data.CongTies
        //         select n;
        //kq = kq.OrderByDescending(p => p.ID_CongTy).Take(10);
        congty += "<ul>";
        foreach (DataRow rows in dt.Rows)
        {
            congty += "<li>" + rows[1].ToString() + "</li>";
        }
        //foreach (var s in kq)
        //{
        //    congty += "<li>" + s.TenCongTy + "</li>";
        //}
        congty += "</ul>";
        TrangChu_NhaTuyenDungMoiNhat.InnerHtml = congty;
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
        catch (Exception)
        { }
    }
}