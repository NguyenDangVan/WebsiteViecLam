using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_KinhNghiem : System.Web.UI.Page
{
    KinhNghiemBLL kn = new KinhNghiemBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnKN_Sua.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadKinhNghiem();
        }
    }
    private void LoadKinhNghiem()
    {
        grvKinhNghiem.DataSource = kn.DsKinhNghiem();
        grvKinhNghiem.DataBind();
    }
    protected void btnKN_ThemMoi_Click(object sender, EventArgs e)
    {
        lblTextIDKinhNghiem.Text = "";
        lblID_KinhNghiem.Text = "";
        txtKinhNghiem.Text = "";
        lblTB_KN.Text = "";
        btnKN_Luu.Enabled = true;
        btnKN_Sua.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }

    protected void btnKN_Luu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtKinhNghiem.Text != "")
            {
                kn.LuuKinhNghiem(txtKinhNghiem.Text.Trim());
                LoadKinhNghiem();
                txtKinhNghiem.Text = "";
                OK.Visible = true;
                lblTB_KN.Text = "Thành công";
            }
            else
            {
                Stop.Visible = true;
                lblTB_KN.Text = "Tên kinh nghiệm không được để trống";
            }
        }
        catch (Exception)
        { }
    }

    protected void btnKN_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtKinhNghiem.Text != "")
            {
                int id = int.Parse(lblID_KinhNghiem.Text);
                kn.SuaKinhNghiem(id, txtKinhNghiem.Text);
                LoadKinhNghiem();
                txtKinhNghiem.Text = "";
                OK.Visible = true;
                lblTB_KN.Text = "Thành công";
                btnKN_Luu.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_KN.Text = "Tên kinh nghiệm không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_KN.Text = "Không sửa được";
        }
    }
    protected void grvKinhNghiem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_KinhNghiem")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_KN.Text = "";
                int idkn = int.Parse(e.CommandArgument.ToString());
                KinhNghiemDTO kq = kn.Get_KinhNghiem(idkn);
                btnKN_Luu.Enabled = false;
                btnKN_Sua.Enabled = true;
                lblTextIDKinhNghiem.Text = "Mã kinh nghiệm:";
                lblID_KinhNghiem.Text = kq.ID_KinhNghiem.ToString();
                txtKinhNghiem.Text = kq.TenKinhNghiem;
            }
            if (e.CommandName == "cmdDelete_KinhNghiem")
            {
                int idKinhNghiem = int.Parse(e.CommandArgument.ToString());
                kn.XoaKinhNghiem(idKinhNghiem);
                LoadKinhNghiem();
                OK.Visible = true;
                lblTB_KN.Text = "Thành công";
            }
        }
        catch (Exception)
        { }
    }
}