using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data;
using BLL;
using DAL;

namespace timviec.NguoiTimViec
{
    public partial class DangKyTimViec : System.Web.UI.Page
    {
        UngVienBLL ungvienbll = new UngVienBLL();
        clsEncrypt encrypt = new clsEncrypt();
        thanhPho tp = new thanhPho();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadThanhPho();
            }
        }

        //Xóa dữ liệu trên textbox
        private void ClearTextBox()
        {
            txtHoTen.Text = "";
            txtDiaChiUV.Text = "";
            txtEmailUV.Text = "";
            txtMatKhauUV.Text = "";
            txtNgaySinh.Text = "";
            txtSDTUV.Text = "";
        }

        //Load thanh pho
        private void LoadThanhPho()
        {
            ddlDK_ThanhPho.DataSource = tp.dsThanhPho();
            ddlDK_ThanhPho.DataValueField = "ID_ThanhPho";
            ddlDK_ThanhPho.DataTextField = "TenThanhPho";
            ddlDK_ThanhPho.DataBind();
        }

        protected void btnHuyUngVien_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        protected void btnDangKyUngVien_Click(object sender, EventArgs e)
        {
            
            string mahoaMK = encrypt.GetMD5(txtMatKhauUV.Text);
            DateTime ngaysinh = Convert.ToDateTime(txtNgaySinh.Text.ToString());
            String.Format("{0:d}", ngaysinh);
            if (ungvienbll.KiemTraEmail(txtEmailUV.Text) == false)
            {
                Response.Write("<script> alert('Email đã được đăng ký, vui lòng chọn Email khác.')</script>");
                txtEmailUV.Text = "";
                txtEmailUV.Focus();
            }
            else
            {
                if (ngaysinh >= DateTime.Now)
                {
                    Response.Write("<script> alert('Ngày sinh không thể lớn hơn ngày hiện tại được đâu nhé bạn.')</script>");
                }
                else
                {
                    string gioitinh = ddlGioiTinh.SelectedValue.ToString();
                    int thanhpho = Convert.ToInt32(ddlDK_ThanhPho.SelectedValue.ToString());
                    ungvienbll.LuuUngVien(txtHoTen.Text, mahoaMK, txtDiaChiUV.Text, thanhpho, ngaysinh, gioitinh, txtEmailUV.Text, txtSDTUV.Text);
                    Response.Write("<script> alert('Đăng ký thành công.')</script>");
                    ClearTextBox();
                }
            }
        }
    }
}