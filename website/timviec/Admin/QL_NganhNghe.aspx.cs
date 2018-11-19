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
    public partial class QL_NganhNghe : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        nganhNghe nn = new nganhNghe();
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

        //load ngành nghề lên Gridview
        protected void LoadNganhNghe()
        {
            grvLoaiNganh.DataSource = nn.dsNganhNghe();
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
            catch (Exception ex)
            { }
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
                    var kq = (from n in data.NganhNghes
                              where (n.ID_NganhNghe == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    btnLuu_Nganh.Enabled = false;
                    btnSua_Nganh.Enabled = true;
                    lblIDNghe.Text = "Mã ngành:";
                    lblID_NganhNghe.Text = kq.ID_NganhNghe.ToString();
                    txtTenNganh.Text = kq.TenNganhNghe;
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
            catch (Exception ex)
            { }
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
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_NganhNghe.Text = "Không sửa được";
            }
        }
    }
}