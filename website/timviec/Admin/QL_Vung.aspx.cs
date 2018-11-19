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
    public partial class QL_Vung : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
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
        //load danh sach vung len gridview
        private void LoadVung()
        {
            grvVung.DataSource = vung.dsVung();
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
            catch (Exception ex)
            { }
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
                    var kq = (from n in data.VungMiens
                              where (n.ID_Vung == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    btnVung_Luu.Enabled = false;
                    btnVung_Sua.Enabled = true;
                    lblTextIDVung.Text = "Mã ngành:";
                    lblID_Vung.Text = kq.ID_Vung.ToString();
                    txtTenVung.Text = kq.TenVung;
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_Vung.Text = "Không sửa được";
            }
        }
    }
}