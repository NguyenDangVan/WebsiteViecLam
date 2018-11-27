using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_NganhNghe : System.Web.UI.Page
{
    NganhNghe nn = new NganhNghe();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnSua_Nganh.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadNganhNghe();
        }
    }

    protected void LoadNganhNghe()
    {
        grvLoaiNganh.DataSource = nn.DsNganhNghe();
        grvLoaiNganh.DataBind();
    }
    protected void btnHuy_Nganh_Click(object sender, EventArgs e)
    {
        lblIDNghe.Text = "";
        lblID_NganhNghe.Text = "";
        txtTenNganh.Text = "";
        lblTB_NganhNghe.Text = "";
        btnLuu_Nganh.Enabled = true;
        btnSua_Nganh.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }
    protected void grvLoaiNganh_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_LoaiNganh")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_NganhNghe.Text = "";
                int idnganh = int.Parse(e.CommandArgument.ToString());
                NganhNgheDTO nganh = new NganhNgheDTO();
                nganh = nn.Get_NganhNghe(idnganh);
                btnLuu_Nganh.Enabled = false;
                btnSua_Nganh.Enabled = true;
                lblIDNghe.Text = "Mã ngành:";
                lblID_NganhNghe.Text = nganh.ID_NganhNghe.ToString();
                txtTenNganh.Text = nganh.TenNganhNghe;
            }
            if (e.CommandName == "cmdDelete_LoaiNganh")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                nn.XoaNganh(id);
                LoadNganhNghe();
                OK.Visible = true;
                lblTB_NganhNghe.Text = "Thành công";
            }
        }
        catch (Exception )
        { }
    }
    protected void btnLuu_Nganh_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenNganh.Text != "")
            {
                nn.LuuNganh(txtTenNganh.Text.Trim());
                txtTenNganh.Text = "";
                OK.Visible = true;
                lblTB_NganhNghe.Text = "Thành công";
                LoadNganhNghe();
            }
            else
            {
                Stop.Visible = true;
                lblTB_NganhNghe.Text = "Tên ngành nghề không được để trống";
            }
        }
        catch(Exception){}
    }
    protected void btnSua_Nganh_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTenNganh.Text != "")
            {
                int id = int.Parse(lblID_NganhNghe.Text);
                nn.SuaNganhNghe(id, txtTenNganh.Text);
                LoadNganhNghe();
                txtTenNganh.Text = "";
                OK.Visible = true;
                lblTB_NganhNghe.Text = "Thành công";
                btnLuu_Nganh.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_NganhNghe.Text = "Tên ngành nghề không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_NganhNghe.Text = "Không sửa được";
        }
    }
}