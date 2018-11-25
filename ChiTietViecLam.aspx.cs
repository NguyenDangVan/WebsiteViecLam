using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChiTietViecLam : System.Web.UI.Page
{
    ViecLam vl = new ViecLam();
    DangKyBLL dk = new DangKyBLL();
    CV_UngVienBLL cv = new CV_UngVienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ChiTietViecLamTheoMa();
        }
    }
    private void ChiTietViecLamTheoMa()
    {
        int id = Convert.ToInt32(Request.QueryString["IDViecLam"]);
        String[] detailvl;
        detailvl = vl.ChiTietViecLam(id);
        lblCTVL_TenViecLam.Text = detailvl[0].ToString();
        lblCTVL_NgayDang.Text = "<b>Ngày đăng:</b> " + String.Format("{0:d}", detailvl[1].ToString());
        lblCTVL_TenCTy.Text = "<b>" + detailvl[2].ToString() + "</b>";
        lblCTVL_DiaChiCTy.Text = "<b>Địa chỉ:</b> " + detailvl[3].ToString();
        lblCTVL_SoLuong.Text = detailvl[4].ToString();
        lblCTVL_ThuViec.Text = detailvl[5].ToString();
        lblCTVL_TrinhDo.Text = detailvl[6].ToString();
        lblCTVL_KinhNghiem.Text = detailvl[7].ToString();
        lblCTVL_ViTri.Text = detailvl[8].ToString();
        lblCTVL_GioiTinh.Text = detailvl[9].ToString();
        lblCTVL_MucLuong.Text = detailvl[10].ToString();
        lblCTVL_NganhNghe.Text = detailvl[11].ToString();
        lblCTVL_ThanhPho.Text = detailvl[12].ToString();
        lblCTVL_MoTa.Text = detailvl[13].ToString();
        lblCTVL_yeuCauKyNang.Text = detailvl[14].ToString();
        lblCTVL_HoSo.Text = detailvl[15].ToString();
        lblCTVL_NgayHetHan.Text = String.Format("{0:M-d-yyyy}", detailvl[16].ToString());
    }
    protected void btnCTVL_NopHoSo_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["IDUngVien"] == null)
            {
                //Response.Write("<script> alert('Bạn chưa đăng nhập.')</script>");
                Response.Redirect("~/NguoiTimViec/DangNhapNguoiTimViec.aspx?returnUrl=" + Request.Url.PathAndQuery);
            }
            else
            {
                int ID_NguoiTimViec = (int)Session["IDUngVien"];
                int id_cv = cv.LayID_CV(ID_NguoiTimViec);
                int idvl = Convert.ToInt32(Request.QueryString["IDViecLam"]);
                dk.LuuDangKy(id_cv, idvl, String.Format("{0:M-d-yyyy}", DateTime.Now), 0);
                Response.Write("<script> alert('Nộp hồ sơ thành công.')</script>");
                btnCTVL_NopHoSo.Visible = false;
            }

        }
        catch (Exception)
        {
            Response.Write("<script> alert('Nộp hồ sơ không thành công.')</script>");
        }
    }
}