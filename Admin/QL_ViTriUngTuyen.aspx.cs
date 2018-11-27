using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_ViTriUngTuyen : System.Web.UI.Page
{
    ViTriBLL vt = new ViTriBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnVT_Sua.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadViTri();
        }
    }
    private void LoadViTri()
    {
        grvViTri.DataSource = vt.DsViTri();
        grvViTri.DataBind();
    }
    protected void btnVT_ThemMoi_Click(object sender, EventArgs e)
    {
        lblTextIDViTri.Text = "";
        lblID_ViTri.Text = "";
        txtViTri.Text = "";
        lblTB_ViTri.Text = "";
        btnVT_Luu.Enabled = true;
        btnVT_Sua.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }

    protected void btnVT_Luu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtViTri.Text != "")
            {
                vt.LuuViTri(txtViTri.Text.Trim());
                LoadViTri();
                txtViTri.Text = "";
                OK.Visible = true;
                lblTB_ViTri.Text = "Thành công";
            }
            else
            {
                Stop.Visible = true;
                lblTB_ViTri.Text = "Tên vị trí ứng tuyển không được để trống";
            }
        }
        catch (Exception)
        { }
    }

    protected void btnVT_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtViTri.Text != "")
            {
                int id = int.Parse(lblID_ViTri.Text);
                vt.SuaViTri(id, txtViTri.Text);
                LoadViTri();
                txtViTri.Text = "";
                OK.Visible = true;
                lblTB_ViTri.Text = "Thành công";
                btnVT_Luu.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_ViTri.Text = "Tên vị trí ứng tuyển không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_ViTri.Text = "Không sửa được";
        }
    }
    protected void grvViTri_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_ViTri")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_ViTri.Text = "";
                int idvt = int.Parse(e.CommandArgument.ToString());
                ViTriDTO kq = vt.Get_ViTri(idvt);
                btnVT_Luu.Enabled = false;
                btnVT_Sua.Enabled = true;
                lblTextIDViTri.Text = "Mã vị trí:";
                lblID_ViTri.Text = kq.ID_ViTri.ToString();
                txtViTri.Text = kq.TenViTri;
            }
            if (e.CommandName == "cmdDelete_ViTri")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                vt.XoaViTri(id);
                LoadViTri();
                OK.Visible = true;
                lblTB_ViTri.Text = "Thành công";
            }
        }
        catch (Exception)
        { }
    }
}