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
    public partial class LoaiTaiKhoan : System.Web.UI.Page
    {
        LoaiTaiKhoanBLL loaiTK = new LoaiTaiKhoanBLL();
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            OK.Visible = false;
            Stop.Visible = false;
            btnSua_LoaiTK.Enabled = false;
            if (!Page.IsPostBack)
            {
                load_LoaiTK();
            }
        }

        protected void btnLuu_LoaiTK_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiTK.Text.Trim() != null)
            {
                loaiTK.LuuLoaiTK(txtTenLoaiTK.Text.Trim());
                txtTenLoaiTK.Text = "";
                OK.Visible = true;
                lblTB_LoaiTK.Text = "Thành công";
                load_LoaiTK();
            }
            else
            {
                Stop.Visible = true;
                lblTB_LoaiTK.Text = "Chưa nhập thông tin";
            }
        }

        private void load_LoaiTK()
        {
            //data.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebsiteViecLamConnectionString"].ToString();
            grvLoaiTK.DataSource = loaiTK.dsLoaiTK();
            grvLoaiTK.DataBind();
        }

        protected void btnSua_LoaiTK_Click(object sender, EventArgs e)
        {
            try
            {
                var kq = data.LoaiTaiKhoans.Single(p => p.ID_LoaiTaiKhoan == int.Parse(lblID_LoaiTK.Text));
                kq.TenLoai = txtTenLoaiTK.Text;
                data.SubmitChanges();
                load_LoaiTK();
                txtTenLoaiTK.Text = "";
                OK.Visible = true;
                lblTB_LoaiTK.Text = "Thành công";
                btnLuu_LoaiTK.Enabled = true;
            }
            catch (Exception ex)
            {
                Stop.Visible = true;
                lblTB_LoaiTK.Text = "Không sửa được";
            }
        }

        protected void grvLoaiTK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "cmdEdit_LoaiTK")
                {
                    var kq = (from n in data.LoaiTaiKhoans
                              where (n.ID_LoaiTaiKhoan == int.Parse(e.CommandArgument.ToString()))
                              select n).SingleOrDefault();
                    btnLuu_LoaiTK.Enabled = false;
                    btnSua_LoaiTK.Enabled = true;
                    lblID.Text = "Mã loại tài khoản: ";
                    lblID_LoaiTK.Text = kq.ID_LoaiTaiKhoan.ToString();
                    txtTenLoaiTK.Text = kq.TenLoai;
                }
                if (e.CommandName == "cmdDelete_LoaiTK")
                {
                    var kq = from n in data.LoaiTaiKhoans
                             where (n.ID_LoaiTaiKhoan == int.Parse(e.CommandArgument.ToString()))
                             select n;
                    data.LoaiTaiKhoans.DeleteAllOnSubmit(kq);
                    data.SubmitChanges();
                    load_LoaiTK();
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        protected void btnHuy_LoaiTK_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            lblID_LoaiTK.Text = "";
            txtTenLoaiTK.Text = "";
            lblTB_LoaiTK.Text = "";
        }
    }
}