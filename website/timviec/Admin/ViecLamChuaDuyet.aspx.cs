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
    public partial class ViecLamChuaDuyet : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            IDViecLamChuaDuyet.Visible = false;
            if (!Page.IsPostBack)
            {
                ViecLamChuaKichHoat();
            }
        }

        //load cac viec lam chua duoc kich hoat
        private void ViecLamChuaKichHoat()
        {
            var kq = from a in data.TinViecLams
                     join b in data.NganhNghes
                     on a.ID_NganhNghe equals b.ID_NganhNghe
                     join c in data.CongTies
                     on a.ID_CongTy equals c.ID_CongTy
                     join d in data.ThanhPhos
                     on c.ID_ThanhPho equals d.ID_ThanhPho
                     where (a.TrangThai == false)
                     select new
                     {
                         a.ID_ViecLam,
                         a.TieuDeViecLam,
                         c.TenCongTy,
                         b.TenNganhNghe,
                         d.TenThanhPho,
                         a.SoLuong,
                         a.NgayDang,
                         a.NgayHetHan
                     };
            grvDS_ViecLamChuaDuyet.DataSource = kq;
            grvDS_ViecLamChuaDuyet.DataBind();
        }

        protected void grvDS_ViecLamChuaDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViecLamChuaKichHoat();
            grvDS_ViecLamChuaDuyet.PageIndex = e.NewPageIndex;
            grvDS_ViecLamChuaDuyet.DataBind();
        }

        protected void grvDS_ViecLamChuaDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnEdit_DuyetViecLam")
                {
                    var kq = (from a in data.TinViecLams
                              join b in data.CongTies
                              on a.ID_CongTy equals b.ID_CongTy
                              join c in data.NganhNghes
                              on a.ID_NganhNghe equals c.ID_NganhNghe
                              join d in data.ViTriUngTuyens
                              on a.ID_ViTri equals d.ID_ViTri
                              join n in data.TrinhDos
                              on a.ID_TrinhDo equals n.ID_TrinhDo
                              where (a.ID_ViecLam == int.Parse(e.CommandArgument.ToString()))
                              select new
                              {
                                  a.ID_ViecLam,
                                  b.TenCongTy,
                                  a.TieuDeViecLam,
                                  c.TenNganhNghe,
                                  d.TenViTri,
                                  n.TenTrinhDo,
                                  a.GioiTinh,
                                  a.MoTa,
                                  a.YeuCauKyNang,
                                  a.YeuCauHoSo,
                                  a.SoLuong,
                                  a.NgayDang,
                                  a.NgayHetHan
                              }).SingleOrDefault();
                    //day du lieu tu gridview xuong textbox
                    txtDuyetVL_MaVL.Text = kq.ID_ViecLam.ToString();
                    txtDuyetVL_TenCT.Text = kq.TenCongTy;
                    txtDuyetVL_TenVL.Text = kq.TieuDeViecLam;
                    txtDuyetVL_NganhNghe.Text = kq.TenNganhNghe;
                    txtDuyetVL_ViTri.Text = kq.TenViTri;
                    txtDuyetVL_TrinhDo.Text = kq.TenTrinhDo;
                    txtDuyetVL_GioiTinh.Text = kq.GioiTinh;
                    txtDuyetVL_MoTa.Text = kq.MoTa;
                    txtDuyetVL_YeuCauKyNang.Text = kq.YeuCauKyNang;
                    txtDuyetVL_YeuCauHoSo.Text = kq.YeuCauHoSo;
                    txtDuyetVL_SoLuong.Text = kq.SoLuong.ToString();
                    txtDuyetVL_NgayDang.Text = Convert.ToString(String.Format("{0:d}", kq.NgayDang.ToString()));
                    txtDuyetVL_NgayHetHan.Text = Convert.ToString(String.Format("{0:d}", kq.NgayHetHan.ToString()));
                    
                    IDViecLamChuaDuyet.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }

        protected void btnDuyetViecLam_Click(object sender, EventArgs e)
        {
            try
            {
                var kq = data.TinViecLams.Single(p => p.ID_ViecLam == int.Parse(txtDuyetVL_MaVL.Text.ToString()));
                kq.TrangThai = true;
                data.SubmitChanges();
                ViecLamChuaKichHoat();
                IDViecLamChuaDuyet.Visible = false;
            }
            catch (Exception ex)
            { }
        }
    }
}