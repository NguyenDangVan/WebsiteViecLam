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

namespace timviec.NhaTuyenDung
{
    public partial class NhaTuyenDung : System.Web.UI.Page
    {
        public string CurrentName_Company { get; set; }
        public int CurrentID_Company { get; set; }
        TimViecDBDataContext data = new TimViecDBDataContext();
        thanhPho tp = new thanhPho();
        CongTyBLL ct = new CongTyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ThongTinCongTy.Visible = true;
            SuaThongTinCongTy.Visible = false;
            if (!Page.IsPostBack)
            {
                LoadThanhPho();
                EnableTextBox(false);
            }
            CongTy tenct = Session.GetName_NhaTuyenDung();
            CongTy idct = Session.GetID_NhaTuyenDung();
            //var kq = (from n in data.CongTies
            //          where (n.ID_CongTy == Convert.ToInt32(idct))
            //          select n).FirstOrDefault();
            if (tenct != null)
            {
                CurrentName_Company = tenct.TenCongTy;
                CurrentID_Company = idct.ID_CongTy;
                lblNTD_DiaChi.Text = idct.DiaChi;
                lblNTD_Email.Text = idct.Email;
                lblNTD_MoTa.Text = idct.MoTa;
                lblNTD_NguoiDaiDien.Text = idct.NguoiDaiDien;
                lblNTD_SDT.Text = idct.SDT;
                lblNTD_TenCongTy.Text = idct.TenCongTy;
                lblNTD_Website.Text = idct.Website;
                lblNTD_QuyMo.Text = idct.QuyMo.ToString();
            }

        }

        protected override void OnInit(EventArgs e)
        {
            if (Session.GetName_NhaTuyenDung() == null)
            {
                Response.Redirect("DangNhapNhaTuyenDung.aspx?returnUrl=" + Request.Url.PathAndQuery);
            }
            base.OnInit(e);
        }

        private void LoadThanhPho()
        {
            ddlNTD_ThanhPho.DataSource = tp.dsThanhPho();
            ddlNTD_ThanhPho.DataTextField = "TenThanhPho";
            ddlNTD_ThanhPho.DataValueField = "ID_ThanhPho";
            ddlNTD_ThanhPho.DataBind();
        }

        protected void btnNTD_CapNhat_Click(object sender, EventArgs e)
        {
            EnableTextBox(true);
            SuaThongTinCongTy.Visible = true;
            ThongTinCongTy.Visible = false;
            CongTy idct = Session.GetID_NhaTuyenDung();
            CongTy tenct = Session.GetName_NhaTuyenDung();
            CurrentID_Company = idct.ID_CongTy;
            if (tenct != null)
            {
                CurrentName_Company = tenct.TenCongTy;
                CurrentID_Company = idct.ID_CongTy;
                txtNTD_DiaChi.Text = idct.DiaChi;
                txtNTD_Email.Text = idct.Email;
                txtNTD_MoTa.Text = idct.MoTa;
                txtNTD_NguoiDaiDien.Text = idct.NguoiDaiDien;
                txtNTD_SDT.Text = idct.SDT;
                txtNTD_TenCongTy.Text = idct.TenCongTy;
                txtNTD_Website.Text = idct.Website;
                ddlNTD_QuyMo.SelectedValue = idct.QuyMo.ToString();
                ddlNTD_ThanhPho.SelectedValue = idct.ID_ThanhPho.ToString();
            }
        }

        protected void btnNTD_Huy_Click(object sender, EventArgs e)
        {
            EnableTextBox(false);
        }

        //Enable textbox
        private void EnableTextBox(bool status)
        {
            txtNTD_DiaChi.Enabled = status;
            txtNTD_Email.Enabled = status;
            txtNTD_MoTa.Enabled = status;
            txtNTD_NguoiDaiDien.Enabled = status;
            txtNTD_SDT.Enabled = status;
            txtNTD_TenCongTy.Enabled = status;
            txtNTD_Website.Enabled = status;
            ddlNTD_QuyMo.Enabled = status;
            ddlNTD_ThanhPho.Enabled = status;
        }

        protected void btnNTD_DongY_Click(object sender, EventArgs e)
        {
            try
            {
                CongTy idct = Session.GetID_NhaTuyenDung();
                CurrentID_Company = idct.ID_CongTy;
                ct.CapNhat(CurrentID_Company, txtNTD_TenCongTy.Text, txtNTD_DiaChi.Text, ddlNTD_QuyMo.SelectedItem.ToString(), txtNTD_SDT.Text, txtNTD_Website.Text,
                        txtNTD_MoTa.Text, txtNTD_NguoiDaiDien.Text, txtNTD_Email.Text, Convert.ToInt32(ddlNTD_ThanhPho.SelectedValue.ToString()));
                ThongTinCongTy.Visible = true;
                SuaThongTinCongTy.Visible = false;
            }
            catch (Exception ex)
            { }
        }

        protected void lnkTD_TimKiemUV_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/TimKiemUngVien.aspx");
        }

        protected void lnkTD_ThemViecLam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/ThemViecLamMoi.aspx");
        }

        protected void lnkTD_UngVienDaUngTuyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/UngVienDaUngTuyen.aspx");
        }

        protected void lnkTD_DSCongViec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NhaTuyenDung/DanhSachViecLam.aspx");
        }
    }
}