using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NguoiTimViec_NguoiTimViec : System.Web.UI.Page
{
    NganhNghe nn = new NganhNghe();
    ViTriBLL vt = new ViTriBLL();
    TrinhDoBLL td = new TrinhDoBLL();
    KinhNghiemBLL kn = new KinhNghiemBLL();
    CV_UngVienBLL cvungvienbll = new CV_UngVienBLL();
    public int CurrentID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        UngVienDTO uv = (UngVienDTO) (Session["UngVien"]);
        //CurrentID = uv.ID_UngVien;
        
        UV_HoSoUngVien.Visible = false;
        if(uv != null)
        {
            lblHoTen.Text = uv.HoTen;
            lblGioiTinh.Text = uv.GioiTinh;
            lblNgaySinh.Text = Convert.ToString(String.Format("{0:d}", uv.NgaySinh));
            lblSDT.Text = uv.SDT;
            lblEmail.Text = uv.Email;
            lblDiaChi.Text = uv.DiaChi;
        }
        if (!Page.IsPostBack)
        {
            LoadNganhNghe();
            LoadViTri();
            LoadTrinhDo();
            LoadKinhNghiem();

        }
        //Session.Remove("user");
    }
    protected void LoadNganhNghe()
    {
        ddlUV_NganhNghe.DataSource = nn.DsNganhNghe();
        ddlUV_NganhNghe.DataTextField = "TenNganhNghe";
        ddlUV_NganhNghe.DataValueField = "ID_NganhNghe";
        ddlUV_NganhNghe.DataBind();
    }
    protected void LoadViTri()
    {
        ddlUV_ViTri.DataSource = vt.DsViTri();
        ddlUV_ViTri.DataTextField = "TenViTri";
        ddlUV_ViTri.DataValueField = "ID_ViTri";
        ddlUV_ViTri.DataBind();
    }
    protected void LoadTrinhDo()
    {
        ddlUV_TrinhDo.DataSource = td.DsTrinhDo();
        ddlUV_TrinhDo.DataTextField = "TenTrinhDo";
        ddlUV_TrinhDo.DataValueField = "ID_TrinhDo";
        ddlUV_TrinhDo.DataBind();
    }
    protected void LoadKinhNghiem()
    {
        ddlUV_KinhNghiem.DataSource = kn.DsKinhNghiem();
        ddlUV_KinhNghiem.DataTextField = "TenKinhNghiem";
        ddlUV_KinhNghiem.DataValueField = "ID_KinhNghiem";
        ddlUV_KinhNghiem.DataBind();
    }
    private void ClearTextBox()
    {
        txtUV_BangCap.Text = "";
        txtUV_KyNang.Text = "";
        txtUV_NgoaiNgu.Text = "";
        txtUV_TieuDe.Text = "";
    }
    protected void lnkTuHoSo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
        UV_HoSoUngVien.Visible = true;
    }
    protected void lnkTaiKhoan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
    }
    protected void lnkViecLamUngTuyen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/ViecLamDaUngTuyen.aspx");
    }
    protected void lnkNhaTuyenDungXemHoSo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NguoiTimViec/NhaTuyenDungXemHoSo.aspx");
    }
    protected void btnUV_XemCV_Click(object sender, EventArgs e)
    {
        UV_HoSoUngVien.Visible = true;
        try 
        { 
            CurrentID = (int)Session["IDUngVien"];
            CV_UngVienDTO cv = new CV_UngVienDTO();
            cv = cvungvienbll.Get_CVUngVien(CurrentID);
            if (cv.ID_UngVien != null)
            {
                if (cv.TrangThai == 1)
                {
                    lblThongBao.Text = "Đã kích hoạt";
                    lblID_CVUngVien.Text = cv.ID_CV.ToString();
                    txtUV_TieuDe.Text = cv.TieuDe;
                    ddlUV_NganhNghe.SelectedValue = cv.ID_NganhNghe.ToString();
                    ddlUV_ViTri.SelectedValue = cv.ID_ViTri.ToString();
                    ddlUV_TrinhDo.SelectedValue = cv.ID_TrinhDo.ToString();
                    ddlUV_KinhNghiem.SelectedValue = cv.ID_KinhNghiem.ToString();
                    txtUV_KyNang.Text = cv.KyNang;
                    txtUV_NgoaiNgu.Text = cv.NgoaiNgu;
                    ddlUV_MucLuong.SelectedValue = cv.MucLuong;
                    txtUV_BangCap.Text = cv.BangCap;
                    btnUV_Luu.Visible = false;
                }
                else
                {   
                    lblThongBao.Text = "Chưa kích hoạt";
                    btnUV_Luu.Visible = true;
                }
                
            }
            else
            {
                ClearTextBox();
                btnUV_Luu.Visible = true;
            }
        }
        catch
        {
            Response.Redirect("~/TrangChu.aspx");
            Response.Write("<script> alert('Bạn chưa đăng nhập')</script>");
        }
    }
    protected void btnUV_Luu_Click(object sender, EventArgs e)
    {
        try
        {

            CurrentID = (int)Session["IDUngVien"];
            CV_UngVienDTO cv = new CV_UngVienDTO();
            cv.TieuDe = txtUV_TieuDe.Text;
            cv.ID_NganhNghe = Convert.ToInt32(ddlUV_NganhNghe.SelectedValue.ToString());
            cv.KyNang = txtUV_KyNang.Text;
            cv.ID_ViTri = Convert.ToInt32(ddlUV_ViTri.SelectedValue.ToString());
            cv.ID_TrinhDo = Convert.ToInt32(ddlUV_TrinhDo.SelectedValue.ToString());
            cv.ID_KinhNghiem = Convert.ToInt32(ddlUV_KinhNghiem.SelectedValue.ToString());
            cv.NgoaiNgu = txtUV_NgoaiNgu.Text;
            cv.MucLuong = ddlUV_MucLuong.SelectedItem.ToString();
            cv.BangCap = txtUV_BangCap.Text;
            cv.TrangThai = 0;
            cvungvienbll.LuuCVUngVien(cv, CurrentID);
            //cv.LuuCVUngVien(CurrentID, txtUV_TieuDe.Text, Convert.ToInt32(ddlUV_NganhNghe.SelectedValue.ToString()), txtUV_KyNang.Text, Convert.ToInt32(ddlUV_ViTri.SelectedValue.ToString()),
            //                Convert.ToInt32(ddlUV_TrinhDo.SelectedValue.ToString()), Convert.ToInt32(ddlUV_KinhNghiem.SelectedValue.ToString()), txtUV_NgoaiNgu.Text,
            //                ddlUV_MucLuong.SelectedItem.ToString(), txtUV_BangCap.Text, false);
            Response.Write("<script> alert('Lưu thành công.')</script>");
            ClearTextBox();
        }
        catch (Exception )
        {
            Response.Write("<script> alert('Lưu không công.')</script>");
        }
    }
    protected void btnUV_CapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentID = (int)Session["IDUngVien"];
            //foreach (var s in kq)
            //    lblID_CVUngVien.Text = s.ID_CV.ToString();
            cvungvienbll.CapNhatCV(CurrentID, txtUV_TieuDe.Text, Convert.ToInt32(ddlUV_NganhNghe.SelectedValue.ToString()), txtUV_KyNang.Text,
                         Convert.ToInt32(ddlUV_ViTri.SelectedValue.ToString()), Convert.ToInt32(ddlUV_TrinhDo.SelectedValue.ToString()),
                         Convert.ToInt32(ddlUV_KinhNghiem.SelectedValue.ToString()),
                         txtUV_NgoaiNgu.Text, ddlUV_MucLuong.SelectedValue.ToString(), txtUV_BangCap.Text);
            Response.Write("<script> alert('Cập nhật thành công.')</script>");
        }
        catch (Exception)
        {
        }
    }
    protected void btnUV_Xoa_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentID = (int)Session["IDUngVien"];
            
            cvungvienbll.XoaCV(CurrentID);
            Response.Write("<script> alert('Xóa thành công.')</script>");
            UV_HoSoUngVien.Visible = false;
        }
        catch (Exception )
        { }
    }
}