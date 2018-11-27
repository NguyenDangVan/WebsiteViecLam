using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QL_TrinhDo : System.Web.UI.Page
{
    TrinhDoBLL td = new TrinhDoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        OK.Visible = false;
        Stop.Visible = false;
        btnTD_Sua.Enabled = false;
        if (!Page.IsPostBack)
        {
            LoadTrinhDo();
        }
    }
    private void LoadTrinhDo()
    {
        grvTrinhDo.DataSource = td.DsTrinhDo();
        grvTrinhDo.DataBind();
    }

    protected void btnTD_ThemMoi_Click(object sender, EventArgs e)
    {
        lblTextIDTrinhDo.Text = "";
        lblID_TrinhDo.Text = "";
        txtTrinhDo.Text = "";
        lblTB_TrinhDo.Text = "";
        btnTD_Luu.Enabled = true;
        btnTD_Sua.Enabled = false;
        OK.Visible = false;
        Stop.Visible = false;
    }
    protected void grvTrinhDo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdEdit_TrinhDo")
            {
                OK.Visible = false;
                Stop.Visible = false;
                lblTB_TrinhDo.Text = "";
                int idtd = int.Parse(e.CommandArgument.ToString());
                TrinhDoDTO kq = td.Get_TrinhDo(idtd);
                btnTD_Luu.Enabled = false;
                btnTD_Sua.Enabled = true;
                lblTextIDTrinhDo.Text = "Mã trình độ:";
                lblID_TrinhDo.Text = kq.ID_TrinhDo.ToString();
                txtTrinhDo.Text = kq.TenTrinhDo;
            }
            if (e.CommandName == "cmdDelete_TrinhDo")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                td.XoaTrinhDo(id);
                LoadTrinhDo();
                OK.Visible = true;
                lblTB_TrinhDo.Text = "Thành công";
            }
        }
        catch (Exception )
        { }
    }
    protected void btnTD_Luu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTrinhDo.Text != "")
            {
                td.LuuTrinhDo(txtTrinhDo.Text.Trim());
                LoadTrinhDo();
                txtTrinhDo.Text = "";
                OK.Visible = true;
                lblTB_TrinhDo.Text = "Thành công";
            }
            else
            {
                Stop.Visible = true;
                lblTB_TrinhDo.Text = "Tên trình độ không được để trống";
            }
        }
        catch (Exception)
        { }
    }

    protected void btnTD_Sua_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTrinhDo.Text != "")
            {
                int id = int.Parse(lblID_TrinhDo.Text);
                td.SuaTrinhDo(id, txtTrinhDo.Text);
                LoadTrinhDo();
                txtTrinhDo.Text = "";
                OK.Visible = true;
                lblTB_TrinhDo.Text = "Thành công";
                btnTD_Luu.Enabled = true;
            }
            else
            {
                Stop.Visible = true;
                lblTB_TrinhDo.Text = "Tên trình độ không được để trống";
            }
        }
        catch (Exception)
        {
            Stop.Visible = true;
            lblTB_TrinhDo.Text = "Không sửa được";
        }
    }
}