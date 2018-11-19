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
    public partial class QL_KinhNghiem : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        clsKinhNghiem kn = new clsKinhNghiem();
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

        //load kinh nghiem len gridview
        private void LoadKinhNghiem()
        {
            grvKinhNghiem.DataSource = kn.dsKinhNghiem();
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
            catch (Exception ex)
            { }
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
                    var kq = (from n in data.KinhNghiems
                              where (n.ID_KinhNghiem == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    btnKN_Luu.Enabled = false;
                    btnKN_Sua.Enabled = true;
                    lblTextIDKinhNghiem.Text = "Mã ngành:";
                    lblID_KinhNghiem.Text = kq.ID_KinhNghiem.ToString();
                    txtKinhNghiem.Text = kq.TenKinhNghiem;
                }
                if (e.CommandName == "cmdDelete_KinhNghiem")
                {
                    int idKinhNghiem = int.Parse(e.CommandArgument.ToString());
                    kn.XoaKinhNghiem(idKinhNghiem);
                    //var kq = from n in data.KinhNghiems
                    //         where (n.ID_KinhNghiem == int.Parse(e.CommandArgument.ToString()))
                    //         select n;
                    //data.KinhNghiems.DeleteAllOnSubmit(kq);
                    //data.SubmitChanges();
                    LoadKinhNghiem();
                    OK.Visible = true;
                    lblTB_KN.Text = "Thành công";
                }
            }
            catch (Exception ex)
            { }
        }

        protected void btnKN_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKinhNghiem.Text != "")
                {
                    //var kq = data.KinhNghiems.Single(p => p.ID_KinhNghiem == int.Parse(lblID_KinhNghiem.Text));
                    //kq.TenKinhNghiem = txtKinhNghiem.Text;
                    //data.SubmitChanges();
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
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_KN.Text = "Không sửa được";
            }
        }
    }
}