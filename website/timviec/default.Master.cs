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
    public partial class _default : System.Web.UI.MasterPage
    {
        public string NameUV { get; set; }
        public string NameCT { get; set; }
        nganhNghe nn = new nganhNghe();
        thanhPho tp = new thanhPho();
        clsTrinhDo td = new clsTrinhDo();
        clsViTriLamViec vt = new clsViTriLamViec();
        clsKinhNghiem kn = new clsKinhNghiem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadNganh();
                loadThanhPho();
                loadTrinhDo();
                loadViTri();
                loadKinhNghiem();
                loadSearchNganh();
                loadSearchThanhPho();
            }
            lbtDefault_ThoatUser.Visible = false;
            lbtDefault_User.Visible = false;
            lblDefault_User.Visible = false;
            UngVien uv = Session.GetName_NguoiTimViec();
            if (uv != null)
            {
                NameUV = uv.HoTen;
                lblDefault_User.Text = "Xin chào: ";
                lbtDefault_User.Text = NameUV;
                lblDefault_User.Visible = true;
                lbtDefault_ThoatUser.Visible = true;
                lbtDefault_User.Visible = true;
                IDDangNhap_DangKy.Visible = false;
            }
            CongTy cty = Session.GetName_NhaTuyenDung();
            if (cty != null)
            {
                NameCT = cty.TenCongTy;
                lblDefault_User.Text = "Xin chào: ";
                lbtDefault_User.Text = NameCT;
                lblDefault_User.Visible = true;
                lbtDefault_ThoatUser.Visible = true;
                lbtDefault_User.Visible = true;
                IDDangNhap_DangKy.Visible = false;
            }

        }
        private void loadNganh()
        {
            ddlNganhNghe.DataSource = nn.dsNganhNghe();
            ddlNganhNghe.DataValueField = "ID_NganhNghe";
            ddlNganhNghe.DataTextField = "TenNganhNghe";
            ddlNganhNghe.DataBind();
        }
        private void loadThanhPho()
        {
            ddlThanhPho.DataSource = tp.dsThanhPho();
            ddlThanhPho.DataValueField = "ID_ThanhPho";
            ddlThanhPho.DataTextField = "TenThanhPho";
            ddlThanhPho.DataBind();
        }

        private void loadTrinhDo()
        {
            ddlSearchTrinhDo.DataSource = td.dsTrinhDo();
            ddlSearchTrinhDo.DataValueField = "ID_TrinhDo";
            ddlSearchTrinhDo.DataTextField = "TenTrinhDo";
            ddlSearchTrinhDo.DataBind();
        }

        private void loadViTri()
        {
            ddlSearchViTri.DataSource = vt.dsViTri();
            ddlSearchViTri.DataValueField = "ID_ViTri";
            ddlSearchViTri.DataTextField = "TenViTri";
            ddlSearchViTri.DataBind();
        }

        private void loadKinhNghiem()
        {
            ddlSearchKinhNghiem.DataSource = kn.dsKinhNghiem();
            ddlSearchKinhNghiem.DataValueField = "ID_KinhNghiem";
            ddlSearchKinhNghiem.DataTextField = "TenKinhNghiem";
            ddlSearchKinhNghiem.DataBind();
        }

        private void loadSearchNganh()
        {
            ddlSearchNghe.DataSource = nn.dsNganhNghe();
            ddlSearchNghe.DataValueField = "ID_NganhNghe";
            ddlSearchNghe.DataTextField = "TenNganhNghe";
            ddlSearchNghe.DataBind();
        }
        private void loadSearchThanhPho()
        {
            ddlSearchThanhPho.DataSource = tp.dsThanhPho();
            ddlSearchThanhPho.DataValueField = "ID_ThanhPho";
            ddlSearchThanhPho.DataTextField = "TenThanhPho";
            ddlSearchThanhPho.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int idnghe = Convert.ToInt32(ddlNganhNghe.SelectedValue.ToString());
                int idtp = Convert.ToInt32(ddlThanhPho.SelectedValue.ToString());
                Response.Redirect("~/TimKiem.aspx?IDNghe=" + idnghe + "&IdTP=" + idtp);
            }
            catch (Exception ex)
            { }
        }

        protected void btnTimKiemNhanh_Click(object sender, EventArgs e)
        {
            try
            {
                int nghe = Convert.ToInt32(ddlSearchNghe.SelectedValue.ToString());
                int tp = Convert.ToInt32(ddlSearchThanhPho.SelectedValue.ToString());
                int trinhdo = Convert.ToInt32(ddlSearchTrinhDo.SelectedValue.ToString());
                int vitri = Convert.ToInt32(ddlSearchViTri.SelectedValue.ToString());
                int kinhnghiem = Convert.ToInt32(ddlSearchKinhNghiem.SelectedValue.ToString());
                Response.Redirect("TimKiemNhanh.aspx?IDNganhNghe=" + nghe + "&IDThanhPho=" + tp + "&IDTrinhDo=" + trinhdo + "&IDViTri=" + vitri + "&IDKinhNghiem=" + kinhnghiem);
            }
            catch (Exception ex)
            { }
        }

        protected void lbtDefault_ThoatUser_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/TrangChu.aspx");
        }

        protected void lbtDefault_User_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session.GetName_NguoiTimViec() != null)
                {
                    Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
                }
                if (Session.GetName_NhaTuyenDung() != null)
                {
                    Response.Redirect("~/NhaTuyenDung/NhaTuyenDung.aspx");
                }
            }
            catch (Exception ex)
            { }
        }
    }
}