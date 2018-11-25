using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.MasterPage
{
    TrinhDoBLL td = new TrinhDoBLL();
    ViTriBLL vt = new ViTriBLL();
    KinhNghiemBLL kn = new KinhNghiemBLL();
    NganhNghe nn = new NganhNghe();
    ThanhPho tp = new ThanhPho();
    UngVienBLL uvbll = new UngVienBLL();
    CongTyBLL ctbll = new CongTyBLL();
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
            // ứng viên
            UngVienDTO uv = new UngVienDTO();
            if(Session["UngVien"] != null)
            {
                lblDefault_User.Text = "Xin chào: ";
                lbtDefault_User.Text = (String)Session["TenUV"];
                lblDefault_User.Visible = true;
            }
            // nhà tuyển dụng
            if (Session["NhaTuyenDung"] != null)
            {
                lblDefault_User.Text = "Xin chào: ";
                string tendangnhap = (string)Session["TenDangNhap"];
                CongTy ct = new CongTy();
                ct = ctbll.Get_CongTy(tendangnhap);
                lbtDefault_User.Text = ct.TenCongTy;
                lblDefault_User.Visible = true;
            }
        }
    }
    protected void lbtDefault_User_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UngVien"] != null)
            {
                Response.Redirect("~/NguoiTimViec/NguoiTimViec.aspx");
            }
            if (Session["NhaTuyenDung"] != null)
            {
                Response.Redirect("~/NhaTuyenDung/NhaTuyenDung.aspx");
            }
        }
        catch (Exception)
        { }
    }
    protected void lbtDefault_ThoatUser_Click(object sender, EventArgs e)
    {
        Session.Remove("UngVien");
        Session.Remove("IDUngVien");
        Session.Remove("TenUV");
        Session.Abandon();
        Response.Redirect("~/TrangChu.aspx");
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
        catch (Exception)
        { }
    }
    private void loadNganh()
    {
        ddlNganhNghe.DataSource = nn.DsNganhNghe();
        ddlNganhNghe.DataValueField = "ID_NganhNghe";
        ddlNganhNghe.DataTextField = "TenNganhNghe";
        ddlNganhNghe.DataBind();
    }
    private void loadThanhPho()
    {
        ddlThanhPho.DataSource = tp.LoadDuLieu();
        ddlThanhPho.DataValueField = "ID_ThanhPho";
        ddlThanhPho.DataTextField = "TenThanhPho";
        ddlThanhPho.DataBind();
    }
    private void loadTrinhDo()
    {
        ddlSearchTrinhDo.DataSource = td.DsTrinhDo();
        ddlSearchTrinhDo.DataValueField = "ID_TrinhDo";
        ddlSearchTrinhDo.DataTextField = "TenTrinhDo";
        ddlSearchTrinhDo.DataBind();
    }

    private void loadViTri()
    {
        ddlSearchViTri.DataSource = vt.DsViTri();
        ddlSearchViTri.DataValueField = "ID_ViTri";
        ddlSearchViTri.DataTextField = "TenViTri";
        ddlSearchViTri.DataBind();
    }

    private void loadKinhNghiem()
    {
        ddlSearchKinhNghiem.DataSource = kn.DsKinhNghiem();
        ddlSearchKinhNghiem.DataValueField = "ID_KinhNghiem";
        ddlSearchKinhNghiem.DataTextField = "TenKinhNghiem";
        ddlSearchKinhNghiem.DataBind();
    }

    private void loadSearchNganh()
    {
        ddlSearchNghe.DataSource = nn.DsNganhNghe();
        ddlSearchNghe.DataValueField = "ID_NganhNghe";
        ddlSearchNghe.DataTextField = "TenNganhNghe";
        ddlSearchNghe.DataBind();
    }
    private void loadSearchThanhPho()
    {
        ddlSearchThanhPho.DataSource = tp.LoadDuLieu();
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
            Response.Redirect("~/TimKiem.aspx?IDNghe=" + idnghe + "&IdTP=" + idtp + "&Search=" + txtSearch.Text);
        }
        catch (Exception)
        { }
    }
}
