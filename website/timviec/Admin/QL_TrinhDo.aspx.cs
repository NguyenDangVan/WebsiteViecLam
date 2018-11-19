using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;
using BLL;

namespace timviec.Admin
{
    public partial class QL_TrinhDo : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        clsTrinhDo td = new clsTrinhDo();
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

        //load trinh do len gridview
        private void LoadTrinhDo()
        {
            grvTrinhDo.DataSource = td.dsTrinhDo();
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
            catch (Exception ex)
            { }
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
                    var kq = (from n in data.TrinhDos
                              where (n.ID_TrinhDo == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    btnTD_Luu.Enabled = false;
                    btnTD_Sua.Enabled = true;
                    lblTextIDTrinhDo.Text = "Mã ngành:";
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_TrinhDo.Text = "Không sửa được";
            }
        }
    }
}