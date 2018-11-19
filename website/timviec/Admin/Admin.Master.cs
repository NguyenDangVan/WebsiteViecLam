using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using DAL;
using BLL;

namespace timviec.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string CurrentName { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (Session.GetName_Admin() == null)
            {
                Response.Redirect("Login.aspx?returnUrl=" + Request.Url.PathAndQuery);
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TaiKhoan hoten = Session.GetName_Admin();
            if (hoten != null)
            {
                CurrentName = hoten.HoTen;
                lblChao.Text = "Wellcome:";
                lblUser.Text = CurrentName;
                lbtThoat.Text = "Thoát";
            }
            else
            {
                lblChao.Text = "";
                lblUser.Text = "";
                lbtThoat.Visible = true;
            }
        }

        protected void lbtThoat_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}