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
    public partial class QL_ViTriUngTuyen : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        clsViTriLamViec vt = new clsViTriLamViec();
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

        //load vi tri len gridview
        private void LoadViTri()
        {
            grvViTri.DataSource = vt.dsViTri();
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
            catch (Exception ex)
            { }
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
                    var kq = (from n in data.ViTriUngTuyens
                              where (n.ID_ViTri == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_ViTri.Text = "Không sửa được";
            }
        }
    }
}