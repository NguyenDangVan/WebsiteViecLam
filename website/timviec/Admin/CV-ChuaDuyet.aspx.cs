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
    public partial class CV_ChuaDuyet : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            IDCVChuaDuyet.Visible = false;
            if (!Page.IsPostBack)
            {
                LoadCV();
            }
        }

        //load CV chua kich hoat
        private void LoadCV()
        {
            var kq = from a in data.CV_UngViens
                     join b in data.UngViens
                     on a.ID_UngVien equals b.ID_UngVien
                     join c in data.NganhNghes
                     on a.ID_NganhNghe equals c.ID_NganhNghe
                     join d in data.TrinhDos
                     on a.ID_TrinhDo equals d.ID_TrinhDo
                     where (a.TrangThai == false)
                     select new
                     {
                         a.ID_CV,
                         b.HoTen,
                         a.TieuDe,
                         c.TenNganhNghe,
                         d.TenTrinhDo,
                         a.NgoaiNgu,
                         a.MucLuong,
                         a.BangCap
                     };
            grvDS_CVChuaDuyet.DataSource = kq;
            grvDS_CVChuaDuyet.DataBind();
        }

        protected void grvDS_CVChuaDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnEdit_CV")
                {
                    IDCVChuaDuyet.Visible = true;
                    var kq = (from a in data.CV_UngViens
                              join b in data.UngViens
                              on a.ID_UngVien equals b.ID_UngVien
                              join c in data.NganhNghes
                              on a.ID_NganhNghe equals c.ID_NganhNghe
                              join d in data.TrinhDos
                              on a.ID_TrinhDo equals d.ID_TrinhDo
                              join m in data.ViTriUngTuyens
                              on a.ID_ViTri equals m.ID_ViTri
                              join n in data.KinhNghiems
                              on a.ID_KinhNghiem equals n.ID_KinhNghiem
                              where (a.ID_CV == int.Parse(e.CommandArgument.ToString()))
                              select new
                              {
                                  a.ID_CV,
                                  b.HoTen,
                                  a.TieuDe,
                                  c.TenNganhNghe,
                                  a.KyNang,
                                  m.TenViTri,
                                  d.TenTrinhDo,
                                  n.TenKinhNghiem,
                                  a.NgoaiNgu,
                                  a.MucLuong,
                                  a.BangCap
                              }).SingleOrDefault();
                    lblCV_ID.Text = kq.ID_CV.ToString();
                    txtCV_TieuDe.Text = kq.TieuDe;
                    txtCV_NganhNghe.Text = kq.TenNganhNghe;
                    txtCV_KyNang.Text = kq.KyNang;
                    txtCV_ViTri.Text = kq.TenViTri;
                    txtCV_TrinhDo.Text = kq.TenTrinhDo;
                    txtCV_KinhNghiem.Text = kq.TenKinhNghiem;
                    txtCV_NgoaiNgu.Text = kq.NgoaiNgu;
                    txtCV_MucLuong.Text = kq.MucLuong;
                    txtCV_Bang.Text = kq.BangCap;
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        protected void grvDS_CVChuaDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadCV();
            grvDS_CVChuaDuyet.PageIndex = e.NewPageIndex;
            grvDS_CVChuaDuyet.DataBind();
        }

        protected void btnDuyetCV_Click(object sender, EventArgs e)
        {
            var kq = data.CV_UngViens.Single(p => p.ID_CV == int.Parse(lblCV_ID.Text.ToString()));
            kq.TrangThai = true;
            data.SubmitChanges();
            LoadCV();
            IDCVChuaDuyet.Visible = false;
        }
    }
}