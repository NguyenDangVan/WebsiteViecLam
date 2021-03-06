﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NguoiTimViec_DangKyTimViec : System.Web.UI.Page
{
    UngVienBLL ungvienbll = new UngVienBLL();
    clsEncrypt encrypt = new clsEncrypt();
    ThanhPho tp = new ThanhPho();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadThanhPho();
        }
    }
    private void ClearTextBox()
    {
        txtHoTen.Text = "";
        txtDiaChiUV.Text = "";
        txtEmailUV.Text = "";
        txtMatKhauUV.Text = "";
        txtNgaySinh.Text = "";
        txtSDTUV.Text = "";
    }
    private void LoadThanhPho()
    {
        ddlDK_ThanhPho.DataSource = tp.LoadDuLieu();
        ddlDK_ThanhPho.DataValueField = "ID_ThanhPho";
        ddlDK_ThanhPho.DataTextField = "TenThanhPho";
        ddlDK_ThanhPho.DataBind();
    }
    protected void btnDangKyUngVien_Click(object sender, EventArgs e)
    {
        UngVienDTO uv = new UngVienDTO();
        string mahoaMK = encrypt.GetMD5(txtMatKhauUV.Text);
        DateTime ngaysinh = Convert.ToDateTime(txtNgaySinh.Text.ToString());
        String.Format("{0:d}", ngaysinh);
        if (ungvienbll.KiemTraEmail(txtEmailUV.Text.ToString()) == false)
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
                // gán giá trị
                uv.HoTen = txtHoTen.Text;
                uv.MatKhau = mahoaMK;
                uv.DiaChi = txtDiaChiUV.Text;
                uv.NgaySinh = txtNgaySinh.Text.ToString();
                uv.GioiTinh = gioitinh;
                uv.Email = txtEmailUV.Text;
                uv.ID_ThanhPho = thanhpho;
                uv.SDT = txtSDTUV.Text;
                try 
                { 
                    ungvienbll.LuuUngVien(uv);
                    Response.Write("<script> alert('Đăng ký thành công.')</script>");
                }
                catch (Exception) 
                {
                    Response.Write("<script> alert('Đăng ký không thành công.')</script>");
                }
                ClearTextBox();
            }
        }
    }
    protected void btnHuyUngVien_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
}