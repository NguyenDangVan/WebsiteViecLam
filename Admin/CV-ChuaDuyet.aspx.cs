using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_CV_ChuaDuyet : System.Web.UI.Page
{
    CV_UngVienBLL cv = new CV_UngVienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        IDCVChuaDuyet.Visible = false;
        if (!Page.IsPostBack)
        {
            LoadCV();
        }
    }
    private void LoadCV()
    {
        
        grvDS_CVChuaDuyet.DataSource = cv.LoadCV();
        grvDS_CVChuaDuyet.DataBind();
    }
    protected void grvDS_CVChuaDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit_CV")
            {
                IDCVChuaDuyet.Visible = true;
                int idcv = int.Parse(e.CommandArgument.ToString());
                DataTable kq = cv.CV_ChuaDuyet(idcv);
                lblCV_ID.Text = kq.Rows[0]["ID_CV"].ToString();
                txtCV_TieuDe.Text = kq.Rows[0]["TieuDe"].ToString();
                txtCV_NganhNghe.Text = kq.Rows[0]["TenNganhNghe"].ToString();
                txtCV_KyNang.Text = kq.Rows[0]["KyNang"].ToString();
                txtCV_ViTri.Text = kq.Rows[0]["TenViTri"].ToString();
                txtCV_TrinhDo.Text = kq.Rows[0]["TenTrinhDo"].ToString();
                txtCV_KinhNghiem.Text = kq.Rows[0]["TenKinhNghiem"].ToString();
                txtCV_NgoaiNgu.Text = kq.Rows[0]["NgoaiNgu"].ToString();
                txtCV_MucLuong.Text = kq.Rows[0]["MucLuong"].ToString();
                txtCV_Bang.Text = kq.Rows[0]["BangCap"].ToString();
            }
        }
        catch (Exception){}
    }
    protected void grvDS_CVChuaDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadCV();
        grvDS_CVChuaDuyet.PageIndex = e.NewPageIndex;
        grvDS_CVChuaDuyet.DataBind();
    }
    protected void btnDuyetCV_Click(object sender, EventArgs e)
    {

    }
}