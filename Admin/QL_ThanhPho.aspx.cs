using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_ThanhPho : System.Web.UI.Page
{
    ThanhPho tp = new ThanhPho();
    VungMienBLL vung = new VungMienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnTP_Sua.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadVung();
            LoadDSThanhPho();
        }
    }
    private void LoadVung()
    {
        ddlQL_Vung.DataSource = vung.DsVungMien();
        ddlQL_Vung.DataTextField = "TenVung";
        ddlQL_Vung.DataValueField = "ID_Vung";
        ddlQL_Vung.DataBind();
    }
    private void LoadDSThanhPho()
    {
        grvThanhPho.DataSource = tp.LoadDuLieu();
        grvThanhPho.DataBind();
    }

    protected void btnTP_ThemMoi_Click(object sender, EventArgs e)
    {
        lblTextID.Text = "";
        lblID_ThanhPho.Text = "";
        txtTenThanhPho.Text = "";
        lblTB_TP.Text = "";
        btnTP_Luu.Enabled = true;
        btnTP_Sua.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }
    protected void grvThanhPho_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_TP")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_TP.Text = "";
                int idtp = int.Parse(e.CommandArgument.ToString());
                ThanhPhoDTO kq = new ThanhPhoDTO();
                kq = tp.Get_ThanhPho(idtp);
                btnTP_Luu.Enabled = false;
                btnTP_Sua.Enabled = true;
                lblTextID.Text = "Mã thành phố:";
                lblID_ThanhPho.Text = kq.ID_ThanhPho.ToString();
                ddlQL_Vung.SelectedValue = kq.ID_VungMien.ToString();
                txtTenThanhPho.Text = kq.TenThanhPho;
            }
            if (e.CommandName == "cmdDelete_TP")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                tp.XoaThanhPho(id);
                LoadDSThanhPho();
                OK.Visible = true;
                lblTB_TP.Text = "Thành công";
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btnTP_Luu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenThanhPho.Text != "")
            {
                int vung = Convert.ToInt32(ddlQL_Vung.SelectedValue.ToString());
                tp.LuuTP(txtTenThanhPho.Text, vung);
                LoadDSThanhPho();
                txtTenThanhPho.Text = "";
                OK.Visible = true;
                lblTB_TP.Text = "Thành công";
            }
            else
            {
                Stop.Visible = true;
                lblTB_TP.Text = "Tên thành phố không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_TP.Text = "Thất bại";
        }
    }

    protected void btnTP_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenThanhPho.Text != "")
            {
                int id = int.Parse(lblID_ThanhPho.Text);
                int idvung = Convert.ToInt32(ddlQL_Vung.SelectedValue.ToString());
                tp.SuaThanhPho(id, txtTenThanhPho.Text, idvung);
                LoadDSThanhPho();
                txtTenThanhPho.Text = "";
                OK.Visible = true;
                lblTB_TP.Text = "Thành công";
                btnTP_Luu.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_TP.Text = "Tên thành phố không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_TP.Text = "Không sửa được";
        }
    }
}