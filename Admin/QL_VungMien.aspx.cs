using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_VungMien : System.Web.UI.Page
{
    VungMienBLL vung = new VungMienBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnVung_Sua.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadVung();
        }
    }
    private void LoadVung()
    {
        grvVung.DataSource = vung.DsVungMien();
        grvVung.DataBind();
    }

    protected void btnVung_ThemMoi_Click(object sender, EventArgs e)
    {
        lblTextIDVung.Text = "";
        lblID_Vung.Text = "";
        txtTenVung.Text = "";
        lblTB_Vung.Text = "";
        btnVung_Luu.Enabled = true;
        btnVung_Sua.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }
    protected void grvVung_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_Vung")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_Vung.Text = "";
                int idvung = int.Parse(e.CommandArgument.ToString());
                VungMienDTO kq = vung.Get_VungMien(idvung);
                btnVung_Luu.Enabled = false;
                btnVung_Sua.Enabled = true;
                lblTextIDVung.Text = "Mã ngành:";
                lblID_Vung.Text = kq.ID_VungMien.ToString();
                txtTenVung.Text = kq.TenVungMien;
            }
            if (e.CommandName == "cmdDelete_Vung")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                vung.XoaVung(id);
                LoadVung();
                OK.Visible = true;
                lblTB_Vung.Text = "Thành công";
            }
        }
        catch (Exception)
        { }
    }
    protected void btnVung_Luu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenVung.Text != "")
            {
                vung.LuuVung(txtTenVung.Text.Trim());
                LoadVung();
                txtTenVung.Text = "";
                OK.Visible = true;
                lblTB_Vung.Text = "Thành công";
            }
            else
            {
                Stop.Visible = true;
                lblTB_Vung.Text = "Tên vùng không được để trống";
            }
        }
        catch (Exception)
        { }
    }

    protected void btnVung_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenVung.Text != "")
            {
                int id = int.Parse(lblID_Vung.Text);
                vung.SuaVung(id, txtTenVung.Text);
                LoadVung();
                txtTenVung.Text = "";
                OK.Visible = true;
                lblTB_Vung.Text = "Thành công";
                btnVung_Luu.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_Vung.Text = "Tên vùng không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_Vung.Text = "Không sửa được";
        }
    }
}